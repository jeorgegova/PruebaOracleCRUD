using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaOracleCRUD.Entidades
{
    public class E_Productos
    {
        public int Codigo_pr {  get; set; }
        public string Description_pr { get; set; }
        public string Marca_pr { get; set; }
        public string Medida_pr { get; set; }
        public float Stock_actual { get; set; }
        public int Codigo_ca {  get; set; }
    }
}
