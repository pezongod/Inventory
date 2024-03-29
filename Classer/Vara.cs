﻿using System;

namespace Inventory
{
    public class Vara
    {
        public int Id { get; set; }
        public int TypId { get; set; }
        public string TypNamn { get; set; }
        public int SubTypId { get; set; }

        public string SubTypNamn { get; set; }

        public int? Pris { get; set; } = null;
        public string Beskrivning { get; set; } = null;
        public int? BildId { get; set; }
        public DateTime? DatumInköpt { get; set; }
        public int? StatusId { get; set; } = null;
        public string StatusNamn { get; set; } = null;

        public Vara(string beskrivning, int typid)
        {
            Beskrivning = beskrivning;
            SubTypId = typid;
        }

        public Vara()
        {
        }
    }
}