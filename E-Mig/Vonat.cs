using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace E_Mig
{
    public class Vonat
    {
        //Fields
        private string _uic;
        private string _palyaszam;
        private double _lat;
        private double _lon;
        private string _vonatszam;
        private string _kiindulasiAllomas;
        private string _celallomas;
        private MozdonyTipus _mozdonyTipus;
        private string _vonatTipus;
        private string _icon;
        private string _iconSource;

        //Properties
        public string UIC
        {
            get { return _uic; }
            set { _uic = value; }
        }
        public string Palyaszam
        {
            get { return filterUIC(_uic); }
        }
        public string Vonatszam
        {
            get { return _vonatszam; }
            set { _vonatszam = value; }
        }
        public double Longitude
        {
            get { return _lon; }
            set { _lon = value; }
        }
        public double Latitude
        {
            get { return _lat; }
            set { _lat = value; }
        }
        public string KiinduloAllomas
        {
            get { return _kiindulasiAllomas; }
            set { _kiindulasiAllomas = value; }
        }
        public string Celallomas
        {
            get { return _celallomas; }
            set { _celallomas = value; }
        }
        public MozdonyTipus MozdonyTipus
        {
            get { return _mozdonyTipus; }
            set { _mozdonyTipus = value; }
        }
        public string VonatTipus
        {
            get { return _vonatTipus; }
            set { _vonatTipus = value; }
        }
        public Geopoint Location
        {
            get { return new Geopoint(new BasicGeoposition() { Latitude = this.Latitude, Longitude = this.Longitude }); }
        }
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        public string IconSource
        {
            get
            {
                return "";
            }
        }

        //Helpers
        string filterUIC(string uic)
        {
            string str = uic.Remove(0, 4).Remove(7, 1);
            str = String.Format("{0} {1}", str.Substring(0, 4), str.Substring(4));
            if (str.StartsWith("0")) str = str.Remove(0, 1);
            return str;
        }
        string getSource()
        {
            string src = @"Images\";
            switch (_mozdonyTipus)
            {
                case MozdonyTipus.Dizel:
                    src += "Blue_";
                    switch (_icon)
                    {

                    }
                    break;
            }
            return "";
        }



        int getAngle()
        {
            if (_icon != "z-z-a" && _icon != "z-l-a" && _icon != "z-p-a" && _icon != "p-z-a" && _icon != "l-z-a")
            {
                return Convert.ToInt32(_icon.Split('-')[2]);
            }
            else return 0;
        }

    }

    public enum MozdonyTipus
    {
        Dizel,
        DizelMotor,
        DizelEgyeb,
        ElektromosRegi,
        ElektromosUj,
        ElektromosMotor,
        ElektromosEgyeb
    }
}
