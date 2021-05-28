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
    public partial class MovieDetails : ContentPage
    {
        public MovieDetails(Movie movie)
        {
            InitializeComponent();
            (stck_main.BindingContext as VMMovieDetails).CurrentMovie = movie;
            //rtng_star.Rate = movie.vote_average;
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}