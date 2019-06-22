using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class SadrzajApartmana
    {
        #region Fields
        public int Id { get; set; }
        public string NazivSadrzaja { get; set; }
        #endregion

        #region Constructors
        public SadrzajApartmana()
        {
            this.Id = 0;
            this.NazivSadrzaja = "";
        }

        public SadrzajApartmana(int Id, string NazivSadrzaja)
        {
            this.Id = Id;
            this.NazivSadrzaja = NazivSadrzaja;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Id} {NazivSadrzaja}";
        }
        #endregion
    }
}