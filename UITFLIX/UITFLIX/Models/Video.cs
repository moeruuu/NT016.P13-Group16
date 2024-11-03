using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITFLIX.Models
{
    internal class Video
    {
        public string Title { get; set; }
        public DateTime uploaddate { get; set; }
        public double rate { get; set; }
        public string urlvideo { get; set; }
        public string urlimage {  get; set; }
    }
}
