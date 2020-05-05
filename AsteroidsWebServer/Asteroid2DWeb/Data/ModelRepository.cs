using System;
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

        public IEnumerable<Model> GetAllPlayers(string Order)
        {
            var players = from db in appDbContext.Models
                           select db;
            if (Order == "des")
            {
                players = players.OrderByDescending(db => db.Score);
                return players;
            }
            if (Order == "asc")
            {
                players = players.OrderBy(db => db.Score);
                return players;
            }
            else
            {
                return null;
            }
        }
    }
}
