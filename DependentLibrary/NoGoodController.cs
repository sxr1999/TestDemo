using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependentLibrary
{
    public class NoGoodController : Controller
    {
        public IActionResult Index()
        {
            return Ok("We don't want to load this controller.");
        }

    }
}
