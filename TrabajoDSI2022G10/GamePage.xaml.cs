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
using System.ComponentModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabajoDSI2022G10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page, INotifyPropertyChanged
    {
        Button sel;
        Button object2buy;
        //int ice=0, bomb=0, shield, vaccine, wind;
        //private DispatcherTimer _btimer,_itimer,_stimer,_vtimer,_wtimer;
        public GamePage()
        {
            this.InitializeComponent();
            //_btimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            //_itimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            //_stimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            //_vtimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            //_wtimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

            //_btimer.Tick += (sender, o) =>
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bomb)));
            //_itimer.Tick += (sender, o) =>
            //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ice)));
            //_stimer.Tick += (sender, o) =>
            //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(shield)));
            //_vtimer.Tick += (sender, o) =>
            //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(vaccine)));
            //_wtimer.Tick += (sender, o) =>
            //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(wind)));

            //_btimer.Start();
            //_itimer.Start();
            //_stimer.Start();
            //_vtimer.Start();
            //_wtimer.Start();

        }

        public event PropertyChangedEventHandler PropertyChanged;
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
            PausePanel.Visibility = Visibility.Visible;
        }
        private void Objects_Click(object sender, RoutedEventArgs e)
        {
            object2buy = sender as Button;
            switch (object2buy.Name)
            {
                case "Bomb":
                    Ctxt.Text = "QUIERES GASTAR 150 MONEDAS PARA COMPRAR BOMBA";
                    break;
                case "Ice":
                    Ctxt.Text = "QUIERES GASTAR 100 MONEDAS PARA COMPRAR HIELO";
                    break;
                case "Vaccine":
                    Ctxt.Text = "QUIERES GASTAR 100 MONEDAS PARA COMPRAR VACUNA";
                    break;
                case "Wind":
                    Ctxt.Text = "QUIERES GASTAR 80 MONEDAS PARA COMPRAR VIENTO";
                    break;
                case "Shield":
                    Ctxt.Text = "QUIERES GASTAR 120 MONEDAS PARA COMPRAR ESCUDO";
                    break;
            }
            BuyPanel.Visibility = Visibility.Visible;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AgainButton_Click(object sender, RoutedEventArgs e)
        {
            PausePanel.Visibility = Visibility.Collapsed;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            PausePanel.Visibility = Visibility.Collapsed;
        }

        private void BuyBack_Click(object sender, RoutedEventArgs e)
        {
            BuyPanel.Visibility = Visibility.Collapsed;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            BuyPanel.Visibility = Visibility.Collapsed;
            switch (object2buy.Name)
            {
                case "Bomb":
                    
                    break;
                case "Ice":
                    
                    break;
                case "Vaccine":
                    
                    break;
                case "Wind":
                    
                    break;
                case "Shield":
                    
                    break;
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NivelPage));
        }
    }
}
