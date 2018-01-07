using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Cell
    {
        private Content content;
        private Ship ship;

        public bool isDeck => content.Type == ContentType.deck;
        public bool isOccupied { get; set; }
        public Content Content => content;


        public Cell()
        {
            content = new Content();
            isOccupied = false;
            ship = null;
        }


        public Content addShip(Ship s)
        {
            ship = s;
            content.SetDeck();
            s.addDeck(content);
            return content;
        }
    }
}
