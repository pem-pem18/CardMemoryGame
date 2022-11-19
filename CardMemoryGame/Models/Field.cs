using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMemoryGame.Models
{
    public class Field
    {
        Card[] cardList = new Card[16];

        public delegate void CardEvent(int index);
        public CardEvent CardIsDel;

        public int PairCount
        {
            get
            {
                return cardList.Length / 2;
            }
        }

        public Field(CardEvent cardIsDel)
        {
            int[] counter = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            Random random = new Random();

            for (int i = 0; i < cardList.Length; i++)
            {
                int id;

                do
                {
                    id = random.Next(counter.Length);
                }
                while (counter[id] == 0);

                cardList[i] = new Card(id + 1);

                counter[id]--;
            }

            CardIsDel = cardIsDel;
        }

        public Card this[int index]
        {
            get
            {
                return cardList[index];
            }
            set
            {
                cardList[index] = value;

                if (value == null)
                {
                    CardIsDel(index);
                }
            }
        }
    }
}
