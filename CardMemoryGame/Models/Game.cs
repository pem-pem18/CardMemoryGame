using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace CardMemoryGame.Models
{
    public class Game
    {
        public Field field;

        private int RamainingPairCounter;

        private bool _selectionStatus;
        public bool SelectionStatus
        {
            get
            {
                return _selectionStatus;
            }
            set
            {
                _selectionStatus = value;
            }
        }

        private int _selectedCount;
        public int SelectedCount
        {
            get
            {
                return _selectedCount;
            }
            set
            {
                if (value == 3)
                {
                    _selectedCount = 0;
                }
                else
                {
                    _selectedCount = value;
                }
            }
        }

        public event Field.CardEvent CardIsDel;
        public event Field.CardEvent CardIsSelected;

        public delegate void SelectionEvent(int index1, int index2);
        public event SelectionEvent SelectionReset;

        public delegate void EndEvent();
        public event EndEvent GameEnd;
        public event EndEvent RestoreGame;

        public int SelectedIndex;

        public double SelectedTimeOut = 0.5;

        public Game(
            EndEvent gameEnd,
            Field.CardEvent cardIsDel,
            Field.CardEvent cardIsSelected,
            SelectionEvent selectionReset)
        {
            CardIsDel += cardIsDel;
            CardIsSelected += cardIsSelected;
            SelectionReset += selectionReset;
            GameEnd += gameEnd;
            field = new Field(CardIsDel);
            RamainingPairCounter = field.PairCount;
        }

        public Card this[int index]
        {
            get
            {
                return field[index];
            }
        }

        public void SelectCard(Control sender)
        {
            int senderNum = Convert.ToInt16(sender.Name.Substring(10));

            SelectedCount = SelectedCount + 1;

            CardIsSelected(senderNum);

            if (SelectionStatus && senderNum != SelectedIndex)
            {
                if (field[senderNum].Id == field[SelectedIndex].Id)
                {
                    Thread.Sleep((int)(1000 * SelectedTimeOut));

                    DelPair(SelectedIndex, senderNum);
                }
                else
                {
                    Thread.Sleep((int)(1000 * SelectedTimeOut));

                    SelectionReset(senderNum, SelectedIndex);
                }

                SelectionStatus = false;
            }
            else
            {
                SelectionStatus = true;
                SelectedIndex = senderNum;
            }
        }

        private void DelPair(int index1, int index2)
        {
            field[index1] = null;
            field[index2] = null;

            RamainingPairCounter--;

            if (RamainingPairCounter == 0)
            {
                GameEnd();
            }
        }
    }
}
