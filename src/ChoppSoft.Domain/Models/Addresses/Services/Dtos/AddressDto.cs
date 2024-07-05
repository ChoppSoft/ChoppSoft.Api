using System.ComponentModel.DataAnnotations;

namespace ChoppSoft.Domain.Models.Addresses.Services.Dtos
{
    public record AddressDto([Required(ErrorMessage = "É necessário informar o código do usuário.")] 
                             Guid customerid,
                             [Required(ErrorMessage = "É necessário informar a rua.")]
                             string street,
                             [Required(ErrorMessage = "É necessário informar o número.")]
                             string number,
                             string additionalinformation,
                             [Required(ErrorMessage = "É necessário informar o bairro.")]
                             string district,
                             [Required(ErrorMessage = "É necessário informar a cidade.")]
                             string city,
                             [Required(ErrorMessage = "É necessário informar a sigla do estado.")]
                             string state,
                             [Required(ErrorMessage = "É necessário informar o CEP.")]
                             string postalcode,
                             [Required(ErrorMessage = "É necessário informar o país.")]
                             string country);
}
