using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre
{
    public class MatriculaProjeto
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public int IdProjeto { get; set; }
        public bool Ativo { get; set; }
    }
}
