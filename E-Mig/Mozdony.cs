using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace E_Mig
{
    public class Mozdony
    {
        private string _uic;
        private string _palyaszam;
        private double _lat;
        private double _lon;
        private string _vonatszam;
        private string _kiindulasiAllomas;
        private string _celallomas;
        private MozdonyTipus _mozdonyTipus;
        private string _icon;

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
        public string UIC
        {
            get { return _uic; }
            set
            {
                _uic = value;
                Palyaszam = filterUIC(value);
                selectType();
            }
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
        public string Palyaszam
        {
            get { return _palyaszam; }
            set
            {
                _palyaszam = value;
            }
        }

        string filterUIC(string uic)
        {
            string str = uic.Remove(0, 4).Remove(7, 1);
            str = String.Format("{0} {1}", str.Substring(0, 4), str.Substring(4));
            if (str.StartsWith("0")) str = str.Remove(0, 1);
            return str;
        }
        void selectType()
        {
            string[] s = _palyaszam.Split(' ');

            switch (s[0])
            {
                case "431":
                    _mozdonyTipus = MozdonyTipus.ElektromosRegi;
                    break;
                case "432":
                    _mozdonyTipus = MozdonyTipus.ElektromosRegi;
                    break;
                case "433":
                    _mozdonyTipus = MozdonyTipus.ElektromosRegi;
                    break;
                case "448":
                    _mozdonyTipus = MozdonyTipus.Dizel;
                    break;
                case "418":
                    _mozdonyTipus = MozdonyTipus.Dizel;
                    break;
                case "628":
                    _mozdonyTipus = MozdonyTipus.Dizel;
                    break;
                case "470":
                    _mozdonyTipus = MozdonyTipus.ElektromosUj;
                    break;
                case "480":
                    _mozdonyTipus = MozdonyTipus.ElektromosUj;
                    break;
                case "5341":
                    _mozdonyTipus = MozdonyTipus.ElektromosMotor;
                    break;
            }
        }
        public Geopoint Location
        {
            get { return new Geopoint(new BasicGeoposition() { Latitude = this.Latitude, Longitude = this.Longitude }); }
        }

        public Point Anchor
        {
            get
            {
                return new Point(0.5, 0.5);
            }
        }

        public string MarkerImage
        {
            get
            {
                string src = "Images/OtherMarker.png";
                switch (_mozdonyTipus)
                {
                    case MozdonyTipus.Dizel:
                        src = "Images/Grey_"+ _tipus +".png";
                        break;
                    case MozdonyTipus.DizelMotor:
                        src = "Images/Green_" + _tipus + ".png";
                        break;
                    case MozdonyTipus.ElektromosEgyeb:
                        src = "Images/Orange_" + _tipus + ".png";
                        break;
                    case MozdonyTipus.ElektromosGanz:
                        src = "Images/Red_" + _tipus + ".png";
                        break;
                    default:
                        src = "Images/BG_" + _tipus + ".png";
                        break;
                }
                return src;
            }
        }
        public string Index
        {
            get; set;
        }

        

        private string _tipus;

        public string Tipus
        {
            get { return _tipus; }
            set { _tipus = value; }
        }



        public int Angle
        {
            get
            {
                if (_icon != "z-z-a" && _icon != "z-l-a" && _icon != "z-p-a" && _icon != "p-z-a" && _icon != "l-z-a")
                {
                    return Convert.ToInt32(_icon.Split('-')[2]);
                }
                else return 0;
            }
            set { Angle = value; }
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
