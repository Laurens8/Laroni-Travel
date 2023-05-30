using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
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
                if (columnName == "Voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam moet ingevuld zijn";
                }
                if (columnName == "Familienaam" && string.IsNullOrWhiteSpace(Familienaam))
                {
                    return "Familienaam moet ingevuld zijn";
                }
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email moet ingevuld zijn";
                }
                if (columnName == "Straatnaam" && string.IsNullOrWhiteSpace(Straatnaam))
                {
                    return "Straatnaam moet ingevuld zijn";
                }
                if (columnName == "Huisnummer" && string.IsNullOrWhiteSpace(Huisnummer))
                {
                    return "Huisnummer moet ingevuld zijn";
                }
                if (columnName == "Postcode" && string.IsNullOrWhiteSpace(Postcode))
                {
                    return "Postcode moet ingevuld zijn";
                }
                if (columnName == "Gemeente" && string.IsNullOrWhiteSpace(Gemeente))
                {
                    return "Gemeente moet ingevuld zijn";
                }
                if (columnName == "Geboortedatum" && Geboortedatum.Year == 0)
                {
                    return "Geboortedatum moet ingevuld zijn";
                }
                if (columnName == "Geslacht" && string.IsNullOrWhiteSpace(Geslacht))
                {
                    return "Geslacht moet ingevuld zijn";
                }
                if (columnName == "Geslacht" && !Geslacht.Contains("M") && !Geslacht.Contains("V"))
                {
                    return "Geslacht moet 'M' of 'V' zijn";
                }
                if (columnName == "Email" && !ValidateEmail(Email))
                {
                    return "Email moet een geldig email adres zijn";
                }
                //if (columnName == "Postcode" && !IsNumeriek(Postcode))
                //{
                //    return "Postcode moet een nummer zijn";
                //}
                //if (columnName == "Huisnummer" && !IsNumeriek(Huisnummer))
                //{
                //    return "Huisnummer moet een nummer zijn";
                //}              
                //if (columnName == "Wachtwoord" && string.IsNullOrWhiteSpace(Wachtwoord))
                //{
                //    return "Wachtwoord moet ingevuld zijn";
                //}
                //if (columnName == "Wachtwoord" && Wachtwoord.Length < 8)
                //{
                //    return "Wachtwoord moet minstens 8 tekens lang zijn";
                //}
                return "";
            }
        }
    }  
}
