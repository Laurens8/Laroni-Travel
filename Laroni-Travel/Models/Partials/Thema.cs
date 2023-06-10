﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Thema : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Thema naam moet ingevuld zijn";
                }                
                return "";
            }
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
