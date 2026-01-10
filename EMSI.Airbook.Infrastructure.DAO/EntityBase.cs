namespace EMSI.Airbook.Infrastructure.DAO;

public abstract class EntityBase<T>
where T : struct
{
    public T Id { get; set; }
}