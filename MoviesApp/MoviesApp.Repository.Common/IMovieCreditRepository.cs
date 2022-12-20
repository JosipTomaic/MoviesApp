﻿using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Repository.Common
{
    public interface IMovieCreditRepository
    {
        IEnumerable<IMovieCreditDomain> GetMovieCredits();
    }
}
