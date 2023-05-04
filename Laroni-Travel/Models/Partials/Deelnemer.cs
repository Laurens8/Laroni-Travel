using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Laroni_Travel.Models;

namespace Laroni_Travel.Models.Partials
{
    public partial class Deelnemer : Basisklasse
    {
        public bool IsNumeriek(string input)
        {
            bool isNumeriek;
            if (input.All(char.IsDigit))
            {
                return isNumeriek = true;
            }
            else
            {
                return isNumeriek = false;
            }
        }

        public bool ValidateEmail(string input)
        {
            bool email;
            if (input.Contains("@") && input.Contains("."))
            {
                return email = true;
            }
            else
            {
                return email = false;
            }
        }

        public override string this[string columnName]
        {
            get
            {
                if (true)
                {
                    return "";
                }                
                return "";
            }
        }
    }  
}
