using boxcalcui2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Diagnostics;

namespace boxcalcui2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index(int result, int totalRoutes, int currentRoute, int boxes, int bags)
        {
            var viewModel = View(new ViewModel());
            if (totalRoutes == 0)
            {
                viewModel = View(new ViewModel
                {
                    Text = "Enter the number of routes"
                });
            }
            else
            {
                if (result == 5)
                {
                    boxes++;
                }
                else
                {
                    int quotient = result / 6;
                    boxes = boxes + quotient;

                    int remainder = result % 6;
                    int bagQuotient = remainder / 2;
                    int bagRemainder = remainder % 2;
                    int bagsToAdd = bagQuotient + bagRemainder;
                    bags = bags + bagsToAdd;
                }

                currentRoute++;
                if (currentRoute <= totalRoutes + 1 ) {
                    viewModel = View(new ViewModel
                    {
                        Text = "Enter the number of meals for route " + currentRoute,
                        TotalRoutes = totalRoutes,
                        CurrentRoute = currentRoute,
                        Boxes = boxes,
                        Bags = bags,
                        Message = "Your estimated needs are " + boxes + " boxes and " + bags + " bags"
                    });
                } 
            }

            return viewModel;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}