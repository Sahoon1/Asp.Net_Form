﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string age, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ModelState.AddModelError("username", "User name is required");
            }

            if (string.IsNullOrWhiteSpace(age))
            {
                ModelState.AddModelError("age", "User age is required");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("email", "User email is required");
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                ModelState.AddModelError("email", "Invalid Email");
            }

            if (ModelState.IsValid)
            {
                ViewData["SuccessMessage"] = "<script>alert('Thank you for submitting the form');</script>";
                ModelState.Clear();
            }

            return View();
        }
    }
}

      

