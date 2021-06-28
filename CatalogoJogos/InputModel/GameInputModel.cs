using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoJogos.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game name must contain between 3 and 100 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The name of the producer must contain between 3 to 100 characters")]
        public string Producer { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "The price must be at least 1 BRL and at most 1000 BRL")]
        public double Preco { get; set; }
    }
}
