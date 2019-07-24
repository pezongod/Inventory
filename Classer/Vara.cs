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
        public int TypId { get; set; }
        public string TypNamn { get; set; }
        public int SubTypId { get; set; }
<<<<<<< HEAD

=======
        public string SubTypNamn { get; set; }
>>>>>>> 16927fb67314891850ec26e1ebc8cf7b9d4c723b
        public int Pris { get; set; }
        public string Beskrivning { get; set; }
        public int BildId { get; set; }
        public DateTime DatumInköpt { get; set; }
        public int StatusId { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 16927fb67314891850ec26e1ebc8cf7b9d4c723b

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
