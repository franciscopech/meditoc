using MeditocTest.Model;
using MeditocTest.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeditocTest.ViewModel
{
    public class VMMovie : INotifyPropertyChanged
    {
        static public ObservableCollection<VMMovie> MovieToVM(List<Movie> movies)
        {
            ObservableCollection<VMMovie> mvs = new ObservableCollection<VMMovie>();
            if (movies != null)
            {
                foreach (var item in movies)
                {
                    if (mvs.Count < Settings.Instance.MaxElementsList)
                        mvs.Add(new VMMovie(item));
                    else
                        break;
                }
            }
            return mvs;
        }
        static public List<VMMovie> MovieToVMList(List<Movie> movies)
        {
            List<VMMovie> mvs = new List<VMMovie>();
            if (movies != null)
            {
                foreach (var item in movies)
                {
                    if (mvs.Count < Settings.Instance.MaxElementsList)
                        mvs.Add(new VMMovie(item));
                    else
                        break;
                }
            }
            return mvs;
        }
        public Movie ItemMovie { get; set; }

        public bool ShowMovie
        {
            get
            {
                if (TextSearch != null)
                    if (TextSearch != "")
                        return ItemMovie.title.ToUpper().Contains(TextSearch.ToUpper());
                    else
                        return true;
                else
                    return true;
            }
        }
        string _TextSearch;
        public string TextSearch 
        {
            get => _TextSearch;
            set
            {
                _TextSearch = value; 
                OnChangeProp(nameof(ShowMovie));
            }
        }
        public ICommand OnSelectedMovieCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChangeProp(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public delegate void DelegateOnSelectedMovie(Movie movie);
        public event DelegateOnSelectedMovie OnSelectedMovie;
        public VMMovie(Movie movie)
        {
            ItemMovie = movie;
            OnSelectedMovieCommand = new Command(() =>
            {
                if(movie != null && movie.Genres != null)
                    movie.UpdateDatails();
                OnSelectedMovie?.Invoke(ItemMovie);
            });
            
        }
    }
}
