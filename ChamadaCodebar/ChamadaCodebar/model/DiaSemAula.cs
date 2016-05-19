using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaCodebar.model
{
    public class DiaSemAula
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public int IdEpoca { get; set; }
        public int TipoDia { get; set; } //0-Sem especificar 1-Sábado 2-Domingo 3-Feriado 4-Recesso 5-Atividades internas
    }
}
