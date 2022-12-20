using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IMovieCreditDomain
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
