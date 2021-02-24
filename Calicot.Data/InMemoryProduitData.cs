using System;
using System.Collections.Generic;
using System.Linq;
using Calicot.Core;

namespace Calicot.Data
{
    public class InMemoryProduitData : IProduitData
    {
        readonly List<Produit> produits;

        public InMemoryProduitData()
        {
            produits = new List<Produit>()
            {
                new Produit { Id = 1, Nom = "Aerographe", Prix = 59.90, Description = "pistolet à peinture miniature", Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/PaascheAirbrush.jpg/1024px-PaascheAirbrush.jpg" },
                new Produit { Id = 2, Nom = "Marteau ", Prix = 9.90, Description = "Un marteau est un outil percuteur, servant par exemple à aplatir un morceau de fer ou à enfoncer un clou.", Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Claw-hammer.jpg/1920px-Claw-hammer.jpg" },
                new Produit { Id = 3, Nom = "Visseuse", Prix = 119.90, Description = "une machine-outil qui permet de visser et dévisser, assisté par un moteur (électrique), se basant sur le même principe que la perceuse, et possédant un limiteur de couple.", Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Screwgun.jpg/1280px-Screwgun.jpg" }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Produit Create(Produit nouveauProduit)
        {
            produits.Add(nouveauProduit);

            nouveauProduit.Id = produits.Max(p => p.Id) + 1;

            return nouveauProduit;
        }

        public Produit Delete(int id)
        {
            var produit = produits.FirstOrDefault(p => p.Id == id);

            if(produit != null)
            {
                produits.Remove(produit);
            }
            return produit;
        }

        public Produit GetById(int? id)
        {
            return produits.SingleOrDefault<Produit>(produit => produit.Id == id);
        }

        public IEnumerable<Produit> GetByName(string name)
        {
            return from produit in produits
                   where string.IsNullOrEmpty(name) || produit.Nom.StartsWith(name)
                   orderby produit.Nom
                   select produit;
        }

        public Produit Update(Produit produitActualise)
        {
            var produit = produits.SingleOrDefault(r => r.Id == produitActualise.Id);

            if (produit != null)
            {
                produit.Nom = produitActualise.Nom;
                produit.Description = produitActualise.Description;
                produit.Prix = produitActualise.Prix;
                produit.Photo = produitActualise.Photo;
            }
            return produit;
        }
    }
}
