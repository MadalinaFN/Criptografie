using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_1
{
    abstract class Crypto
    {
        protected int key;
        public abstract string Encriptare(string clear_text);
        public abstract string Decriptare(string cript_text);
    }
}
