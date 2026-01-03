namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface ISupportsWriteRepository<T, in TKey>
    where T : class
    where TKey : struct
{ 
    Task<T> AddAsync(T flight);
    void Update(T flight);
    Task DeleteAsync(TKey id);
}