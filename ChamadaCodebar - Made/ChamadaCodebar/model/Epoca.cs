using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre
{
    public class Epoca
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Turno { get; set; } //0-Não Especificado 1-Matutino 2-Vespertino 3-Noturno
        public string NomeCurto { get; set; }
        public string NomeCompleto { get; set; }
        public bool Ativo { get; set; }
    }
}
