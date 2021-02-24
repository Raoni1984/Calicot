using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calicot.Core;
using Calicot.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calicot.Pages.Produits
{
    public class EditerModel : PageModel
    {

        private readonly IProduitData produitData;

        [BindProperty]
        public Produit Produit { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditerModel(IProduitData produitData)
        {
            this.produitData = produitData;
        }

        public IActionResult OnGet(int? produitId)
        {
            if (produitId.HasValue)
            {
                Produit = produitData.GetById(produitId.Value);
            }
            else
            {
                Produit = new Produit();
            }

            if (Produit == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Produit.Id > 0)
            {
                produitData.Update(Produit);
            }
            else
            {
                produitData.Create(Produit);
            }

            produitData.Commit();

            TempData["Message"] = "Produit Sauvegardé!";
            return RedirectToPage("./Detail", new { produitId = Produit.Id });

        }
    }
}
