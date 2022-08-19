using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório"), MaxLength(45, ErrorMessage = "O nome do produto deve ter no máximo 45 caracteres")]
        public string Product_title { get; set; }
        [Required(ErrorMessage = "O código de barras do produto é obrigatório"), MaxLength(13, ErrorMessage = "O código de barras deve ter no máximo 13 caracteres")]
        public string Barcode { get; set; }
    }
}
