using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturVida.Models
{
    class ProductoM
    {
        private int proCodigo;
        private string proDescripcion;
        private int proValor;
        private int proCantidad ;

        public ProductoM()
        {
            this.proCodigo = 0;
            this.proDescripcion = "";
            this.proValor = 0;
            this.ProCantidad = 0;
        }

        public int ProCodigo { get => proCodigo; set => proCodigo = value; }
        public string ProDescripcion { get => proDescripcion; set => proDescripcion = value; }
        public int ProValor { get => proValor; set => proValor = value; }
        public int ProCantidad { get => proCantidad; set => proCantidad = value; }
    }
}
