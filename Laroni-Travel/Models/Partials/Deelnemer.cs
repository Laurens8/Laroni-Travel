﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models.Partials
{
    public class Deelnemer : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "DeelnemerId")
                {
                    return "";
                }                
                return "";
            }
        }
    }  
}