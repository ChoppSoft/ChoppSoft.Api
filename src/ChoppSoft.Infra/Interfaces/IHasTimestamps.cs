namespace ChoppSoft.Infra.Interfaces
{
    public interface IHasTimestamps
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
