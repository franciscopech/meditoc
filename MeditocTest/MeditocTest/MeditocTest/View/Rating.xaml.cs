using MeditocTest.Model;
using MeditocTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditocTest.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rating : StackLayout
    {
        public Rating()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty RateProperty = BindableProperty.Create(nameof(Rate), typeof(float), typeof(CarruselMovie),null,BindingMode.OneWay,null,OnEventNameChanged);
        float _Rate;
        public float Rate 
        {
            get
            {
                return (float)GetValue(RateProperty);
            }
            set
            {
                SetValue(RateProperty, value);
            }
        }


        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Rating)bindable;

            var vm = ctrl.stck_main.BindingContext as VMRating;
            vm.Rate = Convert.ToSingle(newValue?.ToString());
        }
    }
}