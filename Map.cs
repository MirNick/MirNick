using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Game_2048
{
    class Map
    {
        public int size{ get; private set; }
        int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public int Get(int x, int y)
        {
            if (OnMap(x, y))
                return map[x, y];
            return -1;
        }

        public void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
                map[x, y] = number;
            //return -1;
        }

        private bool OnMap(int x, int y)
        {
            return x >= 0 && x < size && y >= 0 && y < size;
        }
    }
}