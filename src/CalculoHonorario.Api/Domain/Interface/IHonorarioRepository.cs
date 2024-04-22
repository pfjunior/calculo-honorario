using CalculoHonorario.Api.Domain.Entities;
using System.Linq.Expressions;

namespace CalculoHonorario.Api.Domain.Interface;

public interface IHonorarioRepository : IDisposable
{
    IUnitOfWork UnitOfWork { get; }

    Task AdicionarAsync(Honorario honorario);
    void Atualizar(Honorario honorario);
    void Remover(Honorario honorario);

    Task<Honorario> ObterPorIdAsync(Guid id);
    Task<List<Honorario>> ObterTodosAsync();
    Task<IEnumerable<Honorario>> Buscar(Expression<Func<Honorario, bool>> predicate);
}
