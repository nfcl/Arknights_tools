using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using json_real;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

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

        private TextBox create_num(int value)
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
        /// <para/>先锋 近卫 重装 狙击 
        /// <para/>术士 医疗 辅助 特种
        /// </summary>
        public int Profession { get; set; }
        public int Professional_All = 0b11111111;
        /// <summary>
        /// <para/>稀有度码
        /// <para/>从低位到高位依次为
        /// <para/>1星 2星 3星 4星 5星 6星
        /// </summary>
        public int Rarity { get; set; }
        public int Rarity_All = 0b11111100000000;
        /// <summary>
        /// <para/>tag码
        /// <para/>从低位到高位依次为
        /// <para/>新手   治疗        支援        输出  
        /// <para/>群攻   减速        生存        防护
        /// <para/>削弱   位移        控场        爆发  
        /// <para/>召唤   快速复活    费用回复
        /// </summary>
        public int Tag { get; set; }
        public int Tag_All = 0b11111111111111100000000000000;

        /// <summary>
        /// 设置原始码
        /// 同时改变其他的码
        /// </summary>
        /// <param name="ori">传入的原始码</param>
        public void setOriganal(int ori)
        {
            Origanal = ori;
            Profession = ori & Professional_All;
            Rarity = ori & Rarity_All;
            Tag = ori & Tag_All;
        }

        public checkIdnum()
        {
            Origanal = 0;
            Profession = 0;
            Rarity = 0;
            Tag = 0;
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
        public static Matriels_Root Matriels;
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
        /// <summary>
        /// 
        /// </summary>
        public static List<Charinfo_Tapitem> charinfo_Tapitems;
    }

    /// <summary>
    /// 用于储存人物展示的数据和UI进行绑定
    /// </summary>
    public class Charinfo_Tapitem: INotifyPropertyChanged
    {
        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private readonly string position;
        private readonly string Profession_Ch;
        private readonly string SubProfessionId_Ch;
        private readonly string SubProfessionId_En;
        private readonly List<SkinItem> skins;

        public string Tag { get; }
        public string Name_Ch { get; }
        public string Name_En { get; }
        public string Special { get; }
        public int Rarity { get; }
        public string ImplementationOrder { get; }
        public int Skin_now { get; set; }
        public int Phase_Num { get; }

        public class Skin
        {
            #region INPC
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            #endregion

            public string Name { get; }
            public BitmapImage Avatar { get; }
            public Button Mainbutton { get; set; }
            public int Is_Select { get; set; }
            public SolidColorBrush BorderColor { get; }

            public void SetSelect()
            {
                (Mainbutton.Template.FindName("SelectIcon", Mainbutton) as Image).Opacity = Is_Select;
            }

            public Skin(string name, Uri avatar, Color color)
            {
                Name = name;
                Avatar = new BitmapImage(avatar);
                Is_Select = 0;
                BorderColor = new SolidColorBrush(color);
            }
        }

        public Grid Skill_DataGrid { get; }
        public Grid Talent_DataGrid { get; }
        public Grid Parse_Matriels_DataGrid { get; }
        public List<Button> Skins_Select_Button { get; }
        public List<string> Skins_picname { get; }
        public List<Image> Skins_Select { get; }
        public Button Avatar_Select_Button { get; }

        public List<Skin> Skins;
        public int? Select_Skin = null;
        public string Position => position == "RANGED" ? "远程位" : "近战位";
        public string Professional_Text => Profession_Ch + " - " + SubProfessionId_Ch;
        public string Describle => skins[Skin_now].describle;
        public int Skin_Num => Skins_Select.Count - Phase_Num;
        public BitmapImage Bust_Paint => new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/bust/" + Skins_picname[Skin_now] + ".png"));
        public BitmapImage Avatar_Paint => new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/avatar/" + Skins_picname[Skin_now] + ".png"));
        public BitmapImage Stand_Paint => new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/Stdpaint/" + Skins_picname[Skin_now] + ".png"));
        public BitmapImage Professional_Image => new BitmapImage(new Uri("pack://application:,,,/Resources/image/Optbch/" + SubProfessionId_En + ".png"));

        public void Select_Skin_Click(object sender, RoutedEventArgs e)
        {
            Button Sender = sender as Button;
            if (Skin_now >=Phase_Num)
            {
                Skins[Skin_now - Phase_Num].Is_Select = 0;
                Skins[Skin_now - Phase_Num].SetSelect();
            }
            Skin_now = int.Parse(Sender.Uid);
            Skins[Skin_now - Phase_Num].Is_Select = 1;
            Skins[Skin_now - Phase_Num].SetSelect();
            OnPropertyChanged("Stand_Paint");
            OnPropertyChanged("Describle");
        }

        public void Select_Phase_Click(object sender, RoutedEventArgs e)
        {
            Button Sender = sender as Button;
            if (Skin_now >= Phase_Num)
            {
                Skins[Skin_now - Phase_Num].Is_Select = 0;
                Skins[Skin_now - Phase_Num].SetSelect();
            }
            Skin_now = int.Parse(Sender.Uid);
            OnPropertyChanged("Stand_Paint");
            OnPropertyChanged("Describle");
        }

        public Charinfo_Tapitem(Char_infoItem original)
        {
            //名字（中文）
            Name_Ch = original.name;

            //位置（近战位和远程位）
            position = original.position;

            //稀有度,-1
            Rarity = original.rarity;

            //描述
            Special = original.description;

            //外文名
            Name_En = original.appellation;

            //主职业（中文）
            Profession_Ch = original.Profession_Ch;

            //职业分支（英文）
            SubProfessionId_En = original.SubProfessionId_En;

            //职业分支（中文）
            SubProfessionId_Ch = original.SubProfessionId_Ch;

            //皮肤名称（英文图片名）
            skins = original.Skins;

            //干员序号
            ImplementationOrder = original.ImplementationOrder.ToString();

            //技能部分
            {
                Skill_DataGrid = new Grid();
                Skill_DataGrid.RowDefinitions.Clear();
                TextBlock TmpText;
                Border TmpBorder;
                SolidColorBrush BackgroundColor;
                Dictionary<string, SolidColorBrush> Colors = new Dictionary<string, SolidColorBrush>()
            {
                { "自动回复", new SolidColorBrush(Color.FromArgb(200,142,195,31 ))},
                { "攻击回复", new SolidColorBrush(Color.FromArgb(200,252,121,62 ))},
                { "受击回复", new SolidColorBrush(Color.FromArgb(200,251,178,2  ))},
                { "手动触发", new SolidColorBrush(Color.FromArgb(200,115,115,115))},
                { "自动触发", new SolidColorBrush(Color.FromArgb(200,115,115,115))},
                { "被动"    , new SolidColorBrush(Color.FromArgb(200,115,115,115))},
            };
                foreach (SkillsItem skilltmp in original.skills)
                {
                    Skill_DataGrid.RowDefinitions.Add(new RowDefinition());
                    {
                        Grid Single_Skill_Grid = new Grid();
                        {
                            Skill_DataGrid.Children.Add(Single_Skill_Grid);
                            Grid.SetRow(Single_Skill_Grid, Skill_DataGrid.RowDefinitions.Count - 1);
                            Single_Skill_Grid.RowDefinitions.Add(new RowDefinition());
                            Single_Skill_Grid.RowDefinitions.Add(new RowDefinition());
                            Grid Single_Skill_Outface_Grid = new Grid();
                            {
                                Single_Skill_Grid.Children.Add(Single_Skill_Outface_Grid);
                                Grid.SetRow(Single_Skill_Outface_Grid, 0);
                                int[] Skill_Outface_Percent = new int[4] { 1, 4, 2, 1 };
                                foreach (int tmp1 in Skill_Outface_Percent)
                                {
                                    Single_Skill_Outface_Grid.ColumnDefinitions.Add(new ColumnDefinition());
                                    Single_Skill_Outface_Grid.ColumnDefinitions[Single_Skill_Outface_Grid.ColumnDefinitions.Count - 1].Width = new GridLength(tmp1, GridUnitType.Star);
                                }
                                Image Skill_Icon_Image = new Image()
                                {
                                    Margin = new Thickness(40),
                                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/skillico/skill_icon_" + skilltmp.skillId + ".png")),
                                    VerticalAlignment = VerticalAlignment.Center,
                                    HorizontalAlignment = HorizontalAlignment.Center
                                };
                                Single_Skill_Outface_Grid.Children.Add(Skill_Icon_Image);
                                Grid.SetColumn(Skill_Icon_Image, 0);
                                Grid.SetRow(Skill_Icon_Image, 0);

                                TextBlock Skill_Name_TextBlock = new TextBlock()
                                {
                                    Text = skilltmp.skillname,
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center
                                };
                                Single_Skill_Outface_Grid.Children.Add(Skill_Name_TextBlock);
                                Grid.SetColumn(Skill_Name_TextBlock, 1);
                                Grid.SetRow(Skill_Name_TextBlock, 0);

                                Grid Skill_Kind_Grid = new Grid();
                                Skill_Kind_Grid.RowDefinitions.Add(new RowDefinition());
                                Skill_Kind_Grid.RowDefinitions.Add(new RowDefinition());
                                Single_Skill_Outface_Grid.Children.Add(Skill_Kind_Grid);
                                Grid.SetColumn(Skill_Kind_Grid, 2);
                                Grid.SetRow(Skill_Kind_Grid, 0);
                                {
                                    if (skilltmp.replykind != null)
                                    {
                                        TmpText = new TextBlock()
                                        {
                                            Margin = new Thickness(15, 7, 15, 7),
                                            Foreground = Brushes.White,
                                            Text = skilltmp.replykind,
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            VerticalAlignment = VerticalAlignment.Center
                                        };
                                        TmpBorder = new Border()
                                        {
                                            CornerRadius = new CornerRadius(5),
                                            Child = TmpText,
                                            Background = Colors[skilltmp.replykind],
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            VerticalAlignment = VerticalAlignment.Center
                                        };
                                        Grid.SetRow(TmpBorder, Skill_Kind_Grid.Children.Add(TmpBorder));
                                        if (TmpText.Text == "被动")
                                        {
                                            Grid.SetRowSpan(TmpBorder, 2);
                                        }
                                        else
                                        {
                                            Grid.SetRowSpan(TmpBorder, 1);
                                        }
                                    }
                                    if (skilltmp.triggerkind != null)
                                    {
                                        TmpText = new TextBlock()
                                        {
                                            Margin = new Thickness(15, 7, 15, 7),
                                            Foreground = Brushes.White,
                                            Text = skilltmp.triggerkind,
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            VerticalAlignment = VerticalAlignment.Center
                                        };
                                        TmpBorder = new Border()
                                        {
                                            CornerRadius = new CornerRadius(5),
                                            Child = TmpText,
                                            Background = Colors[skilltmp.triggerkind],
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            VerticalAlignment = VerticalAlignment.Center
                                        };
                                        Grid.SetRow(TmpBorder, Skill_Kind_Grid.Children.Add(TmpBorder));
                                    }
                                }
                            }
                        }

                        Grid Single_Skill_Describle_Grid = new Grid();
                        {
                            Single_Skill_Grid.Children.Add(Single_Skill_Describle_Grid);
                            Grid.SetRow(Single_Skill_Describle_Grid, 1);
                            double[] Skill_Describle_Width_Percent = new double[] { 1, 10, 1.3, 1.3, 1.3 };
                            string[] Skill_Describle_Header = new string[] { "等级", "描述", "初始技力", "消耗技力", "持续时间" };
                            Single_Skill_Describle_Grid.RowDefinitions.Add(new RowDefinition());
                            for (int i = 0; i < 5; ++i)
                            {
                                Single_Skill_Describle_Grid.ColumnDefinitions.Add(new ColumnDefinition());
                                Single_Skill_Describle_Grid.ColumnDefinitions[i].Width = new GridLength(Skill_Describle_Width_Percent[i], GridUnitType.Star);
                                TmpText = new TextBlock
                                {
                                    Text = Skill_Describle_Header[i],
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Margin = new Thickness(10)
                                };
                                TmpBorder = new Border
                                {
                                    Background = new SolidColorBrush(Color.FromArgb(80, 34, 34, 34)),
                                    Child = TmpText
                                };
                                Grid.SetColumn(TmpBorder, Single_Skill_Describle_Grid.Children.Add(TmpBorder));
                                Grid.SetRow(TmpBorder, 0);
                            }
                            for (int i = 0; i < skilltmp.skillDescrible.Count; ++i)
                            {
                                if (i % 2 == 0)
                                {
                                    BackgroundColor = new SolidColorBrush(Color.FromArgb(80, 200, 200, 200));

                                }
                                else
                                {
                                    BackgroundColor = new SolidColorBrush(Color.FromArgb(80, 34, 34, 34));

                                }
                                Single_Skill_Describle_Grid.RowDefinitions.Add(new RowDefinition());
                                TmpText = new TextBlock()
                                {
                                    Margin = new Thickness(10),
                                    Text = (i + 1 >= 8 ? "RANK" + (i - 6).ToString() : (i + 1).ToString()),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center
                                };
                                TmpBorder = new Border
                                {
                                    Margin = new Thickness(1, 10, 1, 10),
                                    Background = BackgroundColor,
                                    Child = TmpText
                                };
                                Single_Skill_Describle_Grid.Children.Add(TmpBorder);
                                Grid.SetColumn(TmpBorder, 0);
                                Grid.SetRow(TmpBorder, i + 1);
                                TmpText = new TextBlock()
                                {
                                    Margin = new Thickness(10),
                                    Text = skilltmp.skillDescrible[i].describle,
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    TextWrapping = TextWrapping.Wrap
                                };
                                TmpBorder = new Border
                                {
                                    Margin = new Thickness(1, 10, 1, 10),
                                    Background = BackgroundColor,
                                    Child = TmpText
                                };
                                Single_Skill_Describle_Grid.Children.Add(TmpBorder);
                                Grid.SetColumn(TmpBorder, 1);
                                Grid.SetRow(TmpBorder, i + 1);
                                TmpText = new TextBlock()
                                {
                                    Margin = new Thickness(10),
                                    Text = skilltmp.skillDescrible[i].start.ToString(),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center
                                };
                                TmpBorder = new Border
                                {
                                    Margin = new Thickness(1, 10, 1, 10),
                                    Background = BackgroundColor,
                                    Child = TmpText
                                };
                                Single_Skill_Describle_Grid.Children.Add(TmpBorder);
                                Grid.SetColumn(TmpBorder, 2);
                                Grid.SetRow(TmpBorder, i + 1);
                                TmpText = new TextBlock()
                                {
                                    Margin = new Thickness(10),
                                    Text = skilltmp.skillDescrible[i].deplete.ToString(),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center
                                };
                                TmpBorder = new Border
                                {
                                    Margin = new Thickness(1, 10, 1, 10),
                                    Background = BackgroundColor,
                                    Child = TmpText
                                };
                                Single_Skill_Describle_Grid.Children.Add(TmpBorder);
                                Grid.SetColumn(TmpBorder, 3);
                                Grid.SetRow(TmpBorder, i + 1);
                                TmpText = new TextBlock()
                                {
                                    Margin = new Thickness(10),
                                    Text = skilltmp.skillDescrible[i].continued.ToString(),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center
                                };
                                TmpBorder = new Border
                                {
                                    Margin = new Thickness(1, 10, 1, 10),
                                    Background = BackgroundColor,
                                    Child = TmpText
                                };
                                Single_Skill_Describle_Grid.Children.Add(TmpBorder);
                                Grid.SetColumn(TmpBorder, 4);
                                Grid.SetRow(TmpBorder, i + 1);
                            }
                        }
                    }
                }
            }

            //天赋部分
            {
                List<double> Talent_Grid_Col_Width = new List<double>() { 1, 2, 2, 5 };
                List<string> Talent_Grid_Col_Header = new List<string>() { "天赋", "名称", "条件", "描述" };
                List<string> dxsz = new List<string>() { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
                TextBlock tmptext;
                Border tmpborder;
                Talent_DataGrid = new Grid();
                {
                    //列标题 天赋 名称 条件 描述
                    Talent_DataGrid.RowDefinitions.Add(new RowDefinition());
                    for (int i = 0; i < 4; ++i)
                    {
                        Talent_DataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(Talent_Grid_Col_Width[i], GridUnitType.Star) });
                        tmptext = new TextBlock()
                        {
                            Text = Talent_Grid_Col_Header[i],
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(10)
                        };
                        tmpborder = new Border()
                        {
                            Background = new SolidColorBrush(Color.FromArgb(80, 22, 22, 22)),
                            BorderBrush = new SolidColorBrush(Color.FromArgb(80, 200, 200, 200)),
                            Child = tmptext
                        };
                        Talent_DataGrid.Children.Add(tmpborder);
                        Grid.SetRow(tmpborder, 0);
                        Grid.SetColumn(tmpborder, i);
                    }
                    int talentnum = 1;
                    foreach (TalentsItem talentmp in original.talents)
                    {
                        tmptext = new TextBlock()
                        {
                            Text = "第" + dxsz[talentnum] + "天赋",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        tmpborder = new Border()
                        {
                            Child = tmptext,
                            Margin = new Thickness(3),
                            BorderBrush = new SolidColorBrush(Color.FromArgb(80, 150, 150, 150)),
                            BorderThickness = new Thickness(5)
                        };
                        Talent_DataGrid.Children.Add(tmpborder);
                        Grid.SetRow(tmpborder, Talent_DataGrid.RowDefinitions.Count);
                        Grid.SetRowSpan(tmpborder, talentmp.candidates.Count);
                        Grid.SetColumn(tmpborder, 0);
                        ++talentnum;
                        tmptext = new TextBlock()
                        {
                            Margin = new Thickness(10),
                            Text = talentmp.candidates[0].name,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            TextWrapping = TextWrapping.Wrap
                        };
                        tmpborder = new Border()
                        {
                            Child = tmptext,
                            Margin = new Thickness(3),
                            BorderBrush = new SolidColorBrush(Color.FromArgb(80, 150, 150, 150)),
                            BorderThickness = new Thickness(5)
                        };
                        Talent_DataGrid.Children.Add(tmpborder);
                        Grid.SetRow(tmpborder, Talent_DataGrid.RowDefinitions.Count);
                        Grid.SetRowSpan(tmpborder, talentmp.candidates.Count);
                        Grid.SetColumn(tmpborder, 1);

                        foreach (CandidatesItem candidatestmp in talentmp.candidates)
                        {
                            Talent_DataGrid.RowDefinitions.Add(new RowDefinition());
                            string tmpstr = "精英" + dxsz[candidatestmp.unlockCondition.phase] + " " +
                               candidatestmp.unlockCondition.level.ToString() + "级" + " " +
                               "潜能" + candidatestmp.requiredPotentialRank.ToString();
                            tmptext = new TextBlock()
                            {
                                Text = tmpstr,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                TextWrapping = TextWrapping.Wrap,
                                Margin = new Thickness(10)
                            };
                            tmpborder = new Border()
                            {
                                Child = tmptext,
                                Margin = new Thickness(3),
                                BorderBrush = new SolidColorBrush(Color.FromArgb(80, 150, 150, 150)),
                                BorderThickness = new Thickness(5)
                            };
                            Talent_DataGrid.Children.Add(tmpborder);
                            Grid.SetRow(tmpborder, Talent_DataGrid.RowDefinitions.Count - 1);
                            Grid.SetColumn(tmpborder, 2);

                            tmptext = new TextBlock()
                            {
                                Text = candidatestmp.description,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                TextWrapping = TextWrapping.Wrap,
                                Margin = new Thickness(10)
                            };
                            tmpborder = new Border()
                            {
                                Child = tmptext,
                                Margin = new Thickness(3),
                                BorderBrush = new SolidColorBrush(Color.FromArgb(80, 150, 150, 150)),
                                BorderThickness = new Thickness(5)
                            };
                            Talent_DataGrid.Children.Add(tmpborder);
                            Grid.SetRow(tmpborder, Talent_DataGrid.RowDefinitions.Count - 1);
                            Grid.SetColumn(tmpborder, 3);
                        }
                    }
                }
            }

            //精英化材料部分
            {
                TextBlock tmptext;
                Border tmpborder;
                Grid tmpgrid;
                Image tmpimage;
                StackPanel tmpstack;
                List<string> dxsz = new List<string>() { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
                List<List<int>> lmbnum = new List<List<int>>()
                {
                    new List<int> {     0,      0  },
                    new List<int> {     0,      0  },
                    new List<int> { 10000,      0  },
                    new List<int> { 15000,  60000  },
                    new List<int> { 20000, 120000  },
                    new List<int> { 30000, 180000  },
                };
                /*材料uid转图片名称*/
                Dictionary<int, string> Matriels_pic = new Dictionary<int, string>();
                /*材料名称加入字典*/
                foreach (CompositableItem tmpmat in GlobalArgs.Matriels.Matriels.Compositable)
                {
                    Matriels_pic[tmpmat.Uid] = tmpmat.En_Name;
                }
                /*芯片名称加入字典*/
                foreach (ChipItem tmpmat in GlobalArgs.Matriels.Matriels.chip)
                {
                    Matriels_pic[tmpmat.Uid] = tmpmat.En_Name;
                }
                Parse_Matriels_DataGrid = new Grid();
                {
                    {
                        //for (int i = 1; i < original.phases.Count; ++i)
                        //{
                        //    while (Parse_Matriels_DataGrid.ColumnDefinitions.Count < original.phases[i].evolveCost.Count + 2)
                        //    {
                        //        Parse_Matriels_DataGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        //    }
                        //    Parse_Matriels_DataGrid.RowDefinitions.Add(new RowDefinition());
                        //    tmpimage = new Image()
                        //    {
                        //        Stretch = Stretch.None,
                        //        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/pharse/Stage_" + i + ".png"))
                        //    };
                        //    tmpborder = new Border()
                        //    {
                        //        Child = tmpimage,
                        //        Margin = new Thickness(10)
                        //    };
                        //    Parse_Matriels_DataGrid.Children.Add(tmpborder);
                        //    Grid.SetRow(tmpborder, i - 1);
                        //    Grid.SetColumn(tmpborder, 0);

                        //    tmpgrid = new Grid();
                        //    {
                        //        tmpimage = new Image()
                        //        {
                        //            Margin = new Thickness(10),
                        //            Stretch = Stretch.None,
                        //            Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Materials/Dragon_Gate_Coin.png"))
                        //        };
                        //        tmpgrid.Children.Add(tmpimage);
                        //        tmptext = new TextBlock()
                        //        {
                        //            Text = lmbnum[original.rarity][i - 1].ToString(),
                        //            HorizontalAlignment = HorizontalAlignment.Center,
                        //            VerticalAlignment = VerticalAlignment.Center,
                        //            Foreground = Brushes.White,
                        //            Margin = new Thickness(10, 3, 10, 3),
                        //            FontSize = 25
                        //        };
                        //        tmpborder = new Border()
                        //        {
                        //            Child = tmptext,
                        //            Background = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34)),
                        //            HorizontalAlignment = HorizontalAlignment.Right,
                        //            VerticalAlignment = VerticalAlignment.Bottom,
                        //            Margin = new Thickness(0, 0, 75, 27)
                        //        };
                        //        tmpgrid.Children.Add(tmpborder);
                        //    }
                        //    Parse_Matriels_DataGrid.Children.Add(tmpgrid);
                        //    Grid.SetRow(tmpgrid, i - 1);
                        //    Grid.SetColumn(tmpgrid, 1);

                        //    int colnow = 2;
                        //    foreach (EvolveCostItem tmpcost in original.phases[i].evolveCost)
                        //    {
                        //        tmpgrid = new Grid();
                        //        {
                        //            tmpimage = new Image()
                        //            {
                        //                Stretch = Stretch.None,
                        //                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Materials/" + Matriels_pic[int.Parse(tmpcost.id)] + ".png"))
                        //            };
                        //            tmpgrid.Children.Add(tmpimage);
                        //            tmptext = new TextBlock()
                        //            {
                        //                Text = tmpcost.count.ToString(),
                        //                HorizontalAlignment = HorizontalAlignment.Center,
                        //                VerticalAlignment = VerticalAlignment.Center,
                        //                Foreground = Brushes.White,
                        //                Margin = new Thickness(10, 3, 10, 3),
                        //                FontSize = 25
                        //            };
                        //            tmpborder = new Border()
                        //            {
                        //                Child = tmptext,
                        //                Background = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34)),
                        //                HorizontalAlignment = HorizontalAlignment.Right,
                        //                VerticalAlignment = VerticalAlignment.Bottom,
                        //                Margin = new Thickness(0, 0, 75, 27)
                        //            };
                        //            tmpgrid.Children.Add(tmpborder);
                        //        }
                        //        Parse_Matriels_DataGrid.Children.Add(tmpgrid);
                        //        Grid.SetRow(tmpgrid, i - 1);
                        //        Grid.SetColumn(tmpgrid, colnow);
                        //        ++colnow;
                        //    }
                        //}
                    }
                    for (int i = 1; i < original.phases.Count; ++i)
                    {
                        Parse_Matriels_DataGrid.RowDefinitions.Add(new RowDefinition());
                        tmpstack = new StackPanel() { Orientation = Orientation.Horizontal };
                        Parse_Matriels_DataGrid.Children.Add(tmpstack);
                        Grid.SetRow(tmpstack, i - 1);
                        tmpimage = new Image()
                        {
                            Stretch = Stretch.None,
                            Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/pharse/Stage_" + i + ".png"))
                        };
                        tmpborder = new Border()
                        {
                            Child = tmpimage,
                            Margin = new Thickness(10)
                        };
                        tmpstack.Children.Add(tmpborder);

                        tmpgrid = new Grid();
                        {
                            tmpimage = new Image()
                            {
                                Margin = new Thickness(10),
                                Stretch = Stretch.None,
                                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Materials/Dragon_Gate_Coin.png"))
                            };
                            tmpgrid.Children.Add(tmpimage);
                            tmptext = new TextBlock()
                            {
                                Text = lmbnum[original.rarity][i - 1].ToString(),
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Foreground = Brushes.White,
                                Margin = new Thickness(10, 3, 10, 3),
                                FontSize = 25
                            };
                            tmpborder = new Border()
                            {
                                Child = tmptext,
                                Background = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34)),
                                HorizontalAlignment = HorizontalAlignment.Right,
                                VerticalAlignment = VerticalAlignment.Bottom,
                                Margin = new Thickness(0, 0, 25, 25)
                            };
                            tmpgrid.Children.Add(tmpborder);
                        }
                        tmpstack.Children.Add(tmpgrid);
                        foreach (EvolveCostItem tmpcost in original.phases[i].evolveCost)
                        {
                            tmpgrid = new Grid();
                            {
                                tmpimage = new Image()
                                {
                                    Stretch = Stretch.None,
                                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/Materials/" + Matriels_pic[int.Parse(tmpcost.id)] + ".png"))
                                };
                                tmpgrid.Children.Add(tmpimage);
                                tmptext = new TextBlock()
                                {
                                    Text = tmpcost.count.ToString(),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Foreground = Brushes.White,
                                    Margin = new Thickness(10, 3, 10, 3),
                                    FontSize = 25
                                };
                                tmpborder = new Border()
                                {
                                    Child = tmptext,
                                    Background = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34)),
                                    HorizontalAlignment = HorizontalAlignment.Right,
                                    VerticalAlignment = VerticalAlignment.Bottom,
                                    Margin = new Thickness(0, 0, 25, 25)
                                };
                                tmpgrid.Children.Add(tmpborder);
                            }
                            tmpstack.Children.Add(tmpgrid);
                        }
                    }
                }
            }

            //时装及精英化部分
            {
                {
                    /*
                    Button SingleSkin_Button;
                    Grid SingleSkin_Grid;
                    Border tmpborder;
                    TextBlock tmptext;
                    Grid tmpgrid;
                    Image tmpimage;
                    Skins_Select_Button = new List<Button>();
                    Skins_picname = new List<string>();
                    Skins_Select = new List<Image>();
                    int num = 0;
                    string tmpstr;
                    foreach (SkinItem tmpskin in original.Skins)
                    {
                        tmpstr = "";
                        for (int i = 0; i < tmpskin.picture_name.Length; ++i)
                        {
                            if (tmpskin.picture_name[i] == '#')
                            {
                                tmpstr += "%23";
                            }
                            else
                            {
                                tmpstr += tmpskin.picture_name[i];
                            }
                        }
                        ++num;
                        Skins_picname.Add(tmpstr);
                        if (tmpskin.is_phase) continue;
                        SingleSkin_Button = new Button()
                        {
                            Width = 350,
                            Margin = new Thickness(0, 30, 30, -10),
                            Height = 100,
                            Background = Brushes.Transparent,
                            BorderBrush = Brushes.Transparent,
                            Uid = num.ToString()
                        };
                        SingleSkin_Button.Click += Select_Skin;
                        SingleSkin_Grid = new Grid();
                        SingleSkin_Button.Content = SingleSkin_Grid;
                        SingleSkin_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                        SingleSkin_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                        int tmpr = Convert.ToInt32(tmpskin.color.Substring(0, 2), 16);
                        int tmpg = Convert.ToInt32(tmpskin.color.Substring(2, 2), 16);
                        int tmpb = Convert.ToInt32(tmpskin.color.Substring(4, 2), 16);
                        tmpborder = new Border()
                        {
                            Background = new SolidColorBrush(Color.FromRgb((byte)tmpr, (byte)tmpg, (byte)tmpb)),
                            Width = 10,
                            HorizontalAlignment = HorizontalAlignment.Left
                        };
                        SingleSkin_Grid.Children.Add(tmpborder);
                        Grid.SetColumn(tmpborder, 0);
                        tmpgrid = new Grid()
                        {
                            Margin = new Thickness(0, 2, 0, 2)
                        };
                        SingleSkin_Grid.Children.Add(tmpgrid);
                        Grid.SetColumn(tmpgrid, 1);
                        {
                            tmpborder = new Border()
                            {
                                Background = new SolidColorBrush(Color.FromArgb(0xFF,0x33, 0x33, 0x33))
                            };
                            tmpgrid.Children.Add(tmpborder);
                            tmpimage = new Image()
                            {
                                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/avatar/" + Skins_picname[Skins_picname.Count - 1] + ".png")),
                                Stretch = Stretch.Uniform,
                                Width = 150,
                                Height = 150,
                                Margin = new Thickness(10, 0, 0, 0),
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Left,
                            };
                            tmpgrid.Children.Add(tmpimage);
                            tmpborder = new Border()
                            {
                                Width = 50,
                                Margin = new Thickness(-100, 0, 0, 0),
                                Background = new LinearGradientBrush()
                                {
                                    EndPoint = new Point(0, 0.5),
                                    StartPoint = new Point(1, 0.5),
                                    GradientStops = new GradientStopCollection()
                                    {
                                        new GradientStop()
                                        {
                                            Color = Color.FromArgb(0xFF,0x33,0x33,0x33),
                                            Offset = 0
                                        },
                                        new GradientStop()
                                        {
                                            Color = Color.FromArgb(0x00,0x33,0x33,0x33),
                                            Offset = 1
                                        }
                                    }
                                }
                            };
                            tmpgrid.Children.Add(tmpborder);
                            tmptext = new TextBlock()
                            {
                                Text = tmpskin.name,
                                Foreground = Brushes.White,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(185, 0, 0, 0)
                            };
                            tmpgrid.Children.Add(tmptext);
                            tmpimage = new Image()
                            {
                                Stretch = Stretch.Uniform,
                                Width = 100,
                                Height = 100,
                                Opacity = 0,
                                Margin = new Thickness(259,19,0,0),
                                VerticalAlignment = VerticalAlignment.Top,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/others/Charinfo_SkinSelect1.png"))
                            };
                            tmpgrid.Children.Add(tmpimage);
                            Skins_Select.Add(tmpimage);
                        }
                        Skins_Select_Button.Add(SingleSkin_Button);
                    }
                    */
                }
                string tmpstr;
                Skins_picname = new List<string>();
                Skins_Select_Button = new List<Button>();
                Skins = new List<Skin>();
                Phase_Num = 0;
                foreach (SkinItem tmpskin in original.Skins)
                {
                    tmpstr = "";
                    for (int i = 0; i < tmpskin.picture_name.Length; ++i)
                    {
                        if (tmpskin.picture_name[i] == '#')
                        {
                            tmpstr += "%23";
                        }
                        else
                        {
                            tmpstr += tmpskin.picture_name[i];
                        }
                    }
                    Skins_picname.Add(tmpstr);
                    if (tmpskin.is_phase)
                    {
                        ++Phase_Num;
                        continue;
                    }
                    int tmpr = Convert.ToInt32(tmpskin.color.Substring(0, 2), 16);
                    int tmpg = Convert.ToInt32(tmpskin.color.Substring(2, 2), 16);
                    int tmpb = Convert.ToInt32(tmpskin.color.Substring(4, 2), 16);
                    Skin tmpskin1 = new Skin(tmpskin.name,
                        new Uri("pack://application:,,,/Resources/image/char/avatar/" + Skins_picname[Skins_picname.Count - 1] + ".png"),
                        Color.FromRgb((byte)tmpr, (byte)tmpg, (byte)tmpb));
                    Button SingleSkin_Button = new Button();
                    tmpskin1.Mainbutton = SingleSkin_Button;
                    SingleSkin_Button.SetValue(Button.StyleProperty, Application.Current.FindResource("Skin_Select_Button"));
                    SingleSkin_Button.DataContext = tmpskin1;
                    SingleSkin_Button.Opacity = 1;
                    SingleSkin_Button.Click += Select_Skin_Click;
                    SingleSkin_Button.Content = tmpskin.name;
                    SingleSkin_Button.Uid = (Skins_picname.Count - 1).ToString();
                    Skins_Select_Button.Add(SingleSkin_Button);
                    Skins.Add(tmpskin1);
                }
                Skin_now = 0;
            }

            //tag词缀（用于绑定数据到UI）
            {
                Tag = original.tagList[0];
                for (int i = 1; i < original.tagList.Count; ++i)
                {
                    Tag += " ";
                    Tag += original.tagList[i];
                }
            }

            //左侧选择栏头像
            {
                Avatar_Select_Button = new Button();
                {
                    Avatar_Select_Button.Uid = ImplementationOrder;
                    Avatar_Select_Button.HorizontalAlignment = HorizontalAlignment.Center;
                    Avatar_Select_Button.VerticalAlignment = VerticalAlignment.Center;
                    Border Out_Border = new Border();
                    {
                        Avatar_Select_Button.Content = Out_Border;
                        Out_Border.BorderBrush = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34));
                        Out_Border.BorderThickness = new Thickness(3);
                        Out_Border.HorizontalAlignment = HorizontalAlignment.Center;
                        Out_Border.VerticalAlignment = VerticalAlignment.Center;
                        Grid Middle_Grid = new Grid();
                        {
                            Out_Border.Child = Middle_Grid;
                            Middle_Grid.Height = 100;
                            Middle_Grid.Width = 100;
                            Middle_Grid.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                            Middle_Grid.HorizontalAlignment = HorizontalAlignment.Center;
                            Middle_Grid.VerticalAlignment = VerticalAlignment.Center;
                            Border Inner_Border = new Border();
                            {
                                Middle_Grid.Children.Add(Inner_Border);
                                Inner_Border.Background = new SolidColorBrush(Color.FromArgb(200, 34, 34, 34));
                                Inner_Border.BorderBrush = new SolidColorBrush(Color.FromArgb(200, 170, 170, 170));
                                Inner_Border.BorderThickness = new Thickness(2);
                                Inner_Border.HorizontalAlignment = HorizontalAlignment.Center;
                                Inner_Border.VerticalAlignment = VerticalAlignment.Center;
                                Image Avatar_Image = new Image();
                                {
                                    Inner_Border.Child = Avatar_Image;
                                    Avatar_Image.Source = Avatar_Paint;
                                    Avatar_Image.HorizontalAlignment = HorizontalAlignment.Center;
                                    Avatar_Image.VerticalAlignment = VerticalAlignment.Center;
                                }
                            };
                        }
                    }
                }
            }
        }
    }

}
