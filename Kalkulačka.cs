using System;
using System.Collections.Generic;
using System.Text;

namespace ReverzníPolskáNotace
{
    public class Kalkulačka
    {
        public static double KalkulačkaNotace(string vstup)
        {
            if (vstup.Length == 0) throw new ArgumentNullException("prosím vstup délky z N");
            List<double> stack = new List<double>();
            string[] vstupec = vstup.Split(' ');
            foreach (var cislo in vstupec)
            {
                if (double.TryParse(cislo, out double číslo))
                {
                    stack.Add(číslo);
                }
                else
                {
                    try
                    {
                        switch (cislo)
                        {
                            case "+":
                                stack.Add(stack[stack.Count - 1] + stack[stack.Count - 2]);
                                stack.RemoveAt(stack.Count - 2); stack.RemoveAt(stack.Count - 2);
                                break;
                            case "-":
                                stack.Add(stack[stack.Count - 2] - stack[stack.Count - 1]);
                                stack.RemoveAt(stack.Count - 2); stack.RemoveAt(stack.Count - 2);
                                break;
                            case "*":
                                stack.Add(stack[stack.Count - 1] * stack[stack.Count - 2]);
                                stack.RemoveAt(stack.Count - 2); stack.RemoveAt(stack.Count - 2);
                                break;
                            case "/":
                                stack.Add(stack[stack.Count - 2] / stack[stack.Count - 1]);
                                stack.RemoveAt(stack.Count - 2); stack.RemoveAt(stack.Count - 2);
                                break;
                            default:
                                throw new InvalidOperationException("na vstupu prosím jen čísla a operace + - * / oddělené mezerami");
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                        throw new ArgumentException("počet operací musí být o jedna menší než je počet čísel");
                    }

                }
            }
            if (stack.Count != 1)  throw new ArgumentException("počet operací musí být o jedna menší než je počet čísel");
            return stack[0];
        }
    }
}
