using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02Delegati
{
    internal class PrimjerKoristenja3
    {

        public PrimjerKoristenja3()
        {
            var os = new ObradaSmjer();
            Action<Smjer> a = new(metodaOvdje);
            os.IspisSmjerAction(a);
        }
        void metodaOvdje (Smjer s)
        {
            Console.WriteLine("\"" + s.Naziv + "\"");
        }
    }
}
