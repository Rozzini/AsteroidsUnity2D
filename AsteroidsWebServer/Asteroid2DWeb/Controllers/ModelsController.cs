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
    public class ModelsController : ControllerBase
    {
        private readonly IModel _model;

        public ModelsController(IModel model)
        {
            _model = model;
        }


        [HttpGet]
        public IEnumerable<Model> GetScores()
        {
            return _model.GetAllPlayers();
        }

        [HttpPost]
        public void PostScore(Model model)
        {
            _model.AddPlayer(model);

        }

        
    }
}
