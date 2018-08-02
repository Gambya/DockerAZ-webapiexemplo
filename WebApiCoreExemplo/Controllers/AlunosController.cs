using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreExemplo.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace WebApiCoreExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly MongoDB.Driver.MongoClient _mongoDbClient;

        public AlunosController(MongoDB.Driver.MongoClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            var listaAlunos = _mongoDbClient.GetDatabase("admin").GetCollection<Aluno>("aluno").Find(Builders<Aluno>.Filter.Where(it=>it.Idade>0)).ToList();
            return listaAlunos;
        }
    }
}
