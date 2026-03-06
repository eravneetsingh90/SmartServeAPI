namespace SmartServe.EFCore.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
