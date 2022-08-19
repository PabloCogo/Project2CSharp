using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class Product: Entity
    {
        [Required,MaxLength(45)]
        public string Product_title { get; set; }
        [Required, MaxLength(13)]
        public string Barcode { get; set; }
    }
}
