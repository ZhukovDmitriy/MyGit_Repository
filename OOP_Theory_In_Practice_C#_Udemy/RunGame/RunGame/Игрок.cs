using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    interface Игрок
    {
        void Беги();
        void Голя();
        void НеГоля();
        bool Поймал(Игрок obj); 
    }
}
