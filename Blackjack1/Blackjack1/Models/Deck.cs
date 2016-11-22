using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackjack1.Models
{
    public class Deck
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int Mremaining { get; set; }
    }
}