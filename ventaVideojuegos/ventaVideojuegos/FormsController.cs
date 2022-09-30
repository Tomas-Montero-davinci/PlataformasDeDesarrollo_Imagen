using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos
{
    internal class FormsController
    {

        public static Form1 Form1
        {
            get
            {
                if(_form1 == null)
                {
                    _form1 = new Form1();
                }
                return _form1;
            }
        }

        private static Form1 _form1;

    }
}
