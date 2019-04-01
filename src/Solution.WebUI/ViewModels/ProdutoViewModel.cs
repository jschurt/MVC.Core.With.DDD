using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.WebUI.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public long ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(250, ErrorMessage = "Maximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "9999999999")]
        [Required(ErrorMessage = "Preencha o campo valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }

        public long ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }


    } //class
} //namaspace
