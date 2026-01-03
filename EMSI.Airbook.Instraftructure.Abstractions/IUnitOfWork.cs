namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}