﻿using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TesteAuthorization.Infra.Repository
{
    public class ProdutoCategoriaRepository : IDisposable
    {
        private Model _entities;


        public ProdutoCategoriaRepository()
        {
            _entities = new Model();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}