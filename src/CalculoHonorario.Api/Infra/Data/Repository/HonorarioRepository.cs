using CalculoHonorario.Api.Domain.Interface;
using CalculoHonorario.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalculoHonorario.Api.Infra.Data.Repository;

public class HonorarioRepository : IHonorarioRepository
{
    protected readonly ApplicationContext _context;

    public HonorarioRepository(ApplicationContext context) => _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Honorario> ObterPorIdAsync(Guid id) => await _context.Honorarios.FindAsync(id);

    public async Task<List<Honorario>> ObterTodosAsync() => await _context.Honorarios.OrderByDescending(x => x.CadastradoEm).ToListAsync();

    public async Task<IEnumerable<Honorario>> Buscar(Expression<Func<Honorario, bool>> predicate) => await _context.Honorarios.AsTracking().Where(predicate).ToListAsync();


    public async Task AdicionarAsync(Honorario honorario) => await _context.AddAsync(honorario);

    public void Atualizar(Honorario honorario) => _context.Honorarios.Update(honorario);

    public void Remover(Honorario honorario) => _context.Honorarios.Remove(honorario);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) => _context?.Dispose();
}