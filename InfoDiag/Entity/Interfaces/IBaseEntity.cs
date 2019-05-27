namespace Entity
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}