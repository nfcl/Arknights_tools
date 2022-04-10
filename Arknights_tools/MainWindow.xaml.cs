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

namespace Arknights_tools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitStore();
            InitCharCheck();
        }

        private void jsonceshi()
        {
            Dictionary<string, int> professionToint = new Dictionary<string, int>()
            {
                { "PIONEER",0b00000001 } ,
                { "WARRIOR",0b00000010 } ,
                { "TANK",   0b00000100 } ,
                { "SNIPER", 0b00001000 } ,
                { "CASTER", 0b00010000 } ,
                { "MEDIC",  0b00100000 } ,
                { "SUPPORT",0b01000000 } ,
                { "SPECIAL",0b10000000 } ,
            };
            Dictionary<int, int> rarityToint = new Dictionary<int, int>()
            {
                {0,0b00000100000000 },
                {1,0b00001000000000 },
                {2,0b00010000000000 },
                {3,0b00100000000000 },
                {4,0b01000000000000 },
                {5,0b10000000000000 },
            };
            Dictionary<string, int> tagToint = new Dictionary<string, int>()
            {
                {"新手",     0b000000000000000100000000000000},
                {"治疗",     0b000000000000001000000000000000},
                {"支援",     0b000000000000010000000000000000},
                {"输出",     0b000000000000100000000000000000},
                {"群攻",     0b000000000001000000000000000000},
                {"减速",     0b000000000010000000000000000000},
                {"生存",     0b000000000100000000000000000000},
                {"防护",     0b000000001000000000000000000000},
                {"削弱",     0b000000010000000000000000000000},
                {"位移",     0b000000100000000000000000000000},
                {"控场",     0b000001000000000000000000000000},
                {"爆发",     0b000010000000000000000000000000},
                {"召唤",     0b000100000000000000000000000000},
                {"快速复活", 0b001000000000000000000000000000},
                {"费用回复", 0b010000000000000000000000000000},
                {"支援机械", 0b100000000000000000000000000000},
            };
            foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            {
                i.tagIdnum = professionToint[i.profession] + rarityToint[i.rarity];
                foreach (string j in i.tagList)
                {
                    i.tagIdnum += tagToint[j];
                }
            }
            JsonWrite(Directory.GetCurrentDirectory() + "/json/character_table.json", GlobalArgs.Chartable);
        }

        /// <summary>
        /// 初始化仓库界面
        /// 从json中读取材料信息并动态生成界面
        /// </summary>
        private void InitStore()
        {
            int STORE_MAIN_GRID_COLNUM = 8;
            GlobalArgs.MatrielsMakble = JsonReader<Matriels_Root>(Directory.GetCurrentDirectory() + "/json/matriels.json");
            int matrielnum = GlobalArgs.MatrielsMakble.Matriels.Makable.Count();
            GlobalArgs.MatrielMode = new StoreMatrielMode[matrielnum];
            Grid_tool grid_Tool = new Grid_tool();
            grid_Tool.GridCutters(StoreMainGrid,
                                  (matrielnum + STORE_MAIN_GRID_COLNUM - 1) / STORE_MAIN_GRID_COLNUM, STORE_MAIN_GRID_COLNUM,
                                  StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.15);
            string path;
            int now = 0;
            foreach (MakableItem i in GlobalArgs.MatrielsMakble.Matriels.Makable)
            {
                path = Directory.GetCurrentDirectory() + "/Image/MakableMaterials/" + i.Level.ToString() + "_" + i.Name + ".png";
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

        private void InitCharCheck()
        {
            GlobalArgs.Chartable = JsonReader<Root_CharTable>(Directory.GetCurrentDirectory() + "/json/character_table.json");
            int char_previewcols = 10;
            int char_previewrows = (GlobalArgs.Chartable.char_info.Count() + char_previewcols - 1) / char_previewcols;
            double CharPicWidth = Grid_CharPreview.Width / char_previewcols;
            double CharPicHeight = CharPicWidth * 288.8 / 146.4;
            Grid_tool grid_Tool = new Grid_tool();
            grid_Tool.GridCutters(Grid_CharPreview, char_previewrows, char_previewcols, CharPicHeight, CharPicWidth);
            int colnow = 0, rownow = 0;
            foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            {
                Button newcharButton = new Button();
                Image newcharImage = new Image();
                newcharButton.Content = newcharImage;
                newcharImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/char/" + i.PicName[0] + ".png"));
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckChange(object sender, RoutedEventArgs e)
        {
            Button Sender = sender as Button;
            if (Sender.Background == Brushes.SkyBlue)
            {
                Sender.Background = Brushes.White;
                GlobalArgs.CheckIdnum.Origanal -= (1 << int.Parse(Sender.Uid));
                GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal);
            }
            else
            {
                Sender.Background = Brushes.SkyBlue;
                GlobalArgs.CheckIdnum.Origanal += (1 << int.Parse(Sender.Uid));
                GlobalArgs.CheckIdnum.setOriganal(GlobalArgs.CheckIdnum.Origanal);
            }
            int rownow = 0, colnow = 0;
            foreach (Char_infoItem i in GlobalArgs.Chartable.char_info)
            {
                if (GlobalArgs.CheckIdnum.Profession != 0 && ((i.tagIdnum & 0b000000000000000000000011111111) & GlobalArgs.CheckIdnum.Profession) == 0)
                {
                    Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                    Grid.SetColumn(tmpbutton, 0);
                    Grid.SetRow(tmpbutton, 0);
                    tmpbutton.Opacity = 0;
                    continue;
                }
                if (GlobalArgs.CheckIdnum.Rarity != 0 && ((i.tagIdnum & 0b000000000000000011111100000000) & GlobalArgs.CheckIdnum.Rarity) == 0)
                {
                    Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                    Grid.SetColumn(tmpbutton, 0);
                    Grid.SetRow(tmpbutton, 0);
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
                            Grid.SetColumn(tmpbutton, 0);
                            Grid.SetRow(tmpbutton, 0);
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                    else                        //tag与运算
                    {
                        if (((i.tagIdnum & 0b111111111111111100000000000000) & GlobalArgs.CheckIdnum.Tag) != GlobalArgs.CheckIdnum.Tag)
                        {
                            Button tmpbutton = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                            Grid.SetColumn(tmpbutton, 0);
                            Grid.SetRow(tmpbutton, 0);
                            tmpbutton.Opacity = 0;
                            continue;
                        }
                    }
                }
                Button tmp = FindName("char" + i.ImplementationOrder.ToString()) as Button;
                Grid.SetColumn(tmp, colnow);
                Grid.SetRow(tmp, rownow);
                tmp.Opacity = 1;
                colnow += 1;
                rownow += colnow / Grid_CharPreview.ColumnDefinitions.Count();
                colnow %= Grid_CharPreview.ColumnDefinitions.Count();
            }
        }

        /// <summary>
        /// 将jsonobject转换为json字符串并写入到path位置的json文件
        /// </summary>
        /// <param name="path">写入的json文件地址</param>
        /// <param name="jsonobject">需要保存的json对象</param>
        private void JsonWrite(string path, object jsonobject)
        {
            string jsonstr = JsonMapper.ToJson(jsonobject);
            jsonstr = Regex.Unescape(jsonstr);
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(jsonstr);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 将path位置的json文件读取为json字符串并转换为json对象
        /// </summary>
        /// <param name="path">读入的json文件地址</param>
        private T JsonReader<T>(string path)
        {
            StreamReader streamReader = new StreamReader(path, Encoding.Default);
            JsonReader js = new JsonReader(streamReader);
            T result = JsonMapper.ToObject<T>(js);
            js.Close();
            streamReader.Close();
            return result;
        }

        /// <summary>
        /// 窗口关闭事件触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            JsonWrite(Directory.GetCurrentDirectory() + "/json/matriels.json", GlobalArgs.MatrielsMakble);
        }

    }
}