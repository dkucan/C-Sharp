﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02Ucahurivanje
{
    internal class Osoba
    {
        // Učahurivanje
        // klase će sakriti svoja svojstva

        private string ime;

        // klase će učiniti svojstvo dostupnim putem tkz. get i set metoda
        
        public void setIme (string ime)
        {
            this.ime = ime;
        }

        public string getIme ()

        { 
            return this.ime; 
        }

        // u nastavku nastave ćemoi koristiti ovaj način za učahurivanje

        public string Prezime { get; set; }
        public Osoba() { }
    }
}
