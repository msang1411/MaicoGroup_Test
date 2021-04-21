using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    /* 
 
        Mặc định size map là 9x9 , số mine có trong map là 10
        Mặc định giá trị -1 là mine, 0 -> 8 là số mine xung quanh

    */
    class minesweeper
    {
        private int[,] map; // map
        private char[,] mapDisplay; // map hien thi
        private bool[,] isChecked;// các ô đã ấn vào
        private bool gameOver; // check xem trò chơi kết thúc chưa

        // contructor
        public minesweeper()
        {
            gameOver = false;
            map = new int[9, 9];
            mapDisplay = new char[9, 9];
            isChecked = new bool[9, 9];


            for (int i = 0; i < 9; i++) // vẽ map khi khởi chạy trò chơi
            {
                for (int j = 0; j < 9; j++)
                {
                    map[i, j] = 0;
                    mapDisplay[i, j] = '#';
                    isChecked[i, j] = false;
                }
            }
        }
        //method
        bool IsMine(int x, int y)
        {
            if (map[x, y] == -1) // là mine
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // mở map
        void OpenRoad(int x, int y)
        {
            if (isChecked[x, y])
            {
                return; // vị trí x,y đã được check thì thoát ra
            }
            if (IsMine(x, y))
            {
                gameOver = true;
                isChecked[x, y] = true;
                mapDisplay[x, y] = 'O';
                return;
            }

            if (map[x, y] > 0)
            {
                isChecked[x, y] = true;
                mapDisplay[x, y] = (char)('0' + map[x, y]);
            }
            else
            {
                isChecked[x, y] = true;
                mapDisplay[x, y] = '0';

                //vị trí trên 
                if ((x - 1 >= 0) && !isChecked[x - 1, y]) OpenRoad(x - 1, y);
                //vị trí dưới
                if ((x + 1 < 9) && !isChecked[x + 1, y]) OpenRoad(x + 1, y);
                //vị trí cạnh phải
                if ((y + 1 < 9) && !isChecked[x, y + 1]) OpenRoad(x, y + 1);
                //vị trí cạnh trái
                if ((y - 1 >= 0) && !isChecked[x, y - 1]) OpenRoad(x, y - 1);
                //vị trí dưới phải
                if ((x + 1 < 9 && y + 1 < 9) && !isChecked[x + 1, y + 1]) OpenRoad(x + 1, y + 1);
                //vị trí dưới trái
                if ((x + 1 < 9 && y - 1 >= 0) && !isChecked[x + 1, y - 1]) OpenRoad(x + 1, y - 1);
                //vị trí trên phải
                if ((x - 1 >= 0 && y + 1 < 9) && !isChecked[x - 1, y + 1]) OpenRoad(x - 1, y + 1);
                //vị trí trên trái
                if ((x - 1 >= 0 && y - 1 >= 0) && !isChecked[x - 1, y - 1]) OpenRoad(x - 1, y - 1);

            }
            return;
        }
        //khởi trạo giá trị cho vị trí, cụ thể thì vih trí =-1 thì cosmine, bằng 0 thì xung quanh không có mine, bằng >0 thì xuong quanh có mine
        public int CreateValue(int x, int y)
        {
            if (map[x, y] == -1)
            {
                return -1;
            }
            int numOfMineAround = 0;

            if (x - 1 >= 0 && map[x - 1, y] == -1)//vi tri ben tren
                numOfMineAround++;
            if (x - 1 >= 0 && y - 1 >= 0 && map[x - 1, y - 1] == -1) //vi tri tren trai
                numOfMineAround++;
            if (x - 1 >= 0 && y + 1 < 9 && map[x - 1, y + 1] == -1) //vi tri tren phai
                numOfMineAround++;
            if (y - 1 >= 0 && map[x, y - 1] == -1) //vị trí cạnh trái
                numOfMineAround++;
            if (y + 1 < 9 && map[x, y + 1] == -1) //vị trí cạnh phải
                numOfMineAround++;
            if (x + 1 < 9 && map[x + 1, y] == -1) //vị trí dưới
                numOfMineAround++;
            if (x + 1 < 9 && y - 1 >= 0 && map[x + 1, y - 1] == -1) //vị trí  dưới trái
                numOfMineAround++;
            if (x + 1 < 9 && y + 1 < 9 && map[x + 1, y + 1] == -1) //vị trí dưới phải
                numOfMineAround++;

            return numOfMineAround;
        }

        void CreateMap(int x, int y)
        {
            Random mine = new Random();


            int totalMine = 0;

            while (totalMine < 10)//tạo 10 mine
            {
                int minex = 0, miney = 0;
                do
                {
                    minex = (int)mine.Next(0, 9);
                    miney = (int)mine.Next(0, 9);

                } while ((minex == x && miney == y) || (map[minex, miney] != 0));

                map[minex, miney] = -1;
                totalMine++;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    map[i, j] = CreateValue(i, j);
                }
            }
            OpenRoad(x, y);
        }
        bool Win()
        {
            int location = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!isChecked[i, j])
                        location++;
                }
            }
            return location == 10;//Nếu số vị trí còn lại là 10 thì thắng
        }
        public void Game()
        {
            PrintBoard();

            int x, y;
            MakeMove(out x, out y);
            CreateMap(x, y);

            while (!Win() && !gameOver)
            {

                do
                {
                    PrintBoard();
                    MakeMove(out x, out y);

                } while (isChecked[x, y]);

                OpenRoad(x, y);

            }

            if (gameOver)
            {
                PrintFinal();
                Console.WriteLine("Dẫm phải boom!\n");
            }
            else
            {
                PrintBoard();
                Console.WriteLine("Tránh được hết boom rồi!\n");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0} ", mapDisplay[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void PrintFinal() 
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (map[i, j] == -1) Console.Write("X ");
                    else Console.Write("{0} ", 48 + map[i, j] - '0');
                }
                Console.WriteLine();
            }
        }

        private void MakeMove(out int x, out int y)
        {
            do
            {
                Console.WriteLine("\nNhap  x: ");

                string input = Console.ReadLine();
                x = (int)(input[0] - '0');
                Console.WriteLine("\nNhap  y: ");
                input = Console.ReadLine();
                y = (int)(input[0] - '0');
                Console.WriteLine();
            } while (x < 0 || y < 0 || x >= 9 || y >= 9);
        }
    }
}
