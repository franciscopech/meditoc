using MeditocTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MeditocTest.ViewModel
{
    public class VMMain:INotifyPropertyChanged
    {
        public VMMain()
        {
            POP = VMMovie.MovieToVMList(Movie.GetPopular());
            TR = VMMovie.MovieToVMList(Movie.GetTopRate());
            UPC = VMMovie.MovieToVMList(Movie.GetUpComing());

            UpdateLists();
        }
        public List<VMMovie> TR { get; set; }
        public List<VMMovie> UPC { get; set; }
        public List<VMMovie> POP { get; set; }

        ObservableCollection<VMMovie> _TopRate;
        public ObservableCollection<VMMovie> TopRate 
        {
            set
            {
                _TopRate = value;
            }
            get
            {
                if (_TopRate == null)
                    _TopRate = new ObservableCollection<VMMovie>();                
                return _TopRate;
            }
        }
        ObservableCollection<VMMovie> _UpComing;
        public ObservableCollection<VMMovie> UpComing 
        {
            set
            {
                _UpComing = value;
            }
            get
            {
                if (_UpComing == null)
                    _UpComing = new ObservableCollection<VMMovie>();


                return _UpComing;
            }
        }
        ObservableCollection<VMMovie> _Popular;
        public ObservableCollection<VMMovie> Popular 
        {
            set
            {
                _Popular = value;
            }
            get
            {
                if (_Popular == null)
                    _Popular = new ObservableCollection<VMMovie>();


                return _Popular;
            }
        }

        string _TextSearch;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnChangeProp(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string TextSearch
        {
            get => _TextSearch;
            set
            {
                _TextSearch = value;

                if (value != null)
                {
                    if (value.Length >= 3 || value.Length == 0)
                    {
                        UpdateLists();
                    }
                   /* OnChangeProp(nameof(TopRate));
                    OnChangeProp(nameof(Popular));
                    OnChangeProp(nameof(UpComing));*/
                }
            }
        }
        ObservableCollection<VMMovie> FilterList(List<VMMovie> lista)
        {
            ObservableCollection<VMMovie> ret = new ObservableCollection<VMMovie>();
            foreach (var item in lista)
            {
                ret.Add(item);
            }
            return ret;
        }
        public void UpdateLists()
        {
            TopRate.Clear();
            foreach (var item in TR)
            {
                item.TextSearch = _TextSearch;
                if (item.ShowMovie)
                    TopRate.Add(item);
            }

            Popular.Clear();
            foreach (var item in POP)
            {
                item.TextSearch = _TextSearch;
                if (item.ShowMovie)
                    Popular.Add(item);
            }

            UpComing.Clear();
            foreach (var item in UPC)
            {
                item.TextSearch = _TextSearch;
                if (item.ShowMovie)
                    UpComing.Add(item);
            }


        }
    }
}
