using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using json_real;

namespace ClassSum
{
    public class StoreMatrielMode
    {
        private Button _up;
        private Button _down;
        private TextBox _num;
        private Image _picture;
        private int _level;
        private int _uid;

        /// <summary>
        /// 数量+1按钮
        /// </summary>
        public Button Up 
        {
            get 
            {
                return _up;
            }
            set
            { 
                _up = value;
            } 
        }

        /// <summary>
        /// 数量-1按钮
        /// </summary>
        public Button Down
        {
            get
            {
                return _down;
            }
            set
            {
                _down = value;
            }
        }

        /// <summary>
        /// 数量显示文本框
        /// </summary>
        public TextBox Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
            }
        }

        /// <summary>
        /// 图片显示
        /// </summary>
        public Image Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;

            }
        }

        /// <summary>
        /// 材料等级（意义不明的）
        /// </summary>
        public int Level 
        { 
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        /// <summary>
        /// 当前控件组的UID序号
        /// </summary>
        public int Uid 
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
            }
        }

        /// <summary>
        /// 生成一个材料显示模板 参数如下
        /// </summary>
        /// <param name="width">整个材料模板的宽度</param>
        /// <param name="heigth">整个材料模板的高度</param>
        /// <param name="num">材料的数量 用于TextBox的赋值</param>
        /// <param name="path">材料图片路径</param>
        /// <param name="level">材料等级</param>
        /// <param name="parent">DockPannel父控件用于把模板内控件的排版</param>
        /// <param name="uid">这个模板的全部控件UID</param>
        public StoreMatrielMode(int width, int heigth, int num, string path, int level, DockPanel parent, int uid)
        {
            Uid = uid;
            Picture = create_picture(path, width);
            Up = create_up((int)((heigth - width) * 0.8));
            Down = create_down((int)((heigth - width) * 0.8));
            Num = create_num(num);
            parent.Children.Add(Picture);
            DockPanel.SetDock(Picture, Dock.Top);
            parent.Children.Add(Down);
            DockPanel.SetDock(Down, Dock.Left);
            parent.Children.Add(Up);
            DockPanel.SetDock(Up, Dock.Right);
            parent.Children.Add(Num);
            DockPanel.SetDock(Num, Dock.Bottom);
            Level = level;
        }//构造函数，提供展示框在x,y位置

        /// <summary>
        /// 设置+1按钮的单击事件
        /// </summary>
        /// <param name="REH">一个路由事件用于赋值</param>
        public void SetUpClick(RoutedEventHandler REH)
        {
            Up.Click += REH;
        }

        /// <summary>
        /// 设置-1按钮的单击事件
        /// </summary>
        /// <param name="REH">一个路由事件用于赋值</param>
        public void SetDownClick(RoutedEventHandler REH)
        {
            Down.Click += REH;
        }

        /// <summary>
        /// 设置TextBox的change事件
        /// </summary>
        /// <param name="REH">一个TextChangedEventHandler事件用于赋值</param>
        public void SetNumChange(TextChangedEventHandler REH)
        {
            Num.TextChanged += REH; ;
        }

        private TextBox create_num( int value)
        {
            TextBox num = new TextBox();
            num.Uid = Uid.ToString();
            num.FontSize = 24;
            num.TextAlignment = TextAlignment.Center;
            num.Text = value.ToString();
            return num;
        }

        private Button create_up(int width)
        {
            Button up = new Button();
            up.Content = ">";
            up.Uid = Uid.ToString();
            up.Width = width - 20;
            up.Margin = new Thickness(0, 0, 20, 0);
            return up;
        }

        private Button create_down(int width)
        {
            Button down = new Button();
            down.Content = "<";
            down.Uid = Uid.ToString();
            down.Width = width - 20;
            down.Margin = new Thickness(20, 0, 0, 0);
            return down;
        }

        private Image create_picture(string path, int width)
        {
            Image picture = new Image();
            picture.Uid = Uid.ToString();
            picture.Source = new BitmapImage(new Uri(path));
            picture.Width = width;
            return picture;
        }
    }

    public class checkIdnum
    {
        public int Origanal { get; set; }
        public int Profession { get; set; }
        public int Rarity { get; set; }
        public int Tag { get; set; }

        public void setOriganal(int ori)
        {
            Origanal    = ori;
            Profession  = ori & 0b000000000000000000000011111111;
            Rarity      = ori & 0b000000000000000011111100000000;
            Tag         = ori & 0b111111111111111100000000000000;
        }

        public checkIdnum()
        {
            Origanal = 0;
        }
    }

    public static class GlobalArgs
    {
        /// <summary>
        /// <para/>仓库页面的单个材料展示面板组
        /// <para/>包含：
        /// <para/>一个Image用于展示材料图片
        /// <para/>一个Textbox用于显示数量并快速更改数量
        /// <para/>两个Button用于对数量进行+-1操作
        /// </summary>
        public static StoreMatrielMode[] MatrielMode;
        /// <summary>
        /// <para/>matriels.json的json实体类
        /// <para/>保存了材料的数量信息
        /// </summary>
        public static Matriels_Root MatrielsMakble;
        /// <summary>
        /// 干员信息
        /// </summary>
        public static Root_CharTable Chartable;
        /// <summary>
        /// 筛选信息
        /// <para/>包括:
        /// <para/>职业
        /// <para/>稀有度
        /// <para/>tag
        /// </summary>
        public static checkIdnum CheckIdnum;
    }
}
