using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Bestemming : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam moet ingevuld zijn";
                }
                if (columnName == "Straatnaam" && string.IsNullOrWhiteSpace(Straatnaam))
                {
                    return "Straatnaam moet ingevuld zijn";
                }
                if (columnName == "Gemeente" && string.IsNullOrWhiteSpace(Gemeente))
                {
                    return "Gemeente moet ingevuld zijn";
                }
                if (columnName == "Land" && string.IsNullOrWhiteSpace(Land))
                {
                    return "Land moet ingevuld zijn";
                }
                if (columnName == "Huisnummer" && string.IsNullOrWhiteSpace(Huisnummer))
                {
                    return "Huisnummer moet ingevuld zijn";
                }
                if (columnName == "Postcode" && string.IsNullOrWhiteSpace(Postcode))
                {
                    return "Postcode moet ingevuld zijn";
                }
                if (columnName == "Huisnummer" && !IsNumeriek(Huisnummer))
                {
                    return "Huisnummer moet numeriek zijn";
                }
                //if (columnName == "Postcode" && !IsNumeriek(Postcode))
                //{
                //    return "Postcode moet numeriek zijn";
                //}
                return "";
            }
        }

        public bool IsNumeriek(string input)
        {
            bool isNumeriek;
            int nummer;
            if (int.TryParse(input, out nummer))
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
