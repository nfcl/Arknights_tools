using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LitJson;
using json_real;
using ClassSum;
using InitFunction;
using tool;
using System.Windows.Controls.Primitives;
using HandlebarsDotNet.StringUtils;
using System.ComponentModel;
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
            //DirectoryInfo mian = new DirectoryInfo("C:/Users/煖風遲來/Desktop/1/charpic/skin/Texture2D");
            //FileSystemInfo[] fsinfos = mian.GetFileSystemInfos();
            //string s = "[alpha].png";

            //foreach (FileSystemInfo fsinfo in fsinfos)
            //{
            //    File.Move(fsinfo.FullName, "C:/Users/煖風遲來/Desktop/1/charpic/skin/mian/" + fsinfo.Name.Substring(0, fsinfo.Name.Length - 5) + ".png");
            //}

            //string alphadicpath = "C:/Users/煖風遲來/Desktop/1/charpic/skin/alpha/";
            //string resultpath = "C:/Users/煖風遲來/Desktop/1/charpic/skin/Texture2D/";
            //DirectoryInfo mian = new DirectoryInfo("C:/Users/煖風遲來/Desktop/1/charpic/skin/mian/");
            //FileSystemInfo[] fsinfos = mian.GetFileSystemInfos();

            //foreach (FileSystemInfo fsinfo in fsinfos)
            //{
            //    if (fsinfo.Name == ".png" || File.Exists(resultpath + fsinfo.Name)) continue;
            //    System.Drawing.Bitmap alpha = new System.Drawing.Bitmap(alphadicpath + fsinfo.Name);
            //    System.Drawing.Bitmap real = new System.Drawing.Bitmap(fsinfo.FullName);
            //    for (int j = 0; j < real.Height; ++j)
            //    {
            //        for (int i = 0; i < real.Width; ++i)
            //        {
            //            real.SetPixel(j, i, System.Drawing.Color.FromArgb(alpha.GetPixel(j, i).R, real.GetPixel(j, i).R, real.GetPixel(j, i).G, real.GetPixel(j, i).B));
            //        }
            //    }
            //    real.Save(resultpath + fsinfo.Name, System.Drawing.Imaging.ImageFormat.Png);
            //}
            //Charinfo_Tapitem amiya = new Charinfo_Tapitem(54, Navigation_bar);
            //Navigation_bar.Items.Add(amiya.Main_Content);
            //Dictionary<string, string> Professional = new Dictionary<string, string>()
            //{
            //    {"PIONEER","先锋" },{"WARRIOR","近卫" },{"TANK","重装" },{"SNIPER","狙击" },
            //    {"CASTER","术士" },{"MEDIC","医疗" },{"SUPPORT","辅助" },{"SPECIAL","特种" },
            //};//先锋 近卫 重装 狙击 术士 医疗 辅助 特种
            //Dictionary<string, string> sub_professional = new Dictionary<string, string>()
            //{
            //    {"charger","冲锋手" },{"pioneer","尖兵" },{"tactician","战术家" },{"bearer","执旗手" },
            //    {"fighter","斗士" },{"sword","剑豪" },{"instructor","教官" },{"librator","解放者" },
            //    {"lord","领主" },{"centurion","强攻手" },{"reaper","收割者" },{"artsfghter","术战者" },
            //    {"fearless","无畏者" },{"musha","武者" },{"unyield","不屈者" },{"duelist","决战者" },
            //    {"guardian","守护者" },{"protector","铁卫" },{"fortress","要塞" },{"artsprotector","驭法铁卫" },
            //    {"siegesniper","攻城手" },{"aoesniper","炮手" },{"reaperrange","散射手" },{"longrange","神射手" },
            //    {"fastshot","速射手" },{"bombarder","投掷手" },{"closerange","重射手" },{"blastcaster","轰击术师" },
            //    {"splashcaster","扩散术师" },{"chain","链术师" },{"mystic","秘术师" },{"funnel","驭械术师" },
            //    {"phalanx","阵法术师" },{"corecaster","中坚术师" },{"wandermedic","行医" },{"healer","疗养师" },
            //    {"ringhealer","群愈师" },{"physician","医师" },{"craftsman","工匠" },{"blessing","护佑者" },
            //    {"slower","凝滞师" },{"underminer","削弱者" },{"bard","吟游者" },{"summoner","召唤师" },
            //    {"executor","处决者" },{"stalker","伏击客" },{"hookmaster","钩索师" },{"geek","怪杰" },
            //    {"dollkeeper","傀儡师" },{"merchant","行商" },{"pusher","推击手" },{"traper","陷阱师" },
            //};
            //foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            //{
            //    i.Profession_Ch = Professional[i.Profession_En];
            //    i.SubProfessionId_Ch = sub_professional[i.SubProfessionId_En];
            //}
            //amiya 54
            //Navigation_bar.DataContext = GlobalArgs.Charinfo_tapItem;
            //Navigation_bar.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());
            //GlobalArgs.Charinfo_tapItem = new System.Collections.ObjectModel.ObservableCollection<Charinfo_Tapitem>();

            //Charinfo_Tapitem testDataItem = new Charinfo_Tapitem();
            //testDataItem.Ch_name = GlobalArgs.Chartable.char_info[54].name;
            //testDataItem.En_name = GlobalArgs.Chartable.char_info[54].appellation;
            //testDataItem.rarity  = GlobalArgs.Chartable.char_info[54].rarity;
            //GlobalArgs.Charinfo_tapItem.Add(testDataItem);
            //Navigation_bar.SelectedIndex = GlobalArgs.Charinfo_tapItem.Count;
            //string qzkt = "<meta property=\"og:image\" content=\"";
            //int n, m;
            //string s, result;
            //foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            //{
            //    if (File.Exists("E:/tmp/" + i.PicName[0] + ".png"))
            //        continue;
            //    s = GetHtmlStr("https://prts.wiki/w/%E6%96%87%E4%BB%B6:%E5%A4%B4%E5%83%8F_" + i.name + ".png", "UTF8");
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
        /// 获取网页的HTML码
        /// </summary>
        /// <param name="url">链接地址</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string GetHtmlStr(string url, string encoding)
        {
            string htmlStr = "";
            if (!String.IsNullOrEmpty(url))
            {
                WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象
                WebResponse response = request.GetResponse();           //创建WebResponse对象
                Stream datastream = response.GetResponseStream();       //创建流对象
                Encoding ec = Encoding.Default;
                if (encoding == "UTF8")
                {
                    ec = Encoding.UTF8;
                }
                else if (encoding == "Default")
                {
                    ec = Encoding.Default;
                }
                StreamReader reader = new StreamReader(datastream, ec);
                htmlStr = reader.ReadToEnd();                           //读取数据
                reader.Close();
                datastream.Close();
                response.Close();
            }
            return htmlStr;
        }

        /// <summary>
        /// 下载网站图片
        /// </summary>
        /// <param name="picUrl"></param>
        /// <returns></returns>
        public void SaveAsWebImg(string picUrl, string picname, string filepath)
        {
            try
            {
                if (!String.IsNullOrEmpty(picUrl))
                {
                    Random rd = new Random();
                    DateTime nowTime = DateTime.Now;
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(picUrl, filepath + picname + ".png");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 以流读入bitmapimage
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        BitmapImage bmpRead(string path)
        {
            // Read byte[] from png file
            BinaryReader binReader = new BinaryReader(File.Open(path, FileMode.Open));
            FileInfo fileInfo = new FileInfo(path);
            byte[] bytes = binReader.ReadBytes((int)fileInfo.Length);
            binReader.Close();

            // Init bitmap
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(bytes);
            bitmap.EndInit();
            return bitmap;
        }

        /// <summary>
        /// 初始化仓库界面
        /// 从json中读取材料信息并动态生成界面
        /// </summary>
        private void InitStore()
        {
            Tool tool = new Tool();
            int STORE_MAIN_GRID_COLNUM = 8;
            GlobalArgs.MatrielsMakble = tool.JsonReader<Matriels_Root>(Directory.GetCurrentDirectory() + "/Resources/json/matriels.json");
            int matrielnum = GlobalArgs.MatrielsMakble.Matriels.Compositable.Count();
            GlobalArgs.MatrielMode = new StoreMatrielMode[matrielnum];
            tool.GridCutters(StoreMainGrid,
                                  (matrielnum + STORE_MAIN_GRID_COLNUM - 1) / STORE_MAIN_GRID_COLNUM, STORE_MAIN_GRID_COLNUM,
                                  StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.15);
            string path;
            int now = 0;
            foreach (CompositableItem i in GlobalArgs.MatrielsMakble.Matriels.Compositable)
            {
                path = "Resources/image/Materials/Compositable/" + i.Level.ToString() + "_" + i.En_Name + ".png";
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
            int char_previewrows = (GlobalArgs.Chartable.char_info.Count() + char_previewcols - 1) / char_previewcols;
            double CharPicWidth = Grid_CharPreview.Width / char_previewcols;
            double CharPicHeight = CharPicWidth * 288.8 / 146.4;
            tool.GridCutters(Grid_CharPreview, char_previewrows, char_previewcols, CharPicHeight, CharPicWidth);
            int colnow = 0, rownow = 0;
            for (int sx = GlobalArgs.Chartable.char_info.Count - 1; sx >= 0; --sx)
            {
                Char_infoItem i = GlobalArgs.Chartable.char_info[sx];
                Button newcharButton = new Button();
                newcharButton.Uid = i.ImplementationOrder.ToString();
                newcharButton.Click += Click_Char_In_Check;
                Image newcharImage = new Image();
                newcharButton.Content = newcharImage;
                newcharImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/image/char/bust/" + i.PicName[0] + ".png"));
                newcharButton.Style = FindResource("char") as Style;
                Grid_CharPreview.RegisterName("char" + i.ImplementationOrder.ToString(), newcharButton);
                Grid_CharPreview.Children.Add(newcharButton);
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

        private void Click_Select_Button(object sender, RoutedEventArgs e)
        {
            Button tmp_button = sender as Button;
            foreach (Charinfo_Tapitem i in GlobalArgs.charinfo_Tapitems)
            {
                if (tmp_button == i.Avatar_Select_Button)
                {
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
                if (GlobalArgs.CheckIdnum.Profession != 0 && ((i.tagIdnum & 0b000000000000000000000011111111) & GlobalArgs.CheckIdnum.Profession) == 0)
                {
                    Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                    Grid.SetColumn(tmpbutton, char_previewcols - 1);
                    Grid.SetRow(tmpbutton, maxrow - 1);
                    tmpbutton.IsEnabled = false;
                    tmpbutton.Opacity = 0;
                    continue;
                }
                if (GlobalArgs.CheckIdnum.Rarity != 0 && ((i.tagIdnum & 0b000000000000000011111100000000) & GlobalArgs.CheckIdnum.Rarity) == 0)
                {
                    Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                    Grid.SetColumn(tmpbutton, char_previewcols - 1);
                    Grid.SetRow(tmpbutton, maxrow - 1);
                    tmpbutton.IsEnabled = false;
                    tmpbutton.Opacity = 0;
                    continue;
                }
                if (GlobalArgs.CheckIdnum.Tag != 0)
                {
                    if (andor.IsChecked == true)//tag或运算
                    {
                        if (((i.tagIdnum & 0b111111111111111100000000000000) & GlobalArgs.CheckIdnum.Tag) == 0)
                        {
                            Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                            Grid.SetColumn(tmpbutton, char_previewcols - 1);
                            Grid.SetRow(tmpbutton, maxrow - 1);
                            tmpbutton.IsEnabled = false;
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                    else                        //tag与运算
                    {
                        if (((i.tagIdnum & 0b111111111111111100000000000000) & GlobalArgs.CheckIdnum.Tag) != GlobalArgs.CheckIdnum.Tag)
                        {
                            Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                            Grid.SetColumn(tmpbutton, char_previewcols - 1);
                            Grid.SetRow(tmpbutton, maxrow - 1);
                            tmpbutton.IsEnabled = false;
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                }
                Button tmp = FindName("char" + i.ImplementationOrder.ToString()) as Button;
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
            tool.JsonWrite(Directory.GetCurrentDirectory() + "/Resources/json/matriels.json", GlobalArgs.MatrielsMakble);
        }
    }
}