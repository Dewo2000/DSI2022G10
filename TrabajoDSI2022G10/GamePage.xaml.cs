using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabajoDSI2022G10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        Button sel;
        public GamePage()
        {
            this.InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sel = sender as Button;
            MenuFlyout flyout = new MenuFlyout();
            MenuFlyoutItem item = new MenuFlyoutItem();
            item.Text = "Off";
            var bmi = new BitmapIcon();
            bmi.UriSource = new Uri("ms-appx:///Assets/Boton_Quit.png");
            bmi.ShowAsMonochrome = false;
            item.Icon = bmi;
            item.Click += (s, e1) =>
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Boton_Quit.png"));
                sel.Content = img;

            };

            flyout.Items.Add(item);
            sel.Flyout = flyout;
        }    
    }
}
