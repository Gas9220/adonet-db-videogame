﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }

        public override string ToString()
        {
            return $@"
Name: {Name}
Overview: {Overview}
Release date: {ReleaseDate}
Software house id: {SoftwareHouseId}
";
        }
    }
}
