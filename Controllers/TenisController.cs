using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet.Models;
using ProjetoAspNet.Repositories.Interfaces;
using ProjetoAspNet.ViewModels;

namespace ProjetoAspNet.Controllers
{
	public class TenisController : Controller
	{

		private readonly ITenisRepository _tenisRepository;

        public TenisController(ITenisRepository tenisRepository)
        {
            _tenisRepository = tenisRepository;
        }

        public IActionResult ListarTenis(string categoria)
        {

            IEnumerable<Tenis> tenis;

            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                tenis = _tenisRepository.Tenis.OrderBy(t => t.TenisId);
                categoriaAtual = "Todos os tênis";
            }
            else
                {
                //   if (categoria == "Esporte")
                //   {
                //      tenis = _tenisRepository.Tenis
                ///         .Where(t => t.Categoria.CategoriaNome.Equals("Esporte"))
                //      .OrderBy(t => t.TenisNome);
                //}
                // else if (categoria == "Formal")
                // {
                //     tenis = _tenisRepository.Tenis
                //         .Where(t => t.Categoria.CategoriaNome.Equals("Formal"))
                //         .OrderBy(t => t.TenisNome);
                //  }
                //   else
                //  {
                //     tenis = _tenisRepository.Tenis
                //        .Where(t => t.Categoria.CategoriaNome.Equals("Casual"))
                //         .OrderBy(t => t.TenisNome);
                // }

                tenis = _tenisRepository.Tenis
                    .Where(t => t.Categoria.CategoriaNome == categoria)
                    .OrderBy(c => c.TenisNome);

                categoriaAtual = categoria;
            }
            var listarTenisViewModel = new ListarTenisViewModel
            {
                Tenis = tenis,
                CategoriaAtual = categoriaAtual
            };

            return View(listarTenisViewModel);
            

        }

        public IActionResult Details(int tenisId)
        {
            var tenis = _tenisRepository.Tenis.FirstOrDefault(t => t.TenisId == tenisId);
            return View(tenis);
        }
	}
}

