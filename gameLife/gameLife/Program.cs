using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace gameLife
{
    class life
    {
        string[,] lifeDesk;
        int[,] environment = new int[,]{ { -1, 0 } , { 1, 0 } , {0, -1} , {0, 1} , { -1 , -1} , { 1 , -1} , { -1, 1} , { 1 , 1} };

        public life(int yLenght,int xLenght)
        {
            lifeDesk = new string[yLenght, xLenght];
        }
        public life(string[,] array)
        {
            lifeDesk = array;
        }
        public void alertLifeDesk()
        {
            for (int i = 0; i < lifeDesk.GetLength(0);i++)
            {
                for (int z = 0; z < lifeDesk.GetLength(1); z++)
                {
                    Console.Write(lifeDesk[i, z]);
                }
                Console.WriteLine();
            }
        }
        public int checkAroundCount(int y , int x )
        {
            int sum = 0;
            for(int i = 0; i < environment.GetLength(0); i++)
            {
                try
                {
                    if (lifeDesk[y + environment[i, 1], x + environment[i, 0]] != " ")
                    {
                        sum++;
                    }
                }
                catch { };
            }
            return sum; 
        }
        public void nextTime()
        {
            string delArray = "";
            string createArray = "";

            for (int i = 0; i < lifeDesk.GetLength(0)-1; i++)
            {
                for (int z = 0; z < lifeDesk.GetLength(1)-1; z++)
                {
                    if (checkAroundCount(i, z) == 3)
                    {
                        createArray += Convert.ToString(i) + Convert.ToString(z);
                    }
                    else if ((checkAroundCount(i, z) < 2) || checkAroundCount(i, z) > 3)
                    {
                        if (getCell(i, z) != " ")
                        {
                            delArray += Convert.ToString(i) + Convert.ToString(z);
                        }
                    }
                }
            }

            for(int i = 0;i < delArray.Length; i+=2)
            {
                lifeDesk[Convert.ToInt32(Convert.ToString(delArray[i])), Convert.ToInt32(Convert.ToString(delArray[i+1])) ] = " ";
            }

            for (int i = 0; i < createArray.Length; i+=2)
            {
                lifeDesk[Convert.ToInt32(Convert.ToString(createArray[i])), Convert.ToInt32(Convert.ToString(createArray[i+1])) ] = "x";
            }
        } 
        public void setCell(int y, int x, bool isLife)
        {
            if (isLife) {
                lifeDesk[y, x] = "X";
            }
            else
            {
                lifeDesk[y, x] = " ";
            }
        }
        public string getCell(int y, int x)
        {
            return lifeDesk[y, x] ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = {
                {" "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "},
                {" "," ","x","x"," "," "," "," "," "," "},
                {" "," ","x"," "," "," "," "," "," "," "},
                {" "," "," ","x"," ","x"," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," ","x"," ","x"," "," "},
                {" "," "," "," "," "," ","x","x"," "," "},
                {" "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "}

            };
            life life1 = new life(array);

            while (true)
            {
                Console.Clear();

                life1.alertLifeDesk();
                life1.nextTime();

                Thread.Sleep(250);
            }

        }
    }
}
