using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Vara
    {
        public int Id { get; set; }
        public int SubTypId { get; set; }

        public int Pris { get; set; }
        public string Beskrivning { get; set; }
        public int BildId { get; set; }
        public DateTime DatumInköpt { get; set; }
        public int StatusId { get; set; }


        public Vara(string beskrivning, int typid)
        {
            Beskrivning = beskrivning;
            SubTypId = typid;
        }

    }
}
