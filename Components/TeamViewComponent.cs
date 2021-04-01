using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;

        // Constructor
        public TeamViewComponent(BowlingLeagueContext context)
        {
            _context = context;
        }
        
        // Setting up the data for the view component
        public IViewComponentResult Invoke()
        {
            // building a viewbag component, creating a nullable property; teamname refers to the teamname in the route data(the endpoint in startup.cs)
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(_context.Teams
                .Distinct()
                .OrderBy(t => t));
        }
    }
}
