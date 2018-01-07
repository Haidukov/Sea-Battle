using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Ship
    {
        private List<Content> decks;
        private int length;

        public int Length => length;


        public Ship()
        {
            length = 0;
            decks = new List<Content>();
        }


        public Ship(int length)
        {
            this.length = length;
            decks = new List<Content>();
        }


       public bool addDeck(Content content)
        {
            if (decks.Count > length)
                return false;
            decks.Add(content);
            return true;
        }
    }
}
