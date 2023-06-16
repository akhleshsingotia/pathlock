using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementApp
{
    public class Guest
    {
        public int GuestId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
