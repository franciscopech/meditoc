using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MeditocTest.ViewModel
{
    public class VMRating: INotifyPropertyChanged
    {
        public ImageSource star1 { get; set; }
        public ImageSource star2 { get; set; }
        public ImageSource star3 { get; set; }
        public ImageSource star4 { get; set; }
        public ImageSource star5 { get; set; }

        float _Rate;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public float Rate 
        {
            get => _Rate;
            set
            {
                _Rate = value/2;
                star1 = GetResource(_Rate);
                star2 = GetResource(_Rate - 1);
                star3 = GetResource(_Rate - 2);
                star4 = GetResource(_Rate - 3);
                star5 = GetResource(_Rate - 4);

                OnPropChange(nameof(star1));
                OnPropChange(nameof(star2));
                OnPropChange(nameof(star3));
                OnPropChange(nameof(star4));
                OnPropChange(nameof(star5));
            }
        }

        public ImageSource GetResource(float valor)
        {
            string ret = "";
            if (valor >= 1.0f)
                ret = "MeditocTest.Media.estrellas.estrella_entera.png";

            else if (valor >= 0.5f)
                ret = "MeditocTest.Media.estrellas.estrella_media.png";
            else
                ret = "MeditocTest.Media.estrellas.estrella_vacia.png";

            return ImageSource.FromResource(ret);
        }
    }
}
