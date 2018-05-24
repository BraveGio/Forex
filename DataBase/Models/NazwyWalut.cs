using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class NazwyWalut
    {
        public NazwyWalut()
        {
            TabelaKursów = new HashSet<TabelaKursów>();
        }

        public int IdWaluty { get; set; }
        public string NazwaWaluty { get; set; }

        public ICollection<TabelaKursów> TabelaKursów { get; set; }
    }
}
