using System;
using ProjetoAspNet.Models;

namespace ProjetoAspNet.Repositories.Interfaces
{
	public interface ITenisRepository
	{
		IEnumerable<Tenis> Tenis { get; }

		IEnumerable<Tenis> TenisPreferidos { get; }

		Tenis GetTenisById(int tenisId);
	}
}

