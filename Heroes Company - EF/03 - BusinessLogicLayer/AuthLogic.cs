using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class AuthLogic : BaseLogic
    {
        public AuthLogic(MatrixHeroesContext db):base(db) { }

        public bool isTrainerNameExists(string userName)
        {
            return db.Trainers.Any(u => u.Username == userName);
        }

        public TrainerModel Register(TrainerModel trainer)
        {
            trainer.TrainerId = Guid.NewGuid().ToString();
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            trainer.Salt = Convert.ToBase64String(salt);
            trainer.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: trainer.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Trainer trainerToAdd = trainer.ConvertToTrainer();
            db.Trainers.Add(trainerToAdd);
            db.SaveChanges();
            trainer.TrainerId = trainerToAdd.TrainerId;
            return trainer;
        }
        
        public TrainerModel GetTrainerByCredentials(CredentialsModel credentials)
        {
            TrainerModel trainerToCheck = new TrainerModel(db.Trainers.SingleOrDefault(p => p.Username == credentials.Username));

            credentials.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: credentials.Password,
            salt: Convert.FromBase64String(trainerToCheck.Salt),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            if (credentials.Password == trainerToCheck.Password)
                return trainerToCheck;

            return null;
        }
    }
}
