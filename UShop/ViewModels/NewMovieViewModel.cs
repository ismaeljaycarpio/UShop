﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UShop.Entities;


namespace UShop.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}