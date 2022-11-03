﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UitViettour.Controllers
{
	[Route("users")]
	public class UserController : Controller
	{
		// GET: users/signup
		[HttpGet("signup")]
		public ActionResult SignUp()
		{
			return View();
		}

		// POST: users/signup
		[HttpPost("signup")]
		[ValidateAntiForgeryToken]
		public ActionResult SignUp(IFormCollection collection)
		{
			bool err = false;
			//Thêm hàm check sau
			if (err)
			{
				return View(collection);
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

		// GET: users/login
		[HttpGet("login")]
		public ActionResult LogIn()
		{
			return View();
		}

		// POST: users/login
		[HttpPost("login")]
		[ValidateAntiForgeryToken]
		public ActionResult LogIn(IFormCollection collection)
		{
			bool err = false;
			//Thêm hàm check sau
			if (err)
			{
				return View(collection);
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

		// GET: users //GetAllUser
		[HttpGet("")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: users/5
		[HttpGet("{id}")]
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: users/5/edit
		[HttpGet("{id}/edit")]
		public ActionResult Edit(int id)
		{
			return View();
		}

		// PUT: users/5
		[HttpPut("{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			bool err = false;
			//Thêm hàm check sau
			if (err)
			{
				return View(collection);
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

		// Delete: users/5
		[HttpDelete("{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			bool err = false;
			//Thêm hàm check sau
			if (err)
			{
				return View();
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}
	}
}