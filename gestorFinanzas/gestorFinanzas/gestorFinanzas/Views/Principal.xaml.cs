using gestorFinanzas.Views;
using System;
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
using System.Windows.Shapes;

namespace gestorFinanzas.views
{
  
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

            private void Hamburguesa_Click(object sender, RoutedEventArgs e)
            {
                if (MenuPanel.Visibility == Visibility.Visible)
                {
                    MenuPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MenuPanel.Visibility = Visibility.Visible;
                }


            }


        private void BtnAhorro_Click(object sender, RoutedEventArgs e)
        {
            Ahorro ahorroWindow = new Ahorro();
            ahorroWindow.Show();
            ahorroWindow.Show();
            this.Close();

          
        }

       
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConversionView conversionView = new ConversionView();
            conversionView.Show();
            conversionView.Show();
            this.Close();
        }
    }
}
