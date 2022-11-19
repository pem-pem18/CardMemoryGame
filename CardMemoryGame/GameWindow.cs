using CardMemoryGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardMemoryGame
{
    public partial class GameWindow : Form
    {
        Game g;

        Field.CardEvent CardIsDel;
        Field.CardEvent CardIsSelected;
        Game.SelectionEvent SelectionReset;
        Game.EndEvent GameEnd;

        public GameWindow()
        {
            InitializeComponent();

            RestoreGame(false);
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;

            g.SelectCard(c);
        }

        private void Card_IsDel(int index)
        {
            switch (index)
            {
                case 0:
                    DesableCardButton(CardButton0);
                    break;
                case 1:
                    DesableCardButton(CardButton1);
                    break;
                case 2:
                    DesableCardButton(CardButton2);
                    break;
                case 3:
                    DesableCardButton(CardButton3);
                    break;
                case 4:
                    DesableCardButton(CardButton4);
                    break;
                case 5:
                    DesableCardButton(CardButton5);
                    break;
                case 6:
                    DesableCardButton(CardButton6);
                    break;
                case 7:
                    DesableCardButton(CardButton7);
                    break;
                case 8:
                    DesableCardButton(CardButton8);
                    break;
                case 9:
                    DesableCardButton(CardButton9);
                    break;
                case 10:
                    DesableCardButton(CardButton10);
                    break;
                case 11:
                    DesableCardButton(CardButton11);
                    break;
                case 12:
                    DesableCardButton(CardButton12);
                    break;
                case 13:
                    DesableCardButton(CardButton13);
                    break;
                case 14:
                    DesableCardButton(CardButton14);
                    break;
                case 15:
                    DesableCardButton(CardButton15);
                    break;
                default:
                    throw new Exception("Недопустимый номер карточки!");
            }
        }

        private void Card_IsSelected(int index)
        {
            switch (index)
            {
                case 0:
                    OpenCardButton(CardButton0);
                    break;
                case 1:
                    OpenCardButton(CardButton1);
                    break;
                case 2:
                    OpenCardButton(CardButton2);
                    break;
                case 3:
                    OpenCardButton(CardButton3);
                    break;
                case 4:
                    OpenCardButton(CardButton4);
                    break;
                case 5:
                    OpenCardButton(CardButton5);
                    break;
                case 6:
                    OpenCardButton(CardButton6);
                    break;
                case 7:
                    OpenCardButton(CardButton7);
                    break;
                case 8:
                    OpenCardButton(CardButton8);
                    break;
                case 9:
                    OpenCardButton(CardButton9);
                    break;
                case 10:
                    OpenCardButton(CardButton10);
                    break;
                case 11:
                    OpenCardButton(CardButton11);
                    break;
                case 12:
                    OpenCardButton(CardButton12);
                    break;
                case 13:
                    OpenCardButton(CardButton13);
                    break;
                case 14:
                    OpenCardButton(CardButton14);
                    break;
                case 15:
                    OpenCardButton(CardButton15);
                    break;
                default:
                    throw new Exception("Недопустимый номер карточки!");
            }
        }

        private void Card_Closed(int index)
        {
            switch (index)
            {
                case 0:
                    CloseCardButton(CardButton0);
                    break;
                case 1:
                    CloseCardButton(CardButton1);
                    break;
                case 2:
                    CloseCardButton(CardButton2);
                    break;
                case 3:
                    CloseCardButton(CardButton3);
                    break;
                case 4:
                    CloseCardButton(CardButton4);
                    break;
                case 5:
                    CloseCardButton(CardButton5);
                    break;
                case 6:
                    CloseCardButton(CardButton6);
                    break;
                case 7:
                    CloseCardButton(CardButton7);
                    break;
                case 8:
                    CloseCardButton(CardButton8);
                    break;
                case 9:
                    CloseCardButton(CardButton9);
                    break;
                case 10:
                    CloseCardButton(CardButton10);
                    break;
                case 11:
                    CloseCardButton(CardButton11);
                    break;
                case 12:
                    CloseCardButton(CardButton12);
                    break;
                case 13:
                    CloseCardButton(CardButton13);
                    break;
                case 14:
                    CloseCardButton(CardButton14);
                    break;
                case 15:
                    CloseCardButton(CardButton15);
                    break;
                default:
                    throw new Exception("Недопустимый номер карточки!");
            }
        }

        private void DesableCardButton(Button button)
        {
            button.Visible = false;
        }

        private void OpenCardButton(Button button)
        {
            int senderNum = Convert.ToInt16(button.Name.Substring(10));

            button.BackgroundImage = g.field[senderNum].Icon;

            button.Update();
        }

        private void CloseCardButton(Button button)
        {
            int senderNum = Convert.ToInt16(button.Name.Substring(10));

            button.BackgroundImage = Resources.unnamed;
        }

        private void Selection_Reset(int index1, int index2)
        {
            Card_Closed(index1);
            Card_Closed(index2);
        }

        private void Game_Ended()
        {
            DialogResult res = MessageBox.Show(
                "Вы выиграли!\n" +
                "Начать игру заново?", 

                "Конец игры",

                MessageBoxButtons.YesNo);

            if (res is DialogResult.Yes)
            {
                RestoreGame(true);
            }
            else
            {
                this.Close();
            }
        }

        private void RestoreGame(bool isReplay)
        {
            CardIsDel += new Field.CardEvent(Card_IsDel);
            CardIsSelected += new Field.CardEvent(Card_IsSelected);
            SelectionReset += new Game.SelectionEvent(Selection_Reset);
            GameEnd += new Game.EndEvent(Game_Ended);
            g = new Game(GameEnd, CardIsDel, CardIsSelected, SelectionReset);

            if (isReplay)
            {
                foreach (Button card in Cards_Panel.Controls)
                {
                    card.BackgroundImage = Resources.unnamed;
                    card.Visible = true;
                }
            }
        }
    }
}
