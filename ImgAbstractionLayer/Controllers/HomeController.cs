﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}