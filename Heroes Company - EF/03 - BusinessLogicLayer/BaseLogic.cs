using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public abstract class BaseLogic : IDisposable
    {
        protected readonly MatrixHeroesContext db;

        public BaseLogic(MatrixHeroesContext db)
        {
            this.db = db;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
