using Microsoft.AspNetCore.Mvc;

namespace TP_MODUL10_103022400129.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        // Data default disimpan di variabel static (Poin 5)
        private static List<Film> dataFilm = new List<Film>
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

        // GET /api/Film
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return dataFilm;
        }

        // GET /api/Film/{id}
        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            if (id < 0 || id >= dataFilm.Count) return NotFound();
            return dataFilm[id];
        }

        // POST /api/Film
        [HttpPost]
        public void Post([FromBody] Film newFilm)
        {
            dataFilm.Add(newFilm);
        }

        // DELETE /api/Film/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= dataFilm.Count) return NotFound();
            dataFilm.RemoveAt(id);
            return Ok();
        }
    }
}