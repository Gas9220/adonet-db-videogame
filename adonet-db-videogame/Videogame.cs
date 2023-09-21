using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        long Id {  get; set; }
        string Name { get; set; }
        string Overview { get; set; }
        DateTime ReleaseDate { get; set; }
        long SoftwareHouseId { get; set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }
    }
}
