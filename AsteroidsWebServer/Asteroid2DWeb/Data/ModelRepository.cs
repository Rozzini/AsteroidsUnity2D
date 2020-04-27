﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteroid2DWeb
{
    public class ModelRepository : IModel
    {
        private readonly AppDbContext appDbContext;

        public ModelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AddPlayer(Model models)
        {
            appDbContext.Models.Add(models);
            appDbContext.SaveChanges();
        }

        public IEnumerable<Model> GetAllPlayers()
        {
            return appDbContext.Models;
        }
    }
}