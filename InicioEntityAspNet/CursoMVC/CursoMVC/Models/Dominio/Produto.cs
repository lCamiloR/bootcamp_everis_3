using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models.Dominio
{
    public class Produto : ClasseDeDominio
    {
        public string Descricao { get; set; }
        public int Quantidade { set; get; }
        public int CategoriaId { set; get; }
        public Categoria CategoriaProduto { get; set; }

    }
}
