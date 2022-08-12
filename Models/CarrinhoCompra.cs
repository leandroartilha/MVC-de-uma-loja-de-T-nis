using System;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Context;

namespace ProjetoAspNet.Models
{
	public class CarrinhoCompra
	{
		private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }

		public List<CarrinhoCompraItem> CarrinhoCompraItems{ get; set; }

		public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
			//define uma sessão
			ISession session =
				services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			//obtem um serviço do tipo do nosso contexto
			var context = services.GetService<AppDbContext>();

			//obtem ou gera o Id do carrinho
			string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

			//atribui o id do carrinho na Sessão
			session.SetString("CarrinhoId", carrinhoId);

			//retorna o carrinho com o contexto e o Id atribuido ou obtido
			return new CarrinhoCompra(context)
			{
				CarrinhoCompraId = carrinhoId
			};
        }

		public void AdicionarAoCarrinho(Tenis tenis)
        {
			var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
				s => s.Tenis.TenisId == tenis.TenisId &&
				s.CarrinhoCompraId == CarrinhoCompraId);

			if(carrinhoCompraItem == null)
            {
				carrinhoCompraItem = new CarrinhoCompraItem
				{
					CarrinhoCompraId = CarrinhoCompraId,
					Tenis = tenis,
					Quantidade = 1
				};
				_context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
				carrinhoCompraItem.Quantidade++;
            }
			_context.SaveChanges();
        }

		public int RemoverDoCarrinho(Tenis tenis)
        {
			var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
			s => s.Tenis.TenisId == tenis.TenisId &&
			s.CarrinhoCompraId == CarrinhoCompraId);

			var quantidadeLocal = 0;

			if(carrinhoCompraItem != null)
            {
				if(carrinhoCompraItem.Quantidade > 1)
                {
					carrinhoCompraItem.Quantidade--;
					quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
					_context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
			_context.SaveChanges();
			return quantidadeLocal;
		}

		public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
			return CarrinhoCompraItems ??
				(CarrinhoCompraItems =
					_context.CarrinhoCompraItens
					.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
					.Include(s => s.Tenis)
					.ToList());
        }

		public void LimparCarrinho()
        {
			var carrinhoItens = _context.CarrinhoCompraItens
					.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

			_context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
			_context.SaveChanges();
        }

		public decimal GetCarrinhoCompraTotal()
        {

			var total = _context.CarrinhoCompraItens
						.Where(c => CarrinhoCompraId == CarrinhoCompraId)
						.Select(c => c.Tenis.Preco * c.Quantidade).Sum();

			return total;
        }

	}
}

