namespace ChoppSoft.Api.ViewModels
{
    public class ResourceViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public decimal Capacity { get; set; }
        public bool IsOwned { get; set; }
    }
}
