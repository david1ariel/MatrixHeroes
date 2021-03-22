using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class TrainerModel : ICloneable
    {
        public string TrainerId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Missing Name!")]
        [MinLength(2, ErrorMessage = "Must be at least two chars")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Must be at least two chars")]
        public string Username { get; set; }

        [PasswordConstraint]
        public string Password { get; set; }

        public string Salt { get; set; }
        public string JwtToken { get; set; }

        public TrainerModel() { }

        public TrainerModel(Trainer trainer)
        {
            TrainerId = trainer.TrainerId;
            Name = trainer.Name;
            Username = trainer.Username;
            Password = trainer.Password;
            Salt = trainer.Salt;
        }

        public Trainer ConvertToTrainer()
        {
            return new Trainer
            {
                TrainerId = TrainerId,
                Name = Name,
                Username = Username,
                Password = Password,
                Salt = Salt,
            };
        }

        public object Clone()
        {
            return new TrainerModel
            {
                TrainerId = TrainerId,
                Name = Name,
                Username = Username,
                Password = Password,
                Salt = Salt,
                JwtToken = JwtToken
            };
        }
    }
}
