using MeditocTest.Model;
using MeditocTest.View;
using MeditocTest.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeditocTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void CarruselMovie_EventOnSelectedMovie(Movie movie)
        {
            movie.UpdateDatails();
            Navigation.PushModalAsync(new MovieDetails(movie));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
