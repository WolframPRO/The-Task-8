using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин графа: ");

            int Mount;
            bool ok;

            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out Mount);
                if (!ok) Console.WriteLine("Некорректный ввод!");
                if (Mount < 1) Console.WriteLine("Граф слишком мал!");
                if (Mount == 1) Console.WriteLine("Граф можно расскрасить одним цветом, Вы великолепны!");
            } while (!ok);

            Random rand = new Random();
            int[,] graph = new int[Mount, rand.Next(1, Fuck(Mount))];
            GraphGen(graph);

            for(int i = 0; i < Mount; i++)
            {
                for(int n = 0; n < graph.GetLength(1); n++)
                Console.Write(graph[i,n] + " ");
                Console.WriteLine();
            }

            Console.WriteLine("Во сколько цветов нужно раскрасить граф? ");
            int colNum;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out colNum);
                if (!ok) Console.WriteLine("Некорректный ввод!");
                if (colNum < 1) Console.WriteLine("Цветов недостаточно!");
            } while (!ok);

            int[] col = ColorGraph(graph, colNum);
            for (int i = 0; i <col.Length; i++ )
                Console.Write(col[i] + " ");

            Console.ReadKey();
        }

        public static int Fuck(int numb) //Считает количество полосочек в графе
        {
            int res = 1;
            for (int i = numb; i > 1; i--)
                res += i;
            return res;
        }
        public static int[,] GraphGen(int[,] gr) //Генерирует граф
        {
            Random rand = new Random();
            for (int i = 0; i < gr.GetLength(0); i++)
            {
                for (int n = 0; n < gr.GetLength(1); n++)
                {
                    gr[i, n] = 0;
                }
            }
            int x;
            for (int i = 0; i < gr.GetLength(1); i++)
            {

                for (int n = 0; n < 2; n++)
                {
                    x = rand.Next(0, gr.GetLength(0));
                    if (gr[x, i] != 1) gr[x, i] = 1;
                    else n--;
                }


            }

            return gr;
        }

        public static int[] ColorGraph(int[,] gr, int colNum)
        {
            Random rand = new Random();
            int[] col = new int[gr.GetLength(0)];
            int color = 1;
            col[0] = color;

            for(int y = 0; y < 50; y++)
            for (int point = 0; point < gr.GetLength(0); point++)
            {
                for (int line = 0; line < gr.GetLength(1); line++)
                {
                    for (int pointTemp = point + 1; pointTemp < gr.GetLength(0); pointTemp++)
                    {
                        if(col[pointTemp] == 0) col[pointTemp] = 1;
                        do
                        {
                            col[pointTemp] = rand.Next(1, colNum + 1);
                        } while (col[point] == col[pointTemp]);


                    }
                }
            }

            return col;
        }  //раскрашивает граф, вроде даже правильно
    }
}
