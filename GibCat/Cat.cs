using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibCat
{
    public class Cat
    {
        //public string breeds;
        public string id;
        public string url;
        public int width;
        public int height;

        public Cat( string id, string url, int width, int height)
        {
           // this.breeds = "k";
           this.id = id;
           this.url = url;
            this.width = width;
            this.height = height;
        }
    }
}
