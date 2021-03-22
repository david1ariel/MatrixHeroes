using System;
using System.Collections.Generic;

#nullable disable

namespace Matrix
{
    public partial class Trainer
    {
        public Trainer()
        {
            Heroes = new HashSet<Hero>();
        }

        public string TrainerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
