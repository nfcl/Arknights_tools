using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using json_real;
using System.Windows.Data;

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
            picture.Source = new BitmapImage(new Uri("pack://application:,,,/" + path));
            picture.Width = width;
            return picture;
        }
    }

    /// <summary>
    /// 干员筛选词缀码
    /// </summary>
    public class checkIdnum
    {
        /// <summary>
        /// <para/>原始码
        /// <para/>professional，rarity，tag 进行加法计算后的结果
        /// </summary>
        public int Origanal { get; set; }

        /// <summary>
        /// <para/>职业码
        /// <para/>从低位到高位依次为
        /// <para/>先锋 近卫 重装 狙击 术士 医疗 辅助 特种
        /// </summary>
        public int Profession { get; set; }
        /// <summary>
        /// <para/>稀有度码
        /// <para/>从低位到高位依次为
        /// <para/>1星 2星 3星 4星 5星 6星
        /// </summary>
        public int Rarity { get; set; }
        /// <summary>
        /// <para/>tag码
        /// <para/>从低位到高位依次为
        /// <para/>新手 治疗 支援 输出 群攻 减速 生存 防护
        /// <para/>削弱 位移 控场 爆发 召唤 快速复活 费用回复 支援机械
        /// </summary>
        public int Tag { get; set; }

        /// <summary>
        /// 设置原始码
        /// 同时改变其他的码
        /// </summary>
        /// <param name="ori">传入的原始码</param>
        public void setOriganal(int ori)
        {
            Origanal    = ori;
            Profession  = ori & 0b000000000000000000000011111111;
            Rarity      = ori & 0b000000000000000011111100000000;
            Tag         = ori & 0b111111111111111100000000000000;
        }

        public checkIdnum()
        {
            Origanal    = 0;
            Profession  = 0;
            Rarity      = 0;
            Tag         = 0;
        }
    }

    /// <summary>
    /// 用于在不同cs文件间传递数据
    /// </summary>
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

    public class Charinfo_Tapitem
    {
        public TabItem Main_Content;
        private ScrollViewer Main_Scroll;
        private Grid Main_Grid;
        public Charinfo_Tapitem(int id)
        {
            Main_Content = new TabItem();
            Main_Content.Header = GlobalArgs.Chartable.char_info[id].name;
            {
                Main_Grid = new Grid();
                Main_Content.Content = Main_Grid;
                {
                    Main_Scroll = new ScrollViewer();
                    Main_Grid.Children.Add(Main_Scroll);
                    {
                        StackPanel Main_Stackpannel = new StackPanel();
                        Main_Scroll.Content = Main_Stackpannel;
                        {
                            Grid Charinfo_Grid = new Grid();
                            GridCutters(Charinfo_Grid, 2, 1);
                            {
                                TextBlock CharInfo_Topic_TextBlock = new TextBlock();
                                {
                                    CharInfo_Topic_TextBlock.Text = "干员信息";
                                    CharInfo_Topic_TextBlock.FontSize = 40;
                                    CharInfo_Topic_TextBlock.Margin = new Thickness(10);
                                    Charinfo_Grid.Children.Add(CharInfo_Topic_TextBlock);
                                    Grid.SetRow(CharInfo_Topic_TextBlock, 0);
                                }
                                Image Charinfo_Background_Image = new Image();
                                {
                                    Charinfo_Background_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Background/Charinfo_background1.png"));
                                    Charinfo_Background_Image.Margin = new Thickness(10);
                                    Charinfo_Grid.Children.Add(Charinfo_Background_Image);
                                    Grid.SetRow(Charinfo_Background_Image, 1);
                                }
                                Border Charinfo_Background_Border = new Border();
                                {
                                    Charinfo_Background_Border.Background = Brushes.LightGray;
                                    Charinfo_Grid.Children.Add(Charinfo_Background_Border);
                                    Grid.SetRow(Charinfo_Background_Border, 1);
                                }
                                Grid Charinfo_Sum_Grid = new Grid();
                                {
                                    Charinfo_Grid.Children.Add(Charinfo_Sum_Grid);
                                    Grid.SetRow(Charinfo_Sum_Grid, 1);
                                    Image Charinfo_Stdpaint_Image = new Image();
                                    {
                                        Charinfo_Sum_Grid.Children.Add(Charinfo_Stdpaint_Image);
                                        Charinfo_Stdpaint_Image.Stretch = Stretch.Uniform;
                                        Charinfo_Stdpaint_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/Stdpaint/" + GlobalArgs.Chartable.char_info[id].PicName[0] + ".png"));
                                        Charinfo_Stdpaint_Image.Margin = new Thickness(10);
                                        Binding tmpbinding = new Binding("Height");
                                        BindingOperations.SetBinding(Charinfo_Stdpaint_Image, Image.ActualHeightProperty, tmpbinding);
                                    }
                                    Border Charinfo_Professional_Ico_Border = new Border();
                                    {
                                        Charinfo_Sum_Grid.Children.Add(Charinfo_Professional_Ico_Border);
                                        Charinfo_Professional_Ico_Border.BorderBrush = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                                        Charinfo_Professional_Ico_Border.BorderThickness = new Thickness(3);
                                        Charinfo_Professional_Ico_Border.Width = 100;
                                        Charinfo_Professional_Ico_Border.Height = 100;
                                        Charinfo_Professional_Ico_Border.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                                        Charinfo_Professional_Ico_Border.Opacity = 0.8;
                                        Charinfo_Professional_Ico_Border.CornerRadius = new CornerRadius(10);
                                        Charinfo_Professional_Ico_Border.HorizontalAlignment = HorizontalAlignment.Left;
                                        Charinfo_Professional_Ico_Border.VerticalAlignment = VerticalAlignment.Bottom;
                                        Charinfo_Professional_Ico_Border.Margin = new Thickness(30);
                                    }
                                    Image Charinfo_Professional_Ico_Image = new Image();
                                    {
                                        Charinfo_Sum_Grid.Children.Add(Charinfo_Professional_Ico_Image);
                                        Charinfo_Professional_Ico_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Optbch/" + GlobalArgs.Chartable.char_info[id].subProfessionId + ".png"));
                                        Charinfo_Professional_Ico_Image.Width = 80;
                                        Charinfo_Professional_Ico_Image.Height = 80;
                                        Charinfo_Professional_Ico_Image.Margin = new Thickness(40);
                                        Charinfo_Professional_Ico_Image.HorizontalAlignment = HorizontalAlignment.Left;
                                        Charinfo_Professional_Ico_Image.VerticalAlignment = VerticalAlignment.Bottom;
                                    }
                                    Border Charinfo_Professional_Name_Border = new Border();
                                    {
                                        Charinfo_Sum_Grid.Children.Add(Charinfo_Professional_Name_Border);
                                        Charinfo_Professional_Name_Border.BorderBrush = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                                        Charinfo_Professional_Name_Border.Opacity = 0.8;
                                        Charinfo_Professional_Name_Border.BorderThickness = new Thickness(3);
                                        Charinfo_Professional_Name_Border.Width = 200;
                                        Charinfo_Professional_Name_Border.Height = 30;
                                        Charinfo_Professional_Name_Border.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                                        Charinfo_Professional_Name_Border.CornerRadius = new CornerRadius(5);
                                        Charinfo_Professional_Name_Border.VerticalAlignment = VerticalAlignment.Bottom;
                                        Charinfo_Professional_Name_Border.HorizontalAlignment = HorizontalAlignment.Left;
                                        Charinfo_Professional_Name_Border.Margin = new Thickness(140, 100, 0, 0);
                                    }
                                    TextBlock Charinfo_Professional_Name_TextBlock = new TextBlock();
                                    {
                                        Charinfo_Professional_Name_TextBlock.FontSize = 20;
                                        Charinfo_Professional_Name_TextBlock.Text = GlobalArgs.Chartable.char_info[id].profession + " - " + GlobalArgs.Chartable.char_info[id].subProfessionId;



                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 将一个Grid切割为row行col列
        /// </summary>
        /// <param name="GoalGrid">目标Grid</param>
        /// <param name="row">目标行数</param>
        /// <param name="col">目标列数</param>
        /// <param name="height">
        /// <para>设置行高</para>
        /// <para>可选 默认为0即auto</para>
        /// </param>
        /// <param name="width">设置列宽 和行高同理</param>
        public void GridCutters(Grid GoalGrid, int row, int col, double height = 0, double width = 0)
        {
            for (int i = 0; i < row; i++)
                GoalGrid.RowDefinitions.Add(new RowDefinition { Height = (height == 0 ? GridLength.Auto : new GridLength(height)) });
            for (int i = 0; i < col; i++)
                GoalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = (width == 0 ? GridLength.Auto : new GridLength(width)) });
        }

    }
}
