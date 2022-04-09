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

        /// <summary>
        /// 初始化仓库界面
        /// 从json中读取材料信息并动态生成界面
        /// </summary>
        public void InitStore()
        {
            int STORE_MAIN_GRID_COLNUM = 8;
            GloabalArgs.MatrielsMakble = JsonReader<Matriels_Root>("json/matriels.json");
            int matrielnum = GloabalArgs.MatrielsMakble.Matriels.Makable.Count();
            GloabalArgs.MatrielMode = new StoreMatrielMode[matrielnum];
            Grid_tool grid_Tool = new Grid_tool();
            grid_Tool.GridCutters(StoreMainGrid,
                                  (matrielnum + STORE_MAIN_GRID_COLNUM - 1) / STORE_MAIN_GRID_COLNUM, STORE_MAIN_GRID_COLNUM,
                                  (int)(StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.15));
            string path;
            int now = 0;
            foreach (MakableItem i in GloabalArgs.MatrielsMakble.Matriels.Makable)
            {
                path = System.Environment.CurrentDirectory + "\\Image\\MakableMaterials\\" + i.Level.ToString() + "_" + i.Name + ".png";
                DockPanel tmpdock = new DockPanel();
                StoreMainGrid.Children.Add(tmpdock);
                Grid.SetColumn(tmpdock, now % STORE_MAIN_GRID_COLNUM);
                Grid.SetRow(tmpdock, now / STORE_MAIN_GRID_COLNUM);
                GloabalArgs.MatrielMode[now] = new StoreMatrielMode((int)(StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM),
                                                                    (int)(StoreMainGrid.Width / STORE_MAIN_GRID_COLNUM * 1.25),
                                                                    i.Num, path, i.Level, tmpdock, now);
                GloabalArgs.MatrielMode[now].SetDownClick(Store.StoreDownClick);
                GloabalArgs.MatrielMode[now].SetUpClick(Store.StoreUpClick);
                GloabalArgs.MatrielMode[now].SetNumChange(Store.StoreNumChange);
                ++now;
            }
        }

        public void InitCharCheck()
        {

        }

        /// <summary>
        /// 点击干员筛选条件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckChange(object sender, RoutedEventArgs e)
        {
            Button Sender = sender as Button;
            Sender.Background = Sender.Background == Brushes.SkyBlue ? Brushes.White : Brushes.SkyBlue;
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
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/" + path);
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
            JsonWrite("json/matriels.json", GloabalArgs.MatrielsMakble);
        }

    }
}