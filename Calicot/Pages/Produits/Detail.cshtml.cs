using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calicot.Core;
using Calicot.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calicot.Pages.Produits
{
    public class DetailModel : PageModel
    {
        private readonly IProduitData produitData;

        [TempData]
        public string Message { get; set; }
        public Produit Produit { get; set; }

        public DetailModel(IProduitData produitData)
        {
            this.produitData = produitData;
        }

        public IActionResult OnGet(int produitId)
        {
            Produit = produitData.GetById(produitId);

            if (Produit == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
