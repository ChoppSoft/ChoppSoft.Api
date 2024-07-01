namespace ChoppSoft.Domain.Models.Locations.Dtos
{
    public class ViaCepResultDto
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
    }
}
