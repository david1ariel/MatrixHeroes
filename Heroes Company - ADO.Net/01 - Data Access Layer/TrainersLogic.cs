using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHeroes
{
    public class TrainersLogic
    {
        public TrainersLogic(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void Create(Trainer trainer)
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

            using SqlConnection connection = new SqlConnection("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert into Trainers(TrainerId, Name, Username, Password, Salt) " +
                "values(@TrainerId, @Name, @Username, @Password, @Salt)";
            command.Parameters.AddWithValue("@TrainerId", trainer.TrainerId);
            command.Parameters.AddWithValue("@Name", trainer.Name);
            command.Parameters.AddWithValue("@Username", trainer.Username);
            command.Parameters.AddWithValue("@Password", trainer.Password);
            command.Parameters.AddWithValue("@Salt", trainer.Salt);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Trainer GetTrainerByCredentials(Credentials credentials)
        {
            Trainer trainerToCheck = new Trainer();

            using SqlConnection connection = new SqlConnection("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Trainers where Username = @Username";
            command.Parameters.AddWithValue("@Username", credentials.Username);

            using SqlDataReader reader = command.ExecuteReader() ;
                while (reader.Read()) // (1) Go to next row, (2) return true if there is a legal row. If you got to EOF - return false
                {
                    trainerToCheck.TrainerId = Convert.ToString(reader["TrainerId"]);
                    trainerToCheck.Name = Convert.ToString(reader["Name"]);
                    trainerToCheck.Username = Convert.ToString(reader["Username"]);
                    trainerToCheck.Password = Convert.ToString(reader["Password"]);
                    trainerToCheck.Salt = Convert.ToString(reader["Salt"]);
                }

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

        public Trainer GetTrainerById(string trainerId)
        {
            Trainer trainer = new Trainer();

            using SqlConnection connection = new SqlConnection("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Trainers where TrainerId = @TrainerId";
            command.Parameters.AddWithValue("@TrainerId", trainerId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // (1) Go to next row, (2) return true if there is a legal row. If you got to EOF - return false
                {
                    trainer.TrainerId = Convert.ToString(reader["TrainerId"]);
                    trainer.Name = Convert.ToString(reader["Name"]);
                    trainer.Username = Convert.ToString(reader["Username"]);
                    trainer.Password = Convert.ToString(reader["Password"]);
                    trainer.Salt = Convert.ToString(reader["Salt"]);
                    

                }
                reader.Close();
            }

            return trainer;
        }

    }
}

