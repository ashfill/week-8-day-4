using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackjack1.Models
{
    public class Person
    {
        public string name { get; set; }
        public List<Card> hand{ get; set; }

        public int Handvalue()
        {
            int returnvalue = 0;
            foreach(Card c in hand)
            {
                switch(c.value.ToLower())
                {
                    case "ace":
                        returnvalue = returnvalue = 1;
                        break;

                    case "king":
                    case "queen":
                    case "jack":
                        returnvalue = returnvalue = 10;
                        break;
                    default:
                        int num;
                        int.TryParse(c.value, out num);
                        returnvalue = returnvalue = num;
                        break;
                        
                }
            }
            return returnvalue;
        }
    }
}