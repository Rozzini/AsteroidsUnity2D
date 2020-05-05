using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asteroid2DWeb;

namespace Asteroid2DWeb.Controllers
{

    [Route("Scores/[Action]")]
    [ApiController]
    public class ModelsControllerAPI : ControllerBase
    {
        private readonly IModel _model;

        public ModelsControllerAPI(IModel model)
        {
            _model = model;
        }


        [HttpGet]
        public IEnumerable<Model> GetScores(string order)
        {
            return _model.GetAllPlayers(order);
        }

        [HttpPost]
        public void PostScore(Model model)
        {
            _model.AddPlayer(model);

        }

        
    }
}
