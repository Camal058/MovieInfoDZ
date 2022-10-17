using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieInfoDZ
{
    public class SearchRes
    {
        public bool ok { get; set; }
        public Result? result { get; set; }
    }

    public class Result
    {
        public Movie[]? Movies { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string thumbnail { get; set; }
        public override string ToString()
        {
            return $"{Title} ";
        }

    }



}
