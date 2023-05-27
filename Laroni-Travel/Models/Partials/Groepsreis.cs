using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Groepsreis : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Prijs" && Prijs == null)
                {
                    return "Prijs moet ingevuld zijn";
                }
                if (columnName == "Prijs" && !IsNumeriek(Prijs))
                {
                    return "Prijs moet numeriek zijn";
                }
                if (columnName == "Startdatum" && Startdatum == null)
                {
                    return "Startdatum moet ingevuld zijn";
                }
                if (columnName == "Einddatum" && Einddatum == null)
                {
                    return "Einddatum moet ingevuld zijn";
                }
                if (columnName == "MaxAantalDeelenemrs" && MaxAantalDeelnemers == null)
                {
                    return "MaxAantalDeelenemrs moet ingevuld zijn";
                }
                if (columnName == "MaxAantalDeelenemrs" && !IsNumeriek(MaxAantalDeelnemers))
                {
                    return "MaxAantalDeelenemrs moet numeriek zijn";
                }
                return "";
            }
        }

        public bool IsNumeriek(float input)
        {
            bool isNumeriek;
            string nummer = MaxAantalDeelnemers.ToString();
            if (float.TryParse(nummer, out input))
            {
                return isNumeriek = true;
            }
            else
            {
                return isNumeriek = false;
            }
        }
    }
}
