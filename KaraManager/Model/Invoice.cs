using System;
using System.Collections.Generic;

namespace KaraManager.Model
{
    public partial class Invoice
    {
        public int Bid { get; set; }
        public int Rid { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Timestarted { get; set; }
        public DateTime Timeended { get; set; }
        public TimeSpan Timeelapsed { get; set; }
        public int Othercost { get; set; }
        public int Totalcost { get; set; }
    }
}
