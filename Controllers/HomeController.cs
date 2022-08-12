using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet.Models;
using ProjetoAspNet.Repositories.Interfaces;
using ProjetoAspNet.ViewModels;

namespace ProjetoAspNet.Controllers;

public class HomeController : Controller
{

    private readonly ITenisRepository _tenisRepository;

    public HomeController(ITenisRepository tenisRepository)
    {
        _tenisRepository = tenisRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            TenisPreferidos = _tenisRepository.TenisPreferidos
    };

        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

