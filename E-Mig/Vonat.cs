using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace E_Mig
{
    public class Vonat
    {
        //Fields
        private string _uic = "";
        private string _palyaszam = "";
        private double _lat = 0;
        private double _lon = 0;
        private string _vonatszam = "";
        private string _kiindulasiAllomas = "";
        private string _celallomas = "";
        private MozdonyTipus _mozdonyTipus = MozdonyTipus.DizelEgyeb;
        private string _vonatTipus = "";
        private string _icon = "";
        private string _iconSource = null;

        //Properties
        public string UIC
        {
            get { return _uic; }
            set
            {
                _uic = value;
                _palyaszam = filterUIC(value);
                _mozdonyTipus = getMT(_palyaszam);
                _iconSource = getSource();
            }
        }
        public string Palyaszam
        {
            get { return filterUIC(_uic); }
            set { _palyaszam = value; }
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
        public Point Anchor
        {
            get { return new Point(0.5, 0.5); }
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
                return getSource();
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
                    src += "Grey" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.DizelMotor:
                    src += "Orange" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.DizelEgyeb:
                    src += "BG" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.ElektromosRegi:
                    src += "Red" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.ElektromosUj:
                    src += "Blue" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.ElektromosMotor:
                    src += "Green" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                case MozdonyTipus.ElektromosEgyeb:
                    src += "Yellow" + "_" + _vonatTipus + "_" + getAngle().ToString() + ".png";
                    break;
                default:
                    return @"Images\BaseIcon_0.png";
            }
            return src;
        }
        int getAngle()
        {
            if (_icon != "z-z-a" && _icon != "z-l-a" && _icon != "z-p-a" && _icon != "p-z-a" && _icon != "l-z-a")
            {
                return Convert.ToInt32(_icon.Split('-')[2]);
            }
            else return 0;
        }
        MozdonyTipus getMT(string psz)
        {
            string psz1 = psz.Trim().Split(' ')[0];

            switch (psz1)
            {
                case "431":
                    return MozdonyTipus.ElektromosRegi;
                case "432":
                    return MozdonyTipus.ElektromosRegi;
                case "433":
                    return MozdonyTipus.ElektromosRegi;
                case "1047":
                    return MozdonyTipus.ElektromosUj;
            }
            
            return MozdonyTipus.ElektromosUj;
            
        }
        public int Index
        {
            get;
            set;
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
