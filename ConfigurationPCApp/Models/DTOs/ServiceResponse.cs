namespace PcBuilderApp.Models.DTOs
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

    }
}
