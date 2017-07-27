using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMvc.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsOnWarranty { get; set; }
        
    }
}
