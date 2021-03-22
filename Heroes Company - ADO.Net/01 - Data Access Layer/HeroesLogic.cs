using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHeroes
{
    public class HeroesLogic
    {
        public void CreateHero(Hero hero)
        {
            using SqlConnection connection = new SqlConnection("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert into heroes(HeroId, Name, Ability, TrainStartDate, SuitColors, StartingPower, CurrentPower, TrainerId) " +
                "values(@HeroId, @Name, @Ability, @TrainStartDate, @SuitColors, @StartingPower, @CurrentPower, @TrainerId)";
            command.Parameters.AddWithValue("@HeroId", hero.HeroId);
            command.Parameters.AddWithValue("@Name", hero.Name);
            command.Parameters.AddWithValue("@Ability", hero.Ability);
            command.Parameters.AddWithValue("@TrainStartDate", hero.TrainStartDate);
            command.Parameters.AddWithValue("@SuitColors", hero.SuitColors);
            command.Parameters.AddWithValue("@StartingPower", hero.StartingPower);
            command.Parameters.AddWithValue("@CurrentPower", hero.CurrentPower);
            command.Parameters.AddWithValue("@TrainerId", hero.TrainerId);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Hero GetHeroById(string heroId)
        {
            Hero hero = new Hero();

            using SqlConnection connection = new SqlConnection("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Heroes where HeroId = @HeroId";
            command.Parameters.AddWithValue("@HeroId", heroId);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                hero.HeroId = Convert.ToString(reader["HeroId"]);
                hero.Name = Convert.ToString(reader["Name"]);
                hero.Ability = Convert.ToString(reader["Ability"]);
                hero.TrainStartDate = Convert.ToDateTime(reader["TrainStartDate"]);
                hero.SuitColors = Convert.ToString(reader["SuitColors"]);
                hero.StartingPower = Convert.ToDecimal(reader["StartingPower"]);
                hero.CurrentPower = Convert.ToDecimal(reader["CurrentPower"]);
                hero.TrainerId = Convert.ToString(reader["TrainerId"]);
            }

            return hero;
        }

        public List<Hero> GetAllHeroesByTrainerId(string trainerId)
        {
            List<Hero> heroes = new List<Hero>();


        }


    }
}
