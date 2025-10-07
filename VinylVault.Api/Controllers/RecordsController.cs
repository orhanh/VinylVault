using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private static readonly List<Record> records = new()
        {
            new Record { Id = 1, Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973 },
            new Record { Id = 2, Artist = "Daft Punk", Album = "Discovery", Year = 2001 },
            new Record { Id = 3, Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977 },
            new Record { Id = 4, Artist = "Nirvana", Album = "Nevermind", Year = 1991 },
            new Record { Id = 5, Artist = "Michael Jackson", Album = "Thriller", Year = 1982 },
            new Record { Id = 6, Artist = "The Beatles", Album = "Abbey Road", Year = 1969 },
            new Record { Id = 7, Artist = "Kendrick Lamar", Album = "To Pimp a Butterfly", Year = 2015 },
            new Record { Id = 8, Artist = "Radiohead", Album = "OK Computer", Year = 1997 },
            new Record { Id = 9, Artist = "Queen", Album = "A Night at the Opera", Year = 1975 },
            new Record { Id = 10, Artist = "The Prodigy", Album = "The Fat of the Land", Year = 1997 },
            new Record { Id = 11, Artist = "Kanye West", Album = "808s & heartbreak", Year = 2008 },
            new Record { Id = 12, Artist = "Tame Impala", Album = "Currents", Year = 2015 },
            new Record { Id = 13, Artist = "Bob Marley & The Wailers", Album = "Legend", Year = 1984 },
            new Record { Id = 14, Artist = "Bladee", Album = "Cold Visions", Year = 2024 },
            new Record { Id = 15, Artist = "Arctic Monkeys", Album = "AM", Year = 2013 }
        };

        // GET: api/records
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(records);
        }

        // GET api/records/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = records.FirstOrDefault(x => x.Id == id);
            return Ok(record);
        }

        // POST api/records
        [HttpPost]
        public IActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                records.Add(record);
                return Ok("Record added");
            }

            return BadRequest(ModelState);

        }

        // DELETE api/records/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Delete
        }
    }
}
