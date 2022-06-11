using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Cards
    {
        //NOTE: Constructors
        public Cards(){}

        public Cards(Values v, Suits s)
        {
            CardValue = v;
            Suit = s;
        }
        
        //NOTE: Parameters
        public int ID { get; set; }
        //Using Enums to establish some properties.
        public Values CardValue { get; set; }
        public Suits Suit { get; set; }

        public string Color 
        { 
        // Automatically setting a color value to the card depending on the Suit assigned.
            get
            {
                if(Suit == Suits.Diamonds || Suit == Suits.Hearts)
                {
                    return "red";
                }

                return "black";
            }
        }

    }
