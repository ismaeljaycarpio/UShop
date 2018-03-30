using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UShop.Models;
using UShop.Dto;
using AutoMapper;


namespace UShop.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/movies

    }
}
