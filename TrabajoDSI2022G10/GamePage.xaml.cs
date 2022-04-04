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
     
            flyout.Items.Add(newitem("Juego_Alcohol.png","250","Alcohol"));
            flyout.Items.Add(newitem("Juego_Gel.png", "200", "Gel"));
            flyout.Items.Add(newitem("Juego_Jabon.png", "100", "Jabon"));
            flyout.Items.Add(newitem("Juego_Mascarillas.png", "150", "Mascarillas"));
            flyout.Items.Add(newitem("Juego_Paracetamol.png", "500", "Paracetamol"));
            flyout.Items.Add(newitem("Juego_UV.png", "200", "UV"));
            flyout.Items.Add(newitem("Juego_Cuadro.png", "", "Reset"));
            sel.Flyout = flyout;
        }
        MenuFlyoutItem newitem(string path,string price ,string name)
        {
            MenuFlyoutItem item = new MenuFlyoutItem();
            item.Text = name + " " +price;
            var bmi = new BitmapIcon();
            string url = "ms-appx:///Assets/"+path;
            bmi.UriSource = new Uri(url);
            bmi.ShowAsMonochrome = false;
            item.Icon = bmi;
            item.Click += (s, e1) =>
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(url));
                sel.Content = img;

            };
            return item;
        }
        private void PauseB_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Objects_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AgainButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
