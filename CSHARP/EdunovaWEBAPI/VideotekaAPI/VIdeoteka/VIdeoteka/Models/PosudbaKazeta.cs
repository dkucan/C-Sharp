using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace VIdeoteka.Models
{
    public class POSUDBAKAZETA : Entitet
    {
        [ForeignKey("(Kazeta)")]
        public string Kazeta { get; set; }
        [ForeignKey("Posudba)")]
        public string Posudba { get; set; }

        public int Cijena_posudbe { get; set; } 

        public int Cijena_zakasnine { get; set; }

       
        }
          

    }

