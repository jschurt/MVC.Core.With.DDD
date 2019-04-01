using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.WebUI.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Maximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(150, ErrorMessage = "Maximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(100, ErrorMessage = "Maximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email valido")]
        [Display(Name = "E-mail")]

        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }

    } //namespace
} //class
