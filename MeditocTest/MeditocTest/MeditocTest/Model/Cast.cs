using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeditocTest.Model
{
    public class Cast
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public int gender { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
    
        string _profile_path;
        public string profile_path
        {
            get => $"{Settings.Instance.ImagePath}{_profile_path}";
            set
            {
                _profile_path = value;
            }
        }
        public string character { get; set; }

        static public List<Cast> DynamicToMovieArray(dynamic obj)
        {
            string aux = Newtonsoft.Json.JsonConvert.SerializeObject(obj.Response.cast);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cast>>(aux);
        }
        static async public Task<List<Cast>> GetCredits(int id)
        {
            var aux = GetPostClient.GET($"{id}/credits");
            var auxobj = await aux;
            return Cast.DynamicToMovieArray(auxobj);
        }
    }
}
