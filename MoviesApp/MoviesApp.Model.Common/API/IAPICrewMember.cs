using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IAPICrewMember
    {
        int Id { get; set; }
        string? Name { get; set; }
        double Popularity { get; set; }
        string? Job { get; set; }
    }
}
