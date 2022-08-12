using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet.Models;
using ProjetoAspNet.Repositories.Interfaces;
using ProjetoAspNet.ViewModels;

namespace ProjetoAspNet.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        private readonly ITenisRepository _tenisRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ITenisRepository tenisRepository, CarrinhoCompra carrinhoCompra)
        {
            _tenisRepository = tenisRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int tenisId)
        {
            var tenisSelecionado = _tenisRepository.Tenis.FirstOrDefault(p => p.TenisId == tenisId);

            if(tenisSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(tenisSelecionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra(int tenisId)
        {
            var tenisSelecionado = _tenisRepository.Tenis.FirstOrDefault(p => p.TenisId == tenisId);

            if (tenisSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(tenisSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}

