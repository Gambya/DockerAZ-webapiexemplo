using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreExemplo.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCoreExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MongoDB.Driver.MongoClient _mongoDbClient;

        public HomeController(MongoDB.Driver.MongoClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var collection = _mongoDbClient.GetDatabase("admin").GetCollection<Aluno>("aluno");
            collection.InsertMany(new[]{
                new Aluno{ Nome = "Roberto Ramos", Idade = 38 },
                new Aluno{ Nome = "Zoe Ramos", Idade = 3 },
                new Aluno{ Nome = "Chloe Ramos", Idade = 1 }
            });
            return Ok("3 alunos foram adicionados");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
