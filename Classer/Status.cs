using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Classer
{
    public class Status: IEntity
    {
        public int Id { get; set; }
        public string Namn { get; set; }
    }
}
