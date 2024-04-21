namespace CalculoHonorario.Api.Domain.Interface;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
