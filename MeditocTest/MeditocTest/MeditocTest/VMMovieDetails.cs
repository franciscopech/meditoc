using MeditocTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MeditocTest.ViewModel
{
    public class VMMovieDetails: INotifyPropertyChanged
    {
        public ObservableCollection<Cast> Casting { get; set; }
        Movie _CurrentMovie;
        public Movie CurrentMovie 
        {
            get => _CurrentMovie;
            set
            {
                if (value != null)
                {
                    _CurrentMovie = value;
                    UpdateVM(value.id);
                    OnPropChange(nameof(CurrentMovie));
                    OnPropChange(nameof(StudioName));
                    OnPropChange(nameof(Genres));
                }
            }
        }
        public string StudioName => CurrentMovie != null && CurrentMovie.ProductionCompanies != null && CurrentMovie.ProductionCompanies.Count > 0 ? CurrentMovie.ProductionCompanies[0].name : "";
        public string Genres
        {
            get 
            {
                string aux = "";
                if (CurrentMovie != null && CurrentMovie.Genres != null && CurrentMovie.Genres.Count > 0)
                    for(int i = 0; i < CurrentMovie.Genres.Count; i++)
                    {
                        aux += CurrentMovie.Genres[i].Name;
                        if (i < CurrentMovie.Genres.Count - 1)
                            aux += ", ";
                    }
                return aux;
            }
        }
        private async void UpdateVM(int id)
        {
            var auxcast = await Cast.GetCredits(id);
            Casting = new ObservableCollection<Cast>();
            foreach (var item in auxcast)
            {
                if (Casting.Count < Settings.Instance.MaxElementsList)
                    Casting.Add(item);
                else
                    break;
            }
            OnPropChange(nameof(Casting));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
