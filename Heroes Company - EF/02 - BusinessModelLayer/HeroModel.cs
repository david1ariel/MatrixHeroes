using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{

    public class HeroModel
    {

        public string HeroId { get; set; }

        [Required(ErrorMessage = "Missing Name!")]
        [MinLength(2, ErrorMessage = "Must be at least two chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Missing Ability!")]
        public string Ability { get; set; }

        [Required(ErrorMessage = "Missing Trainng Start Date!")]
        public DateTime? TrainStartDate { get; set; }

        [Required(ErrorMessage = "Missing Suit Colors!")]
        public string SuitColors { get; set; }

        [Required(ErrorMessage = "Missing Starting Power!")]
        public decimal StartingPower { get; set; }

        [Required(ErrorMessage = "Missing Current Power!")]
        public decimal CurrentPower { get; set; }

        [Required(ErrorMessage = "Missing Trainer ID!")]
        public string TrainerId { get; set; }

        public HeroModel() { }

        public HeroModel(Hero hero)
        {
            HeroId = hero.HeroId;
            Name = hero.Name;
            Ability = hero.Ability;
            TrainStartDate = hero.TrainStartDate;
            SuitColors = hero.SuitColors;
            StartingPower = hero.StartingPower;
            CurrentPower = hero.CurrentPower;
            TrainerId = hero.TrainerId;
        }

        public Hero ConvertToHero()
        {
            return new Hero
            {
                HeroId = HeroId,
                Name = Name,
                Ability = Ability,
                TrainStartDate = TrainStartDate,
                SuitColors = SuitColors,
                StartingPower = StartingPower,
                CurrentPower = CurrentPower,
                TrainerId = TrainerId,
            };
        }
    }
}
