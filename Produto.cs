using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoquenoCMD
{
    [System.Serializable]  
    abstract class Produto
    {
        public string nome;
        public float preco;
    }
}
