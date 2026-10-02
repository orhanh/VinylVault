using Mapster;
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
            new Record { Id = Guid.NewGuid(), Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973, IsGolden = true },
            new Record { Id = Guid.NewGuid(), Artist = "Daft Punk", Album = "Random Access Memories", Year = 2013 },
            new Record { Id = Guid.NewGuid(), Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977, IsGolden = true },
            new Record { Id = Guid.NewGuid(), Artist = "Nirvana", Album = "Nevermind", Year = 1991 },
            new Record { Id = Guid.NewGuid(), Artist = "Michael Jackson", Album = "Thriller", Year = 1982, IsGolden = true },
            new Record { Id = Guid.NewGuid(), Artist = "The Beatles", Album = "Abbey Road", Year = 1969 },
            new Record { Id = Guid.NewGuid(), Artist = "Kendrick Lamar", Album = "To Pimp a Butterfly", Year = 2015 },
            new Record { Id = Guid.NewGuid(), Artist = "Radiohead", Album = "OK Computer", Year = 1997 },
            new Record { Id = Guid.NewGuid(), Artist = "Queen", Album = "A Night at the Opera", Year = 1975 },
            new Record { Id = Guid.NewGuid(), Artist = "The Prodigy", Album = "The Fat of the Land", Year = 1997 },
            new Record { Id = Guid.NewGuid(), Artist = "Kanye West", Album = "808s & heartbreak", Year = 2008 },
            new Record { Id = Guid.NewGuid(), Artist = "Tame Impala", Album = "Currents", Year = 2015 },
            new Record { Id = Guid.NewGuid(), Artist = "Bob Marley & The Wailers", Album = "Legend", Year = 1984 },
            new Record { Id = Guid.NewGuid(), Artist = "Kid Cudi", Album = "Man on the Moon", Year = 2009 },
            new Record { Id = Guid.NewGuid(), Artist = "Arctic Monkeys", Album = "AM", Year = 2013 },
            new Record { Id = Guid.NewGuid(), Artist = "Amy Winehouse", Album = "Back to Black", Year = 2006 },
            new Record { Id = Guid.NewGuid(), Artist = "Led Zeppelin", Album = "IV", Year = 1971 },
            new Record { Id = Guid.NewGuid(), Artist = "Tyler, The Creator", Album = "IGOR", Year = 2019 }
        };

        // GET: api/records
        [HttpGet]
        public IActionResult GetAll()
        {
            var recordDtos = records.Where(r => r.IsGolden is false).Adapt<List<RecordReadDto>>();

            return Ok(recordDtos);
        }

        // GET api/records/golden
        [Authorize]
        [HttpGet("golden")]
        public IActionResult GetGoldenRecords()
        {
            var recordDtos = records.Where(r => r.IsGolden).Adapt<List<RecordReadDto>>();

            return Ok(recordDtos);
        }
    }
}
