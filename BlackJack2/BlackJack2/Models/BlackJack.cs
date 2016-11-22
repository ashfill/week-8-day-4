using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack2.Models
{
    public class BlackJack
    {
        public string deckId { get; set; }
        public person dealer { get; set; }
        public person player { get; set; }
        public int remaining { get; set; }

        public int dealerValue { get; set; }
        public int playerValue { get; set; }
    }
}