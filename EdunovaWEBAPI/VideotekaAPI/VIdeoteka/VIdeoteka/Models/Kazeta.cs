﻿using System.ComponentModel.DataAnnotations;


namespace VIdeoteka.Models
{
    public class KAZETA : Entitet
    {
        [Required]
        public string? Naslov { get; set; }
        public int? Godina_izdanja { get; set; }
        public string? Zanr { get; set; }
        public int Cijena_posudbe { get; set; }
        public int Cijena_zakasnine { get; set; }

        public ICollection<Posudba> Posudbe { get; } = new List<Posudba>();
    }
    
}