using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;

namespace CardMemoryGame.Models
{
    public class Card
    {
        public int Id { get; }

        public Bitmap Icon 
        { 
            get
            {
                switch (Id)
                {
                    case 1:
                        return Resources.icon1;
                    case 2:
                        return Resources.icon2;
                    case 3:
                        return Resources.icon3;
                    case 4:
                        return Resources.icon4;
                    case 5:
                        return Resources.icon5;
                    case 6:
                        return Resources.icon6;
                    case 7:
                        return Resources.icon7;
                    case 8:
                        return Resources.icon8;
                    default:
                        throw new Exception("Недопустимый номер карточки!");

                }
            }
        }

        public Card(int id)
        {
            Id = id;
        }
    }
}
