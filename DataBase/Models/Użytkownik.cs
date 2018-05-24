using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class Użytkownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public bool IsAdmin { get; set; }
        public double Portfel { get; set; }
    }
}
