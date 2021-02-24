using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calicot.Core;
using Calicot.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Calicot.Pages.Produits
{
    public class ListeModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IProduitData produitData;

        public IEnumerable<Produit> Produits { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RechercheNom { get; set; }

        public ListeModel(IConfiguration config, IProduitData produitData)
        {
            this.config = config;
            this.produitData = produitData;
        }

        public void OnGet()
        {
            Produits = produitData.GetByName(RechercheNom);
        }
    }
}
