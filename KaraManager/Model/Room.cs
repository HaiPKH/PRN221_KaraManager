using System;
using System.Collections.Generic;

namespace KaraManager.Model
{
    public partial class Room
    {
        public int Rid { get; set; }
        public string Name { get; set; } = null!;
        public int Priceperhour { get; set; }
        public bool Isused { get; set; }
        public DateTime? Timestarted { get; set; }
    }
}
