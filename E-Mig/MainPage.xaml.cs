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
