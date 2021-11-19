using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models.Dominio
{
    public class Categoria : ClasseDeDominio
    {
        public string Descricao { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
