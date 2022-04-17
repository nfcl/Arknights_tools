﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace tool
{
    public class Tool
    {
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
        public void GridCutters(Grid GoalGrid, int row, int col,double height = 0,double width = 0)
        {
            GoalGrid.RowDefinitions.Clear();
            GoalGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < row; i++)
                if (height == 0)
                    GoalGrid.RowDefinitions.Add(new RowDefinition());
                else
                    GoalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height) });
            for (int i = 0; i < col; i++)
                if (width == 0)
                    GoalGrid.ColumnDefinitions.Add(new ColumnDefinition());
                else
                    GoalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width) });
            if (height != 0)
                GoalGrid.Height = height * row;
            if (width != 0)
                GoalGrid.Width = width * col;
        }

        /// <summary>
        /// 干员筛选条件码制作
        /// </summary>
        public void SelectionId_Made()
        {
            Dictionary<string, int> professionToint = new Dictionary<string, int>()
            {
                { "PIONEER",0 } ,{ "WARRIOR",1 } ,{ "TANK",   2 } ,{ "SNIPER", 3 } ,
                { "CASTER", 4 } ,{ "MEDIC",  5 } ,{ "SUPPORT",6 } ,{ "SPECIAL",7 }
            };
            Dictionary<int, int> rarityToint = new Dictionary<int, int>()
            {
                {0,0 },{1,1 },{2,2 },
                {3,3 },{4,4 },{5,5 },
            };
            Dictionary<string, int> tagToint = new Dictionary<string, int>()
            {
                {"新手",     0}, {"治疗",     1}, {"支援",     2}, {"输出",     3},
                {"群攻",     4}, {"减速",     5}, {"生存",     6}, {"防护",     7},
                {"削弱",     8}, {"位移",     9}, {"控场",     10},{"爆发",     11},
                {"召唤",     12},{"快速复活", 13},{"费用回复", 14}
            };
            int num;
            foreach (json_real.Char_infoItem i in ClassSum.GlobalArgs.Chartable.char_info)
            {
                num = 0;
                i.tagIdnum = 1 << professionToint[i.Profession_En];
                num += professionToint.Count;
                i.tagIdnum += 1 << (num + rarityToint[i.rarity]);
                num += rarityToint.Count;
                foreach (string j in i.tagList)
                {
                    i.tagIdnum += 1 << (num + tagToint[j]);
                }
            }
            JsonWrite(Directory.GetCurrentDirectory() + "/json/character_table.json", ClassSum.GlobalArgs.Chartable);
        }

        /// <summary>
        /// 将jsonobject转换为json字符串并写入到path位置的json文件
        /// </summary>
        /// <param name="path">写入的json文件地址</param>
        /// <param name="jsonobject">需要保存的json对象</param>
        public void JsonWrite(string path, object jsonobject)
        {
            string jsonstr = JsonMapper.ToJson(jsonobject);
            jsonstr = System.Text.RegularExpressions.Regex.Unescape(jsonstr);
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(jsonstr);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 将path位置的json文件读取为json字符串并转换为json对象
        /// </summary>
        /// <param name="path">读入的json文件地址</param>
        public T JsonReader<T>(string path)
        {
            StreamReader streamReader = new StreamReader(path, Encoding.Default);
            JsonReader js = new JsonReader(streamReader);
            T result = JsonMapper.ToObject<T>(js);
            js.Close();
            streamReader.Close();
            return result;
        }

    }

}
