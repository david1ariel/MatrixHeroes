using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class HeroesLogic : BaseLogic
    {
        
        public HeroesLogic(MatrixHeroesContext db) : base(db) { }

        public List<HeroModel> GetAllHeroesByTrainerId(string trainerId)
        {
            List<HeroModel> allHeroesByTrainerId = db.Heroes
                .Where(p => p.TrainerId == trainerId)
                .Select(p => new HeroModel(p))
                .ToList();
            return allHeroesByTrainerId;
        }

        public HeroModel AddHero(HeroModel hero)
        {
            hero.HeroId = Guid.NewGuid().ToString();
            Hero heroToAdd = hero.ConvertToHero();
            db.Heroes.Add(heroToAdd);
            db.SaveChanges();
            hero.HeroId = heroToAdd.HeroId;
            return hero;
        }

        public void DeleteHero(string heroId)
        {
            Hero heroToDelete = db.Heroes.SingleOrDefault(p => p.HeroId == heroId);
            db.Heroes.Remove(heroToDelete);
            db.SaveChanges();
        }

        
    }
}
