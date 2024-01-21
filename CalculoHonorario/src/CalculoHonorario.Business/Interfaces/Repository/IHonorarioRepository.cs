using CalculoHonorario.Business.Models;
using System.Linq.Expressions;

namespace CalculoHonorario.Business.Interfaces.Repository;

public interface IHonorarioRepository : IDisposable
{
    Task AdicionarAsync(Honorario honorario);
    Task AtualizarAsync(Honorario honorario);
    Task RemoverAsync(Honorario honorario);

    Task<Honorario> ObterPorIdAsync(Guid id);
    Task<List<Honorario>> ObterTodosAsync();
    Task<IEnumerable<Honorario>> Buscar(Expression<Func<Honorario, bool>> predicate);

    Task<int> SaveChanges();
}