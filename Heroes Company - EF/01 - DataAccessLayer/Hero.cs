using System;
using System.Collections.Generic;

#nullable disable

namespace Matrix
{
    public partial class Hero
    {
        public string HeroId { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public DateTime? TrainStartDate { get; set; }
        public string SuitColors { get; set; }
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }
        public string TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
