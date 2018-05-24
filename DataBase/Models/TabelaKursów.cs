using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class TabelaKursów
    {
        public int IdRecord { get; set; }
        public int? Waluta { get; set; }
        public DateTime Data { get; set; }
        public double Ask { get; set; }
        public double Bid { get; set; }

        public NazwyWalut WalutaNavigation { get; set; }
    }
}
