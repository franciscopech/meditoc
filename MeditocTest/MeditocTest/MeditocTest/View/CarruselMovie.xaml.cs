using MeditocTest.Model;
using MeditocTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditocTest.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarruselMovie : StackLayout
    {
        public CarruselMovie()
        {
            InitializeComponent();
        }
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CarruselMovie));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty MoviesProperty = BindableProperty.Create(nameof(Movies), typeof(ObservableCollection<VMMovie>), typeof(CarruselMovie), null, BindingMode.OneWay, null, OnEventNameChanged);
        public ObservableCollection<VMMovie> Movies
        {
            get
            {
                return (ObservableCollection<VMMovie>)GetValue(MoviesProperty);
            }
            set
            {
                SetValue(MoviesProperty, value);
            }
        }
        
       
        public static readonly BindableProperty TextSearchProperty = BindableProperty.Create(nameof(TextSearch), typeof(string), typeof(CarruselMovie), null, BindingMode.OneWay, null, OnEventNameChanged);
        public string TextSearch
        {
            get
            {
                return (string)GetValue(TextSearchProperty);

            }
            set
            {
                SetValue(TextSearchProperty, value);
            }
        }
        static INavigation nav;
        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (CarruselMovie)bindable;
            nav = ctrl.Navigation;
            
            //ctrl.crsl_main. = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal) { ItemSpacing = 20 };
            foreach (var item in  (newValue as ObservableCollection<VMMovie>))
            {
                item.OnSelectedMovie -= Item_OnSelectedMovie;
                item.OnSelectedMovie += Item_OnSelectedMovie;
                
            }
        }

        private static void Item_OnSelectedMovie(Movie movie)
        {
            movie.UpdateDatails();
            nav.PushModalAsync(new MovieDetails(movie));
        }
    }
}