using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaCodebar.model
{
    public class RegistroPresenca
    {
        public int Id { get; set; }
        public int Valor { get; set; } //0-Sem Marcar 1-Faltou 2-Falta Justificada 3-Presente
        public string Obs { get; set; }
        public DateTime Momento { get; set; }
        public int IdAluno { get; set; }
        public int IdDiaAula { get; set; }
    }
}
