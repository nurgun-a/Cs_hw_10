using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cs_hw_10
{
    class Program
    {
        public delegate void ArDeligate(ref int[] _arr_int, int _num);

        
        static public void Creat_arr(ref int[] _arr_int, int _num)
        {
            Random rand = new Random();
            for (int i = 0; i < _num; i++)
            {
                _arr_int[i]= rand.Next(1, 100);
            }
        }
        static public void Print_ar(ref int[] _arr_int, int _num)
        {
            WriteLine($"----------------------------------------");
            for (int i = 0; i < _num; i++)
            {
                Write($"{_arr_int[i]}  ");               
            }
            WriteLine();
            WriteLine($"----------------------------------------");
            //WriteLine(); WriteLine();
        }
        static public void Min_max(ref int[] _arr_int, int _num)
        {
            int min = _arr_int[0], max = _arr_int[0];

            for (int i = 0; i < _num; i++)
            {
                if (min > _arr_int[i]) min = _arr_int[i];
                else if (max < _arr_int[i]) max = _arr_int[i];
            }
            Write($"Min element -> {min};\nMax element -> {max}; ");
            WriteLine(); WriteLine();
        }
        static public void Del(ref int[] _arr_int, int _num)
        {
            WriteLine();
            for (int i = 0; i < _num; i++)
            {
                if (_arr_int[i] % 2 == 0) 
                {
                    WriteLine($"index [{i}] - > {_arr_int[i]} / 2 = {_arr_int[i] /= 2}");                  
                }
            }
            WriteLine();
        }
        static void Main(string[] args)
        {
        bbb:
            Clear();
            try
            {
                Write($"Введите размер массива: "); int num = int.Parse(ReadLine());
                int[] arr_int = new int[num];
                ArDeligate ar_d = null;
                ar_d += Creat_arr;
                ar_d += Print_ar;
                ar_d += Del;
                ar_d += Min_max;
                ar_d += Print_ar;

                foreach (ArDeligate item in ar_d.GetInvocationList())
                {
                    item(ref arr_int, num);
                }
               // WriteLine($"----------------------------------------");
                WriteLine($"Возобновить?\n1 - ДА");
                int num2 = Convert.ToInt32(ReadLine());
                if (num2 == 1) goto bbb;
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }  
        }
    }
}
