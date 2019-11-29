using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Models
{
    public class PessoaDominio
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(11)")]
        public string CPF { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Sobre_Nome { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Sexo { get; set; }
        [Required]
        public DateTime DT_Nascimento { get; set; }
    }
}
