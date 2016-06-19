using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre.model
{
    public class DiaAula
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public double Ch { get; set; } //Carga horária
        public int IdEpoca { get; set; }
    }
}
