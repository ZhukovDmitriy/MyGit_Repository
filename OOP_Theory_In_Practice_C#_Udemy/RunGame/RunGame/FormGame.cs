using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public partial class FormGame : Form
    {
        Arena arena;
        // GameCatch game;
        GameVirus game;

        public FormGame()
        {
            InitializeComponent();
            arena = new Arena(picture);
            // game = new GameCatch();
            game = new GameVirus();
            timer.Enabled = true;
        }

        private void buttonAddGamer_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 5; j++)
            {
                game.AddGamer(Arena.NewCircle());
            }

            for (int j = 0; j < 5; j++)
            {
                game.AddGamer(Arena.NewBox());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            game.Step();
            arena.Clear();
            foreach (Игрок obj in game.gamers)
                arena.Show(obj);
            arena.Refresh();
        }
    }
}
