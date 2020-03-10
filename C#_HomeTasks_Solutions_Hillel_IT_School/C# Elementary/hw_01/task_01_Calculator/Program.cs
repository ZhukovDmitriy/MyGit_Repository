using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_01_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение: ");
            string str = Console.ReadLine();
            str += '+';                             // Программа начинает расчет тогда, когда сравнивается следующий знак с предидущим                    
                                                    // '+' к строке нужен для расчета конца строки или для расчета только двух значений 2+2(+) || 2-2*2-2(+)
            Stack<int> num = new Stack<int>();
            Stack<char> sym = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    int numConvert = (int)char.GetNumericValue(str[i]);
                    num.Push(numConvert);
                }

                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    if (sym.Count == 0)             // Знак вносится в стек sym ТОЛЬКО ПОСЛЕ сравнения с предидущим и вычислении оперции 
                    {                               // по этому первый символ в стек заносится безусловно
                        sym.Push(str[i]);
                    }

                    if (num.Count >= 2)             // Начало вычисления - когда в стеке num будут 2 числа                                                        
                    {
                        if (str[i] == '+' || str[i] == '-')     // Блок вычисления для случаев без приоритета последующей операции 2*2+ || 2/2- || 2-2+
                        {
                            do          // Необходим чтобы после операции оставить в стеке num только одно значение (высчитывает 2-е операции)
                                        // приминяется только в случаях когда после приоритетной последующей оперции идёт знак '-' || '+' : 2-2*2+ || 1+2/2-
                            {
                                if (sym.Peek() == '+' || sym.Peek() == '-' || sym.Peek() == '*' || sym.Peek() == '/')
                                {
                                    if (sym.Peek() == '+')
                                    {
                                        num.Push(num.Pop() + num.Pop());
                                    }

                                    if (sym.Peek() == '-')
                                    {
                                        int numBuffer = num.Pop();
                                        num.Push(num.Pop() - numBuffer);
                                    }

                                    if (sym.Peek() == '*')
                                    {
                                        num.Push(num.Pop() * num.Pop());
                                    }

                                    if (sym.Peek() == '/')
                                    {
                                        int numBuffer = num.Pop();
                                        num.Push(num.Pop() / numBuffer);
                                    }

                                    sym.Pop();                       // Извлекаем знак из стека sym после проведения операции
                                }

                            } while (num.Count != 1);

                            sym.Push(str[i]);                        // Новый знак в стек вносим только после извлечения предидущего
                                                                     // и после того как в стеке будет только 1-а цифра
                        }

                        if (str[i] == '*' || str[i] == '/')          // Блок вычисления для случаев с приоритетной  последующей операцией 2-2*2/ || 1+2*2*
                                                                     // и без приоритетной 2*2*2/
                        {
                            if (sym.Peek() == '+' || sym.Peek() == '-' || sym.Peek() == '*' || sym.Peek() == '/')   // В случаях 2-2*1 при первой оперции 
                                                                                                   // '-' || '+' знак просто заносится в стек без расчета                                           
                            {
                                if (sym.Peek() == '*')
                                {
                                    num.Push(num.Pop() * num.Pop());
                                    sym.Pop();
                                }

                                else if (sym.Peek() == '/')
                                {
                                    int numBuffer = num.Pop();
                                    num.Push(num.Pop() / numBuffer);
                                    sym.Pop();
                                }

                                sym.Push(str[i]);
                            }
                        }
                    }
                }
            }
            /*                                      
            Console.Write("\nСтек num: ");          // Вывод содержимого стеков, для наглядности - используется при разработке и модернизации программы 
            foreach (var item in num)
            {
                Console.Write(" " + item);
            }
                                                    // При правильном вычислении стек num должен содержать только 1-о значение. Стек sym только (+)
            Console.Write("\nСтек sym:  ");
            foreach (var item in sym)
            {
                Console.Write(" " + item);
            }
            */
            Console.WriteLine("\n\nРезультат вычисления: {0}", num.Pop());
            Console.ReadKey();
        }
    }
}
