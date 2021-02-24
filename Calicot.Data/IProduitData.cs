using System.Collections.Generic;
using System.Text;
using Calicot.Core;

namespace Calicot.Data
{
    public interface IProduitData
    {
        IEnumerable<Produit> GetByName(string name);
        Produit GetById(int? id);

        Produit Update(Produit produitActualise);
        Produit Create(Produit nouveauProduit);
        Produit Delete(int id);

        int Commit();
    }
}
