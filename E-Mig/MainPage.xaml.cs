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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace E_Mig
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Vonat> vonatok = new List<Vonat>();
        MainViewModel wm = new MainViewModel();

        public MainPage()
        {
            
            this.InitializeComponent();
            this.InitializeLayout();

            VonatBetoltes();

        }

        void InitializeLayout()
        {
            map.ZoomLevel = 8;
            map.Center = new Windows.Devices.Geolocation.Geopoint(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 47.157466, Longitude = 19.292040 });
        }

        async void VonatBetoltes()
        {
            vonatok = await DataConnection.Vonatok();
            while (vonatok.Count == 0)
            {

            }
            wm.Vonatok = vonatok;
            this.DataContext = wm;
        }

        private void btnMenuToggle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenuToggle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainPage_SplitView.IsPaneOpen = !mainPage_SplitView.IsPaneOpen;
        }

        private void btnMapZoomIn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            map.ZoomLevel++;
        }

        private void btnMapZoomOut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMapZoomOut_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (map.ZoomLevel > 1)
            {
                map.ZoomLevel--;
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image img = (Image)sender;
            int index = Convert.ToInt32(img.Tag);
            ContentDialog dlg = new ContentDialog();
            dlg.Title = vonatok[index].Palyaszam;
            dlg.Content = String.Format("UIC: {0}\nVonatszám: {1}", new object[] { vonatok[index].UIC.ToString(), vonatok[index].Vonatszam.ToString() });
            dlg.IsPrimaryButtonEnabled = true;
            dlg.PrimaryButtonText = "OK";
            dlg.PrimaryButtonClick += Dlg_PrimaryButtonClick;
            dlg.ShowAsync();
        }

        private void Dlg_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            sender.Hide();
        }

        async void VonatDialogShow(Vonat v)
        {
            ContentDialog dlg = new ContentDialog();

            dlg.Title = v.Palyaszam;
            dlg.Content = "\n" + String.Format("UIC: \t{0} \n Vonatszám: \t{1}", new object[] { v.UIC, v.Palyaszam });
        }

        private void menu_map_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_station_Click(object sender, RoutedEventArgs e)
        {

        }

        private void command_settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void menu_settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }
    }
    public class MainViewModel
    {
        private ICollection<Vonat> _vonatok = new List<Vonat>();

        public ICollection<Vonat> Vonatok
        {
            get { return _vonatok; }
            set { _vonatok = value; }
        }

    }
}
