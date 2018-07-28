using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto03_Eventos.Models
{
    public class Evento
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required]        
        public string Local { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        public ICollection<Participante> Participantes { get; set; }
                
    }
}
