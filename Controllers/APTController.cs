using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WEBAPISP_CRUDAPP.Models;

namespace WEBAPISP_CRUDAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APTController : ControllerBase
    {
        private readonly AptonlineContext _context;
        private readonly IHttpClientFactory _httpClient;
        public APTController(AptonlineContext context, IHttpClientFactory  httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var result = _context.Aptests.FromSqlRaw("EXEC sp_getaptest ").ToList();
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.Aptests
                .FromSqlRaw("EXEC sp_getbyidaptest @Id",
                    new SqlParameter("@Id", id))
                .ToList()
                .FirstOrDefault();

            return Ok(result);
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Aptest model)
        {
            var result = _context.Database.ExecuteSqlRaw("EXEC sp_insertaptest @name, @description,@duration,@modules",
                new SqlParameter("@name", model.Name),
                new SqlParameter("@description", model.Description),
                new SqlParameter("@duration", model.Duration),
                new SqlParameter("@modules", model.Modules));
            return Ok("inserted sucessfully");
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Aptest model)
        {
            var result = _context.Database.ExecuteSqlRaw("Exec sp_updateaptest @id,@name,@description,@duration,@modules",
                new SqlParameter("@id", model.Id),
                new SqlParameter("@name", model.Name),
                 new SqlParameter("@description", model.Description),
                  new SqlParameter("@duration", model.Duration),
                 new SqlParameter("@modules", model.Modules));
            return Ok("updated sucessfully");

        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            var result = _context.Database.ExecuteSqlRaw("Exec sp_deleteaptest @id", new SqlParameter("@id", id));
          return Ok("Delete Sucessfully");
        }

        [HttpGet]
        [Route("GetAllFromExternalAPI")]
        public async Task<ActionResult> GetAllFromExternalAPI()
        {
            var httpClient =  _httpClient.CreateClient();
            string response = await httpClient.GetStringAsync("https://api.restful-api.dev/objects");
            return Ok(response);
        }

    }
}
