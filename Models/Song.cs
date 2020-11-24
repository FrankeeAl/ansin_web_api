using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int PeakChartPosition { get; set; }
    }
}