using System;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAspNet.Controllers
{
	public class ContatoController : Controller
	{

		public IActionResult Index()
        {
			return View();
        }

	}
}

