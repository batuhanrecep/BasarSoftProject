using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Door:IEntity
    {

        public int DoorId { get; set; }
        public string DoorName { get; set; }
        public double DoorX { get; set; }
        public double DoorY { get; set; }

    }
}
