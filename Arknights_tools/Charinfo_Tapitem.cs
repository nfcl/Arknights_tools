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

namespace MVVM
{
    /// <summary>
    /// 用于储存人物展示的数据和UI进行绑定
    /// </summary>
    public class Charinfo_Tapitem : INotifyPropertyChanged
    {
        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion



        private string _special;



        private Basic_Info _basic_info;
        private Professional _professional;



        /// <summary>
        /// 特性描述
        /// </summary>
        public string Special { get { return _special; } set { _special = value; } }
        


        /// <summary>
        /// 稀有度（为实际稀有度 - 1）
        /// </summary>
        public int Rarity => _basic_info.Rarity;
        /// <summary>
        /// 干员序号
        /// </summary>
        public int Implementation_Order => _basic_info.Implementation_Order;
        /// <summary>
        /// 中文名
        /// </summary>
        public string Name_Ch => _basic_info.Name_Ch;
        /// <summary>
        /// 外文名
        /// </summary>
        public string Name_En => _basic_info.Name_En;
        /// <summary>
        /// 职业分支（中文）
        /// </summary>
        public string Professional_Ch => _professional.Main_Ch;
        /// <summary>
        /// 职业分支（英文）
        /// </summary>
        public string Professional_En => _professional.Main_En;
        /// <summary>
        /// 职业分支图标
        /// </summary>
        public BitmapImage Professional_Icon => _professional.Sub_Icon;
        /// <summary>
        /// 站位（近战位|远程位）
        /// </summary>
        public string Position => _basic_info.Position;



        public Charinfo_Tapitem(Char_infoItem Original)
        {
            _basic_info = new Basic_Info()
            {
                Name_Ch = Original.name,
                Name_En = Original.appellation,
                Rarity = Original.rarity,
                Implementation_Order = Original.ImplementationOrder,
                Position = Original.position
            };
            _professional = new Professional()
            {
                Main_Ch = Original.Profession_Ch,
                Main_En = Original.Profession_En,
                Sub_Ch = Original.SubProfessionId_Ch,
                Sub_En = Original.SubProfessionId_En
            };
        }



        public class Skin
        {

        }



        public class Skill
        {

        }



        public class Talent
        {

        }



        public class Basic_Info
        {
            public int Rarity { get; set; }
            public string Name_Ch { get; set; }
            public string Name_En { get; set; }
            public string Position { get; set; }
            public int Implementation_Order { get; set; }
        }



        public class Professional
        {
            public string Main_Ch { get; set; }
            public string Main_En { get; set; }
            public string Sub_Ch { get; set; }
            public string Sub_En { get; set; }

            public BitmapImage Main_Icon => new BitmapImage(new Uri("pack://application:,,,/Resources/image/Optbch/" + Sub_En + ".png"));
            public BitmapImage Sub_Icon => new BitmapImage(new Uri("pack://application:,,,/Resources/image/Optbch/" + Sub_En + ".png"));
        }



        public class MatrielsCost
        {
            public string Name_Ch { get; set; }
            public string Name_En { get; set; }
            public int Count { get; set; }

            public BitmapImage Icon => new BitmapImage(new Uri("pack://application:,,,/Resources/image/Materials/" + Name_En + ".png"));
        }
    }
}
