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
        int ice=0, bomb=0, shield=0, vaccine=0, wind=0;
        DispatcherTimer timer;
        int puntuacion=3000, monedas=1000;
        public GamePage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sel = sender as Button;
            MenuFlyout flyout = new MenuFlyout();
     
            flyout.Items.Add(newitem("Juego_Alcohol.png",250,"Alcohol"));
            flyout.Items.Add(newitem("Juego_Gel.png", 200, "Gel"));
            flyout.Items.Add(newitem("Juego_Jabon.png", 100, "Jabon"));
            flyout.Items.Add(newitem("Juego_Mascarillas.png", 150, "Mascarillas"));
            flyout.Items.Add(newitem("Juego_Paracetamol.png", 500, "Paracetamol"));
            flyout.Items.Add(newitem("Juego_UV.png", 200, "UV"));
            flyout.Items.Add(newitem("Juego_Cuadro.png", 0 , "Reset"));
            sel.Flyout = flyout;
        }
        MenuFlyoutItem newitem(string path,int price ,string name)
        {
            MenuFlyoutItem item = new MenuFlyoutItem();
            item.Text = name + " " +price.ToString();
            var bmi = new BitmapIcon();
            string url = "ms-appx:///Assets/"+path;
            bmi.UriSource = new Uri(url);
            bmi.ShowAsMonochrome = false;
            item.Icon = bmi;
            item.Click += (s, e1) =>
            {
                if(puntuacion >= price)
                {
                    puntuacion -= price;
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(url));
                    sel.Content = img;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(puntuacion)));
                }
                else
                {
                    BuyErrorP.Visibility = Visibility.Visible;
                    timer.Start();
                    timer.Tick += (s1, o) =>
                    {
                        BuyErrorP.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                }
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
            MenuFlyout flyout = new MenuFlyout();
            MenuFlyoutItem item = new MenuFlyoutItem();
            item.Text = "COMPRAR";
            item.Click += (s, e1) =>
            {
                buy();
            };
            flyout.Items.Add(item);
            bool exists = false;
            switch (object2buy.Name)
            {
                case "Bomb":
                    if (bomb > 0) exists = true;
                    break;
                case "Ice":
                    if (ice > 0) exists = true;
                    break;
                case "Vaccine":
                    if (vaccine > 0) exists = true;
                    break;
                case "Wind":
                    if (wind > 0) exists = true;
                    break;
                case "Shield":
                    if (shield > 0) exists = true;
                    break;
            }

            if (exists)
            {
                MenuFlyoutItem itemU = new MenuFlyoutItem();
                itemU.Text = "USAR";
                itemU.Click += (s, e1) =>
                {
                    Use();
                };
                flyout.Items.Add(itemU);
            }
            object2buy.Flyout = flyout;
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
            bool buy = false;
            BuyPanel.Visibility = Visibility.Collapsed;
            switch (object2buy.Name)
            {
                case "Bomb":
                    if(monedas >= 150)
                    {
                        monedas -= 150; 
                        bomb++;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bomb)));
                        buy = true;
                    }
                    break;
                case "Ice":
                    if (monedas >= 100)
                    {
                        monedas -= 100;
                        ice++;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ice)));
                        buy = true;
                    }
                    break;
                case "Vaccine":
                    if (monedas >= 100)
                    {
                        monedas -= 100;
                        vaccine++;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(vaccine)));
                        buy = true;
                    }
                    break;
                case "Wind":
                    if (monedas >= 80)
                    {
                        monedas -= 80;
                        wind++;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(wind)));
                        buy = true;
                    }

                    break;
                case "Shield":
                    if (monedas >= 120)
                    {
                        monedas -= 120;
                        shield++;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(shield)));
                        buy = true;
                    }
                    break;
            }
            if (!buy)
            {
                BuyErrorM.Visibility = Visibility.Visible;
                timer.Start();
                timer.Tick += (s1, o) =>
                {
                    BuyErrorM.Visibility = Visibility.Collapsed;
                    timer.Stop();
                };
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(monedas)));
        }
        private void buy()
        {
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
        private void Use() {
            switch (object2buy.Name)
            {
                case "Bomb":
                    BaseLive.Value = BaseLive.Value - 10;
                    bomb--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bomb)));
                    ExpEff.Visibility = Visibility.Visible;
                    timer.Start();
                    timer.Tick += (sender, o) =>
                    {
                        ExpEff.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                    break;
                case "Ice":
                    ice--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ice)));
                    FrostEff.Visibility = Visibility.Visible;
                    timer.Start();
                    timer.Tick += (sender, o) =>
                    {
                        FrostEff.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                    break;
                case "Vaccine":
                    vaccine--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(vaccine)));
                    HealEff.Visibility = Visibility.Visible;
                    BaseLive.Value = BaseLive.Value + 10;
                    timer.Start();
                    timer.Tick += (sender, o) =>
                    {
                        HealEff.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                    break;
                case "Wind":
                    wind--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(wind)));
                    WindEff.Visibility = Visibility.Visible;
                    timer.Start();
                    timer.Tick += (sender, o) =>
                    {
                        WindEff.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                    break;
                case "Shield":
                    shield--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(shield)));
                    ShieldEff.Visibility = Visibility.Visible;
                    timer.Start();
                    timer.Tick += (sender, o) =>
                    {
                        ShieldEff.Visibility = Visibility.Collapsed;
                        timer.Stop();
                    };
                    break;
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NivelPage));
        }
    }
}
