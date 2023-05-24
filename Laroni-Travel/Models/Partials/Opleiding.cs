using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Opleiding : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Beschrijving" && string.IsNullOrWhiteSpace(Beschrijving))
                {
                    return "Beschrijving moet ingevuld zijn";
                }
                if (columnName == "Datum" && Datum == null)
                {
                    return "Datum moet ingevuld zijn";
                }
                if (columnName == "MaxAantalDeelenemrs" && MaxAantalDeelenemrs == 0)
                {
                    return "MaxAantalDeelenemrs moet ingevuld zijn";
                }
                return "";
            }
        }

        public override string ToString()
        {
            return AantalDeelnemers + " / " + MaxAantalDeelenemrs;
        }        
    }
}
