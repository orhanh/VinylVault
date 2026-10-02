using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylVault.Shared.DTOs;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private static readonly List<Record> records = new()
        {
            new Record { Id = Guid.NewGuid(), Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973 },
            new Record { Id = Guid.NewGuid(), Artist = "Daft Punk", Album = "Discovery", Year = 2001 },
            new Record { Id = Guid.NewGuid(), Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977 },
            new Record { Id = Guid.NewGuid(), Artist = "Nirvana", Album = "Nevermind", Year = 1991 },
            new Record { Id = Guid.NewGuid(), Artist = "Michael Jackson", Album = "Thriller", Year = 1982 },
            new Record { Id = Guid.NewGuid(), Artist = "The Beatles", Album = "Abbey Road", Year = 1969 },
            new Record { Id = Guid.NewGuid(), Artist = "Kendrick Lamar", Album = "To Pimp a Butterfly", Year = 2015 },
            new Record { Id = Guid.NewGuid(), Artist = "Radiohead", Album = "OK Computer", Year = 1997 },
            new Record { Id = Guid.NewGuid(), Artist = "Queen", Album = "A Night at the Opera", Year = 1975 },
            new Record { Id = Guid.NewGuid(), Artist = "The Prodigy", Album = "The Fat of the Land", Year = 1997 },
            new Record { Id = Guid.NewGuid(), Artist = "Kanye West", Album = "808s & heartbreak", Year = 2008 },
            new Record { Id = Guid.NewGuid(), Artist = "Tame Impala", Album = "Currents", Year = 2015 },
            new Record { Id = Guid.NewGuid(), Artist = "Bob Marley & The Wailers", Album = "Legend", Year = 1984 },
            new Record { Id = Guid.NewGuid(), Artist = "Kid Cudi", Album = "Man on the Moon", Year = 2009 },
            new Record { Id = Guid.NewGuid(), Artist = "Arctic Monkeys", Album = "AM", Year = 2013 }
        };

        private static readonly List<Record> goldenRecords = new()
        {
            new Record { Id = Guid.NewGuid(), Artist = "Michael Jackson", Album = "Thriller", Year = 1982 },
            new Record { Id = Guid.NewGuid(), Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973 },
            new Record { Id = Guid.NewGuid(), Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977 }
        };

        // GET: api/records
        [HttpGet]
        public IActionResult GetAll()
        {
            var recordDtos = records.Select(r => new RecordReadDto
            {
                Id = r.Id,
                Artist = r.Artist,
                Album = r.Album,
                Year = r.Year
            }).ToList();

            return Ok(recordDtos);
        }

        // GET api/records/golden-records
        [Authorize]
        [HttpGet("Golden")]
        public IActionResult GetGoldenRecords()
        {
            var recordDtos = goldenRecords.Select(r => new RecordReadDto
            {
                Id = r.Id,
                Artist = r.Artist,
                Album = r.Album,
                Year = r.Year
            }).ToList();

            return Ok(recordDtos);
        }

        // GET api/records/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var record = records.FirstOrDefault(x => x.Id == id);
            if (record == null)
                return NotFound();

            var dto = new RecordReadDto
            {
                Id = record.Id,
                Artist = record.Artist,
                Album = record.Album,
                Year = record.Year
            };

            return Ok(dto);
        }
    }
}
