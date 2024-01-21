using CalculoHonorario.Business.Interfaces.Repository;
using CalculoHonorario.Business.Models;
using CalculoHonorario.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalculoHonorario.Data.Repository;

public class HonorarioRepository : IHonorarioRepository
{
    protected readonly ApplicationContext _context;

    public HonorarioRepository(ApplicationContext context) => _context = context;


    public async Task<Honorario> ObterPorIdAsync(Guid id) => await _context.Honorarios.FindAsync(id);

    public async Task<List<Honorario>> ObterTodosAsync() => await _context.Honorarios.ToListAsync();

    public async Task<IEnumerable<Honorario>> Buscar(Expression<Func<Honorario, bool>> predicate) => await _context.Honorarios.AsTracking().Where(predicate).ToListAsync();


    public async Task AdicionarAsync(Honorario honorario)
    {
        _context.Add(honorario);
        await SaveChanges();
    }

    public async Task AtualizarAsync(Honorario honorario)
    {
        _context.Honorarios.Update(honorario);
        await SaveChanges();
    }

    public async Task RemoverAsync(Honorario honorario)
    {
        _context.Honorarios.Remove(honorario);
        await SaveChanges();
    }

    public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

    public void Dispose() => _context?.Dispose();
}