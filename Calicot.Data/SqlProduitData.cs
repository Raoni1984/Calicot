using Calicot.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Calicot.Data
{
    public class SqlProduitData : IProduitData
    {
        private readonly CalicotDbContext db;

        public SqlProduitData(CalicotDbContext db)
        {
            this.db = db;
        }


        public int Commit()
        {
            return db.SaveChanges();
        }

        public Produit Create(Produit nouveauProduit)
        {
            db.Add(nouveauProduit);
            return nouveauProduit;
        }

        public Produit Delete(int id)
        {
            var prod = GetById(id);

            if (prod != null)
            {
                db.Produits.Remove(prod);
            }
            return prod;
        }

        public Produit GetById(int? id)
        {
            return db.Produits.Find(id);
        }

        public IEnumerable<Produit> GetByName(string name)
        {
            var query = from prod in db.Produits
                        where prod.Nom.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby prod.Nom
                        select prod;

            return query;
        }

        public Produit Update(Produit produitActualise)
        {
            var entity = db.Produits.Attach(produitActualise);

            entity.State = EntityState.Modified;

            return produitActualise;
        }
    }
}
