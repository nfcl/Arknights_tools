using System;
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

namespace tool
{
    public class Grid_tool
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
        public void GridCutters(Grid GoalGrid, int row, int col,int height = 0,int width = 0)
        {
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

    }
}
