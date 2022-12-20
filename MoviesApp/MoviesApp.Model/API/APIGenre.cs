using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class APIGenre : IAPIGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
