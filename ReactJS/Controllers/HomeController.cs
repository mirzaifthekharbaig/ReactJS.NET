﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ReactJS.Models;

namespace ReactJS.Controllers
{
	public class HomeController : Controller
	{
		private static readonly IList<CommentModel> _comments;
		
		static HomeController()
		{
			_comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
		}

		public ActionResult Index()
		{
			return View();
		}

		[OutputCache(Location = OutputCacheLocation.None)]
		public ActionResult Comments()
		{
			return Json(_comments, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddComment(CommentModel comment)
		{
			_comments.Add(comment);
			return Content("Success :)");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}