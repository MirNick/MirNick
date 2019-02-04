using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Game_2048
{
    public class Model
    {
        Map map;
        static Random random = new Random();

        public bool isGameover;
        bool moved = false;

        
        public int size
        {
            get { return map.size; }

        }
        public Model(int size)
        {
            map = new Map(size);
        }

        //public int Size { get; set; }

        public int GetMap(int x, int y)
        {
            //throw new NotImplementedException();
            return map.Get(x, y);
        }

        public void Start() {
            isGameover = false;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    map.Set(x, y, 0);
                }
            }
            AddRandomNumber();
            AddRandomNumber();

        }

        private void AddRandomNumber() {
            if (isGameover) return;
            for (int j = 0; j < 100; j++) {
                int x = random.Next(0, map.size);
                int y = random.Next(0, map.size);
                if (map.Get(x, y) == 0) {
                    map.Set(x, y, (random.Next(1, 2) * 2));
                    return;
                }
            }
        }

        void lift(int x, int y, int ax, int ay) {
            if (map.Get(x, y) > 0)
                while (map.Get(x + ax, y + ay) == 0) {
                    map.Set(x + ax, y + ay, map.Get(x, y));
                    map.Set(x, y, 0);
                    x += ax;
                    y += ay;
                    moved = true;
                }

        }

        void join(int x, int y, int ax, int ay) {
            if (map.Get(x, y) > 0) {
                if (map.Get(x + ax, y + ay) == (map.Get(x, y))) {
                    map.Set(x + ax, y + ay, map.Get(x, y) * 2);
                    while (map.Get(x - ax, y - ay) > 0) {
                        map.Set(x, y, map.Get(x - ax, y - ay));
                        x -= ax;
                        y -= ay;
                        moved = true;
                    }
                    map.Set(x,y,0);
                }

            }

        }

            public void Left() {
            moved = false;
            for (int y = 0; y < map.size; y++)
                for (int x = 0; x < map.size; x++)
                    lift(x, y, -1, 0);
            for (int x = 0; x < map.size; x++)
                for (int y = 0; y < map.size; y++)
                    join(x, y, -1, 0);
            if (moved) AddRandomNumber();
        }

        public void Right() {
            moved = false;
            for (int y = 0; y < map.size; y++)
                for (int x = map.size - 2; x >= 0; x--)
                    lift(x, y, 1, 0);
            for (int x = 0; x < map.size; x++)
                for (int y = 0; y < map.size; y++)
                    join(x, y, 1, 0);
            if (moved) AddRandomNumber();
        }

        public void Up() {
            moved = false;
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    lift(x, y, 0, -1);
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    join(x,y,0,-1);
            if(moved) AddRandomNumber();
        }
    
        public void Down() {
            moved = false;
            for (int x = 0; x < map.size; x++)
                for (int y = map.size - 2; y >=0; y--)
                    lift(x, y, 0, 1);
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    join(x, y, 0, 1);
           if (moved) AddRandomNumber();
        }

        public bool IsGameOver() {
            if(isGameover)
            return isGameover;
            //isGameOver = false
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map.Get(x, y) == 0)
                        return false;
                }
            }
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map.Get(x, y) == map.Get(x+1, y)||
                        map.Get(x, y) == map.Get(x, y+1))
                        return false;
                }
            }
            isGameover = true;
            return isGameover;
        }


    }
}
