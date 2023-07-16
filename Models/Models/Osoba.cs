using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string URLSlika { get; set; }

        public int? FirmaId { get; set; } //FK
        public Firma? Firma { get; set;}
    }
}
