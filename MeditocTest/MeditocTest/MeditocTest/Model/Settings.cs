using System;
using System.Collections.Generic;
using System.Text;

namespace MeditocTest.Model
{
    public class Settings
    {
        static private Settings _Instance;
        static public Settings Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Settings();
                
                return _Instance;
            }
        }

        public string URLPATH { get; }
        public string ImagePath { get; }
        public const string APIKEY = "5254513b126de2b5e7794c215c67a674";
        public int MaxElementsList;
        public string Language { get;  }
        public Settings()
        {
            URLPATH = "https://api.themoviedb.org/3/movie/";
            ImagePath = "https://image.tmdb.org/t/p/w500";
            Language = "es-MX";
            MaxElementsList = 10;
        }
    }
}
