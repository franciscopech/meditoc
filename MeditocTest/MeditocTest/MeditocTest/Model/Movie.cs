using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
namespace MeditocTest.Model
{
    public class Movie
    {
        public int id { get; set; }
        
        string _poster_path;
        public string poster_path 
        {
            get => $"{Settings.Instance.ImagePath}{_poster_path}";
            set
            {
                _poster_path = value;
            }
        }
        public bool adult { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
        public int[] genre_ids { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }

        //DETAILS
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<Genre> Genres{ get; set; }


        static public Movie DynamicToMovie(dynamic obj)
        {
            string aux = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(aux);
        }

        static public List<Movie> DynamicToMovieArray(dynamic obj)
        {
            string aux = Newtonsoft.Json.JsonConvert.SerializeObject(obj.Response.results);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(aux);
        }
        
        static public List<Movie> GetPopular()
        {
            var aux = GetPostClient.GETSync("popular");
            return Movie.DynamicToMovieArray(aux);            
        }
        static public List<Movie> GetTopRate()
        {
            var aux = GetPostClient.GETSync("top_rated");
            return Movie.DynamicToMovieArray(aux);
        }
        static public List<Movie> GetUpComing()
        {
            var aux = GetPostClient.GETSync("upcoming");
//            var auxobj = await aux;
            return Movie.DynamicToMovieArray(aux);
        }

        async public void UpdateDatails()
        {
            var auxobj = GetPostClient.GETSync(id.ToString());
            string jsnproductions = Newtonsoft.Json.JsonConvert.SerializeObject(auxobj.Response.production_companies);
            ProductionCompanies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionCompany>>(jsnproductions);

            string jsngenres = Newtonsoft.Json.JsonConvert.SerializeObject(auxobj.Response.genres);
            Genres = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Genre>>(jsngenres);
        }        
    }

}
