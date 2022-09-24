﻿using walks.Models.Domain;

namespace walks.Models.Dto
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        //Navigation Property

        public IEnumerable<WalkDto> Walks { get; set; }
    }
}