using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Asteroid2DWeb.Controllers
{
    [Route("[controller]/[Action]")]
    public class ScoresController : Controller
    {
        private readonly IModel _model;

        public ScoresController(IModel model)
        {
            _model = model;
        }

        public IActionResult AllScores()
        {
            return View(_model.GetAllPlayers("des"));
        }
    }
}