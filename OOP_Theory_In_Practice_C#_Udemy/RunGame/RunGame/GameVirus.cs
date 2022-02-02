using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    class GameVirus
    {
        public List<Игрок> gamers { get; private set; }
        private List<Игрок> virused;

        public GameVirus()
        {
            gamers = new List<Игрок>();
            virused = new List<Игрок>();
        }

        public void AddGamer(Игрок gamer)
        {
            gamers.Add(gamer);
            SetNewVirus(gamer);
        }

        public void Step()
        {
            RunAll();
            FindNewVirus();
        }

        private void RunAll()
        {
            foreach (Игрок g in gamers)
                //if (!virused.Contains(g))
                g.Беги();
        }

        private void SetNewVirus(Игрок gamer)
        {
            virused = new List<Игрок>();
            foreach (Игрок g in gamers)
                g.НеГоля();
            gamer.Голя();
            virused.Add(gamer);
        }

        private void FindNewVirus()
        {
            foreach (Игрок g in gamers)
                if (!virused.Contains(g))
                {
                    if (virused.Count == gamers.Count - 1)
                    {
                        SetNewVirus(g);
                        break;
                    }
                    foreach (Игрок virus in virused)
                        if (g.Поймал(virus))
                        {
                            virused.Add(g);
                            g.Голя();
                            break;
                        }
                }
        }
    }
}
