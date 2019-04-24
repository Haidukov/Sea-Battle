using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Content
    {
        private ContentType type;


        public ContentType Type => type;


        public Content()
        {
            type = ContentType.EMPTY;
        }


        public void SetDeck()
        {
            type = ContentType.DECK;
        }
    }
}
