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
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModel _model;

        public ModelsController(IModel model)
        {
            _model = model;
        }

        // GET: api/Models
        [HttpGet]
        public IEnumerable<Model> Get()
        {
            return _model.GetAllPlayers();
        }

        [HttpPost]
        public ActionResult<Model> Post(Model model)
        {
            model.PlayerName = "asd";
            model.Score = 500;
            _model.AddPlayer(model);

            return CreatedAtAction("GetModel", new { id = model.Id }, model);
        }

        
    }
}
