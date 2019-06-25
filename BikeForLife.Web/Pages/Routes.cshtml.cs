using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeForLife.Dal;
using BikeForLife.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeForLife.Web.Pages
{
    public class RoutesModel : PageModel
    {
        [BindProperty]
        public BikeRoute BikeRoute { get; set; }
        public List<BikeRoute> BikeRoutes { get; set; } = new List<BikeRoute>();
        public IActionResult OnGet()
        {
            return InitializeData();
        }

        public IActionResult OnPost()
        {
            
            return InitializeData();
        }

        public IActionResult InitializeData()
        {
            BikeRouteRepository bikeRouteRepository = new BikeRouteRepository();
            try
            {
                BikeRoutes = bikeRouteRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Page();
        }
    }
}