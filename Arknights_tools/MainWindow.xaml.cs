using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using json_real;
using ClassSum;
using InitFunction;
using tool;
using System.Net;

namespace Arknights_tools
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitStore();
            InitCharCheck();
            ceshi();
        }

        /// <summary>
        /// 进行一些操作
        /// </summary>
        private void ceshi()
        {
            //foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            //{
            //    Charinfo_Tapitem newCharinfo = new Charinfo_Tapitem(i);
            //    newCharinfo.Avatar_Select_Button.Click += Click_Select_Button;
            //    GlobalArgs.charinfo_Tapitems.Add(newCharinfo);
            //    Select_Char_Stackpanel.Children.Add(newCharinfo.Avatar_Select_Button);
            //    Select_Char_Stackpanel.RegisterName("Select_button_" + i.ImplementationOrder, newCharinfo.Avatar_Select_Button);
            //}
            //string s, strtmp;
            //int skilldescribles = 0;
            //int skills = 0;
            //int tmpint = 0;
            //int startid = 0;
            //int tmpend;
            //string socketstr;
            //foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            //{
            //    skills = i.skills.Count;
            //    startid = 0;
            //    s = File.ReadAllText("E:/tmp/" + i.appellation + ".txt");
            //    switch (i.rarity)
            //    {
            //        case 0:
            //            skilldescribles = 0;
            //            break;
            //        case 1:
            //            skilldescribles = 0;
            //            break;
            //        case 2:
            //            skilldescribles = 7;
            //            break;
            //        case 3:
            //            skilldescribles = 10;
            //            break;
            //        case 4:
            //            skilldescribles = 10;
            //            break;
            //        case 5:
            //            skilldescribles = 10;
            //            break;
            //    }

            //    for (int tmp1 = 0; tmp1 < skills; ++tmp1)
            //    {
            //        tmpint = s.IndexOf("技能名=",startid);
            //        tmpend = s.IndexOf("\n", tmpint, 100);
            //        strtmp = s.Substring(tmpint + "技能名=".Length, tmpend - tmpint - "技能名=".Length);
            //        i.skills[tmp1].skillname = strtmp;
            //        tmpint = s.IndexOf("技能类型1=", tmpint);
            //        if (tmpint == -1)
            //            i.skills[tmp1].replykind = null;
            //        else
            //        {
            //            tmpend = s.IndexOf("\n", tmpint, 100);
            //            strtmp = s.Substring(tmpint + "技能类型1=".Length, tmpend - tmpint - "技能类型1=".Length);
            //            i.skills[tmp1].replykind = strtmp;
            //        }
            //        tmpint = s.IndexOf("技能类型2=", startid);
            //        if (tmpint == -1)
            //            i.skills[tmp1].triggerkind = null;
            //        else
            //        {
            //            tmpend = s.IndexOf("\n", tmpint, 100);
            //            strtmp = s.Substring(tmpint + "技能类型2=".Length, tmpend - tmpint - "技能类型2=".Length);
            //            i.skills[tmp1].triggerkind = strtmp;
            //        }
            //        i.skills[tmp1].skillDescrible = new List<SkillDescribleItem>();
            //        for (int tmp2 = 1; tmp2 <= skilldescribles; ++tmp2)
            //        {
            //            SkillDescribleItem tmpitem = new SkillDescribleItem();
            //            socketstr = "技能" + (tmp2 >= 8 ? "专精" : "") + (tmp2 >= 8 ? tmp2 - 7 : tmp2).ToString() + "描述=";
            //            tmpint = s.IndexOf(socketstr, startid);
            //            tmpend = s.IndexOf("\n", tmpint, 1000);
            //            strtmp = s.Substring(tmpint + socketstr.Length, tmpend - tmpint - socketstr.Length);
            //            tmpitem.describle = strtmp;

            //            socketstr = "技能" + (tmp2 >= 8 ? "专精" : "") + (tmp2 >= 8 ? tmp2 - 7 : tmp2).ToString() + "初始=";
            //            tmpint = s.IndexOf(socketstr, startid);
            //            tmpend = s.IndexOf("\n", tmpint, 1000);
            //            if (tmpend - tmpint - socketstr.Length == 0)
            //                tmpitem.start = null;
            //            else
            //            {
            //                strtmp = s.Substring(tmpint + socketstr.Length, tmpend - tmpint - socketstr.Length);
            //                tmpitem.start = int.Parse(strtmp);
            //            }

            //            socketstr = "技能" + (tmp2 >= 8 ? "专精" : "") + (tmp2 >= 8 ? tmp2 - 7 : tmp2).ToString() + "消耗=";
            //            tmpint = s.IndexOf(socketstr, startid);
            //            tmpend = s.IndexOf("\n", tmpint, 1000);
            //            if (tmpend - tmpint - socketstr.Length == 0)
            //                tmpitem.deplete = null;
            //            else
            //            {
            //                strtmp = s.Substring(tmpint + socketstr.Length, tmpend - tmpint - socketstr.Length);
            //                tmpitem.deplete = int.Parse(strtmp);
            //            }

            //            socketstr = "技能" + (tmp2 >= 8 ? "专精" : "") + (tmp2 >= 8 ? tmp2 - 7 : tmp2).ToString() + "持续=";
            //            tmpint = s.IndexOf(socketstr, startid);
            //            tmpend = s.IndexOf("\n", tmpint, 1000);
            //            if (tmpend - tmpint - socketstr.Length == 0)
            //                tmpitem.continued = null;
            //            else
            //            {
            //                strtmp = s.Substring(tmpint + socketstr.Length, tmpend - tmpint - socketstr.Length);
            //                tmpitem.continued = int.Parse(strtmp);
            //            }

            //            i.skills[tmp1].skillDescrible.Add(tmpitem);
            //        }
            //        startid = s.IndexOf("技能名=", s.IndexOf("技能名=", startid) + 10);
            //    }
            //}
            //Tool tool = new Tool();
            //tool.JsonWrite("E:/C#/Arknights_tools/Arknights_tools/Resources/json/character_table.json", GlobalArgs.Chartable);
            //string qzkt = "<meta property=\"og:image\" content=\"";
            //int n, m;
            //string s, result;
            //foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            //{
            //    if (File.Exists("E:/tmp/" + i.PicName[0] + ".png"))
            //        continue;
            //    s = tool.GetHtmlStr("https://prts.wiki/w/%E6%96%87%E4%BB%B6:%E5%A4%B4%E5%83%8F_" + i.name + ".png", "UTF8");
            //    //s = "<meta property=\"og:image\"content=\"http://prts.wiki/images/b/b6/%E5%A4%B4%E5%83%8F_Lancet-2.png\"/>";
            //    for (n = 0; n < s.Length; ++n)
            //    {
            //        for (m = 0; m < qzkt.Length; ++m)
            //        {
            //            if (s[n + m] != qzkt[m])
            //            {
            //                break;
            //            }
            //        }
            //        if (m == qzkt.Length)
            //        {
            //            n += m;
            //            result = "";
            //            while (s[n] != '\"')
            //            {
            //                result += s[n];
            //                ++n;
            //            }
            //            SaveAsWebImg(result, i.PicName[0], "E:/tmp/");
            //            break;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 初始化仓库界面
        /// 从json中读取材料信息并动态生成界面
        /// </summary>
        private void InitStore()
        {
            Tool tool = new Tool();
            int STORE_MAIN_GRID_COLNUM = 8;
            GlobalArgs.Matriels = tool.JsonReader<Matriels_Root>(Directory.GetCurrentDirectory() + "/Resources/json/matriels.json");
            int matrielnum = GlobalArgs.Matriels.Matriels.Compositable.Count();
            GlobalArgs.MatrielMode = new StoreMatrielMode[matrielnum];
            tool.GridCutters(StoreMainGrid,
                                  (matrielnum + STORE_MAIN_GRID_COLNUM - 1) / STORE_MAIN_GRID_COLNUM, STORE_MAIN_GRID_COLNUM,
                                  StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.15);
            string path;
            int now = 0;
            foreach (CompositableItem i in GlobalArgs.Matriels.Matriels.Compositable)
            {
                path = "Resources/image/Materials/" + i.En_Name + ".png";
                DockPanel tmpdock = new DockPanel();
                StoreMainGrid.Children.Add(tmpdock);
                Grid.SetColumn(tmpdock, now % STORE_MAIN_GRID_COLNUM);
                Grid.SetRow(tmpdock, now / STORE_MAIN_GRID_COLNUM);
                GlobalArgs.MatrielMode[now] = new StoreMatrielMode((int)(StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM),
                                                                    (int)(StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.25),
                                                                    i.Num, path, i.Level, tmpdock, now);
                GlobalArgs.MatrielMode[now].SetDownClick(Store.StoreDownClick);
                GlobalArgs.MatrielMode[now].SetUpClick(Store.StoreUpClick);
                GlobalArgs.MatrielMode[now].SetNumChange(Store.StoreNumChange);
                ++now;
            }
        }

        /// <summary>
        /// 初始化干员筛选界面
        /// </summary>
        private void InitCharCheck()
        {
            Tool tool = new Tool();
            GlobalArgs.charinfo_Tapitems = new List<Charinfo_Tapitem>();
            GlobalArgs.Chartable = tool.JsonReader<Root_CharTable>(Directory.GetCurrentDirectory() + "/Resources/json/character_table.json");
            int char_previewcols = 10;
            int char_previewrows = (GlobalArgs.Chartable.char_info.Count + char_previewcols - 1) / char_previewcols;
            double CharPicWidth = Grid_CharPreview.Width / char_previewcols;
            double CharPicHeight = CharPicWidth * 288.8 / 146.4;
            tool.GridCutters(Grid_CharPreview, char_previewrows, char_previewcols, CharPicHeight, CharPicWidth);
            int colnow = 0, rownow = 0;
            for (int sx = GlobalArgs.Chartable.char_info.Count - 1; sx >= 0; --sx)
            {
                Char_infoItem i = GlobalArgs.Chartable.char_info[sx];
                Button newcharButton = new Button { Uid = i.ImplementationOrder.ToString() };
                newcharButton.Click += Click_Char_In_Check;
                Image newcharImage = new Image();
                newcharButton.Content = newcharImage;
                newcharImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/bust/" + i.PicName[0] + ".png"));
                newcharButton.Style = FindResource("char") as Style;
                Grid_CharPreview.Children.Add(newcharButton);
                Grid_CharPreview.RegisterName("CharCheck" + i.ImplementationOrder.ToString(), newcharButton);
                Grid.SetColumn(newcharButton, colnow);
                Grid.SetRow(newcharButton, rownow);
                colnow += 1;
                rownow += colnow / char_previewcols;
                colnow %= char_previewcols;
            }
            GlobalArgs.CheckIdnum = new checkIdnum();
        }

        /// <summary>
        /// 点击干员筛选条件按钮
        /// </summary>
        private void CheckChange(object sender, RoutedEventArgs e)
        {
            Button Sender = sender as Button;
            if (Sender.Background == Brushes.SkyBlue)
            {
                Sender.Background = Brushes.White;
                GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal - (1 << int.Parse(Sender.Uid)));
            }
            else
            {
                Sender.Background = Brushes.SkyBlue;
                GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal + (1 << int.Parse(Sender.Uid)));
            }
            Movecharcard();
        }

        /// <summary>
        /// <para>点击干员筛选界面的干员按钮</para>
        /// <para>会在@Gloargs.charinfo_Tapitems添加一个新的成员</para>
        /// </summary>
        private void Click_Char_In_Check(object sender, RoutedEventArgs e)
        {
            Button tmp_button = sender as Button;
            foreach (Charinfo_Tapitem i in GlobalArgs.charinfo_Tapitems)
            {
                if (i.ImplementationOrder == tmp_button.Uid)
                    return;
            }
            Charinfo_Tapitem newCharinfo = new Charinfo_Tapitem(GlobalArgs.Chartable.char_info[int.Parse(tmp_button.Uid) - 1]);
            newCharinfo.Avatar_Select_Button.Click += Click_Select_Button;
            GlobalArgs.charinfo_Tapitems.Add(newCharinfo);
            Select_Char_Stackpanel.Children.Add(newCharinfo.Avatar_Select_Button);
            Select_Char_Stackpanel.RegisterName("Select_button_" + tmp_button.Uid, newCharinfo.Avatar_Select_Button);
        }

        /// <summary>
        /// 点击干员查看界面左侧干员按钮，右侧显示干员信息
        /// </summary>
        private void Click_Select_Button(object sender, RoutedEventArgs e)
        {
            Button tmp_button = sender as Button;
            foreach (Charinfo_Tapitem i in GlobalArgs.charinfo_Tapitems)
            {
                if (tmp_button.Uid == i.ImplementationOrder)
                {
                    if (i.Skill_DataGrid.RowDefinitions.Count == 0)
                    {
                        Skills_Grid.Opacity = 0;
                        Skills_Grid.IsEnabled = false;
                    }
                    else
                    {
                        Skills_Grid.Opacity = 1;
                        Skills_Grid.IsEnabled = true;
                        Skills_Grid.Children.Clear();
                        Skills_Grid.Children.Add(i.Skill_DataGrid);
                    }
                    Talent_Grid.Children.Clear();
                    Talent_Grid.Children.Add(i.Talent_DataGrid);
                    if (i.Rarity <= 1)
                    {
                        Parse_Matriels_Grid.Opacity = 0;
                        Parse_Matriels_Grid.IsEnabled = false;
                    }
                    else
                    {
                        Parse_Matriels_Grid.Opacity = 1;
                        Parse_Matriels_Grid.IsEnabled = true;
                        Parse_Matriels_Grid.Children.Clear();
                        Parse_Matriels_Grid.Children.Add(i.Parse_Matriels_DataGrid);
                    }
                    Charinfo_Pannel.DataContext = i;
                    return;
                }
            }
        }

        /// <summary>
        /// 点击词缀与或计算复选框
        /// </summary>
        private void andorchange(object sender, RoutedEventArgs e)
        {
            Movecharcard();
        }

        /// <summary>
        /// <para/>根据筛选条件移动卡片
        /// <para/>没有时默认全选
        /// <para/>职业和稀有度有选择时进行每项的或计算
        /// <para/>tag可以选择与或计算
        /// </summary>
        private void Movecharcard()
        {
            int rownow = 0, colnow = 0;
            int char_previewcols = 10;
            int maxrow = (GlobalArgs.Chartable.char_info.Count() + char_previewcols - 1) / char_previewcols;
            for (int sx = GlobalArgs.Chartable.char_info.Count - 1; sx >= 0; --sx)
            {
                Char_infoItem i = GlobalArgs.Chartable.char_info[sx];
                if ((GlobalArgs.CheckIdnum.Profession != 0 && ((i.tagIdnum & GlobalArgs.CheckIdnum.Professional_All) & GlobalArgs.CheckIdnum.Profession) == 0) ||
                    (GlobalArgs.CheckIdnum.Rarity != 0 && ((i.tagIdnum & GlobalArgs.CheckIdnum.Rarity_All) & GlobalArgs.CheckIdnum.Rarity) == 0))
                {
                    Button tmpbutton = FindName("CharCheck" + i.ImplementationOrder.ToString()) as Button;
                    Grid.SetColumn(tmpbutton, char_previewcols - 1);
                    Grid.SetRow(tmpbutton, maxrow - 1);
                    tmpbutton.IsEnabled = false;
                    tmpbutton.Opacity = 0;
                    continue;
                }
                if (GlobalArgs.CheckIdnum.Tag != 0)
                {
                    if (Tag_calculate.IsChecked == true)//tag或运算
                    {
                        if (((i.tagIdnum & GlobalArgs.CheckIdnum.Tag_All) & GlobalArgs.CheckIdnum.Tag) == 0)
                        {
                            Button tmpbutton = FindName("CharCheck" + i.ImplementationOrder.ToString()) as Button;
                            Grid.SetColumn(tmpbutton, char_previewcols - 1);
                            Grid.SetRow(tmpbutton, maxrow - 1);
                            tmpbutton.IsEnabled = false;
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                    else                        //tag与运算
                    {
                        if (((i.tagIdnum & GlobalArgs.CheckIdnum.Tag_All) & GlobalArgs.CheckIdnum.Tag) != GlobalArgs.CheckIdnum.Tag)
                        {
                            Button tmpbutton = FindName("CharCheck" + i.ImplementationOrder.ToString()) as Button;
                            Grid.SetColumn(tmpbutton, char_previewcols - 1);
                            Grid.SetRow(tmpbutton, maxrow - 1);
                            tmpbutton.IsEnabled = false;
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                }
                Button tmp = FindName("CharCheck" + i.ImplementationOrder.ToString()) as Button;
                Grid.SetColumn(tmp, colnow);
                Grid.SetRow(tmp, rownow);
                tmp.IsEnabled = true;
                tmp.Opacity = 1;
                colnow += 1;
                rownow += colnow / Grid_CharPreview.ColumnDefinitions.Count();
                colnow %= Grid_CharPreview.ColumnDefinitions.Count();
            }
            int char_previewrows = rownow + (colnow != 0 ? 1 : 0);
            double CharPicWidth = Grid_CharPreview.Width / char_previewcols;
            double CharPicHeight = CharPicWidth * 288.8 / 146.4;
            Grid_CharPreview.Height = CharPicHeight * char_previewrows;
        }

        /// <summary>
        /// 全选和清空tag按钮
        /// </summary>
        private void Check_all_cal(object sender, RoutedEventArgs e)
        {
            Button tmp = sender as Button;
            Button buttmp;
            switch (tmp.Name)
            {
                case "professonal_all"://职业全选
                    for (int i = 0; i < 8; ++i)
                    {
                        buttmp = FindName("check_professonal_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.SkyBlue;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal | 0b11111111);
                    break;
                case "professonal_cal"://职业清空
                    for (int i = 0; i < 8; ++i)
                    {
                        buttmp = FindName("check_professonal_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.White;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal - GlobalArgs.CheckIdnum.Profession);
                    break;
                case "rarity_all"://稀有度全选
                    for (int i = 0; i < 6; ++i)
                    {
                        buttmp = FindName("check_rarity_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.SkyBlue;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal | 0b11111100000000);
                    break;
                case "rarity_cal"://稀有度清空
                    for (int i = 0; i < 6; ++i)
                    {
                        buttmp = FindName("check_rarity_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.White;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal - GlobalArgs.CheckIdnum.Rarity);
                    break;
                case "tag_all"://tag全选
                    for (int i = 0; i < 16; ++i)
                    {
                        buttmp = FindName("check_tag_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.SkyBlue;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal | 0b111111111111111100000000000000);
                    break;
                case "tag_cal"://tag清空
                    for (int i = 0; i < 16; ++i)
                    {
                        buttmp = FindName("check_tag_" + i.ToString()) as Button;
                        buttmp.Background = Brushes.White;
                    }
                    GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal - GlobalArgs.CheckIdnum.Tag);
                    break;
            }
            Movecharcard();
        }

        /// <summary>
        /// 窗口关闭事件触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Tool tool = new Tool();
            tool.JsonWrite(Directory.GetCurrentDirectory() + "/Resources/json/matriels.json", GlobalArgs.Matriels);
        }
    }
}