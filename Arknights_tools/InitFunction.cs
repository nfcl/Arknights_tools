using System.Windows;
using System.Windows.Controls;
using ClassSum;

namespace InitFunction
{
    public class Store
    {
        public static void StoreDownClick(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            try
            {
                GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num--;
            }
            catch
            {
                GloabalArgs.MatrielMode[int.Parse(but.Uid)].Num.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num.ToString();
            }
            finally
            {
                GloabalArgs.MatrielMode[int.Parse(but.Uid)].Num.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num.ToString();
            }
        }

        public static void StoreUpClick(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            try
            {
                GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num++;
            }
            catch
            {
                GloabalArgs.MatrielMode[int.Parse(but.Uid)].Num.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num.ToString();
            }
            finally
            {
                GloabalArgs.MatrielMode[int.Parse(but.Uid)].Num.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(but.Uid)].Num.ToString();
            }
        }

        public static void StoreNumChange(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            try
            {
                GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(txt.Uid)].Num = int.Parse(txt.Text);
            }
            catch
            {
                txt.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(txt.Uid)].Num.ToString();
            }
            finally
            {
                txt.Text = GloabalArgs.MatrielsMakble.Matriels.Makable[int.Parse(txt.Uid)].Num.ToString();
            }
        }
    }
}
