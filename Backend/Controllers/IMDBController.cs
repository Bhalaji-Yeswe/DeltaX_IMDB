using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class IMDBController : ControllerBase
    {
        public AppDB Db { get; }
        public IMDBController(AppDB db)
        {
            Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new IMDBquery(Db);
            var result = await query.latestPostsAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetParticular(string title)
        {
            await Db.Connection.OpenAsync();
            var query = new IMDBquery(Db);
            var result = await query.FindOneAsync(title);
            if(result is null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody]IMDBPost body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            if (ValidateoneProducer.validate(body.producer))
            {
                return new BadRequestResult();
            }
            else
            {
                await body.insertAsync();
            }
            return new OkObjectResult(body);
        }

        [HttpPut("{title}")]
        public async Task<IActionResult> UpdateActors(string title,[FromBody]IMDBPost body)
        {
            await Db.Connection.OpenAsync();
            var query = new IMDBquery(Db);
            var result = await query.FindOneAsync(title);

            if(result is null)
            {
                return new NotFoundResult();
            }
            result.actors = body.actors;
            result.producer = body.producer;
            await result.updateAsync();
            return new OkObjectResult(result);
        }

        [HttpDelete("title")]
        public async Task<IActionResult> DeleteMovies(string title)
        {
            await Db.Connection.OpenAsync();
            var query = new IMDBquery(Db);
            var result = await query.FindOneAsync(title);

            if(result is null)
            {
                return new NotFoundResult();
            }
            await result.deleteMovieAsync();
            return new OkResult();
        }

        
    }
}
