using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteroid2DWeb
{
    public interface IModel
    {
        IEnumerable<Model> GetAllPlayers();

        void AddPlayer(Model models);
    }
}
