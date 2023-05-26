﻿using System;
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
                if (columnName == "MaxAantalDeelenemrs" && MaxAantalDeelenemrs == null)
                {
                    return "MaxAantalDeelenemrs moet ingevuld zijn";
                }
                if (columnName == "MaxAantalDeelenemrs" && !IsNumeriek(MaxAantalDeelenemrs))
                {
                    return "MaxAantalDeelenemrs moet numeriek zijn";
                }
                return "";
            }
        }

        public bool IsNumeriek(int input)
        {
            bool isNumeriek;
            string nummer = MaxAantalDeelenemrs.ToString();
            if (int.TryParse(nummer, out input))
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
