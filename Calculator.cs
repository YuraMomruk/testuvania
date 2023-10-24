using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Yura
{
    public class Calculator
    {
        private const char SYMBOL_CLOSE_BRACKET = ')';
        private const char SYMBOL_OPEN_BRACKET = '(';
        private const char SYMBOL_OPERATOR_ADD = '+';
        private const char SYMBOL_OPERATOR_SUB = '-';
        private const char SYMBOL_OPERATOR_DIV = '/';
        private const char SYMBOL_OPERATOR_MUL = '*';
        private const char SYMBOL_OPERATOR_MOD = '%';
        private const char SYMBOL_UNARY_PLUS = 'p';
        private const char SYMBOL_UNARY_MINUS = 'm';

        static void Main(string[] args)
        {
        }

        private static string InsertSymbol(string input, char symbol, int position)
        {
            string res = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i == position) res += symbol;
                else res += input[i];
            }
            return res;
        }

        private static readonly char[] _operators = new char[]  // бінарні операції
            {
                SYMBOL_OPERATOR_ADD,
                SYMBOL_OPERATOR_SUB,
                SYMBOL_OPERATOR_MUL,
                SYMBOL_OPERATOR_DIV,
                SYMBOL_OPERATOR_MOD
            };

        public static string ReplaceUnaryPlusMinus(string input)
        {
            string res = input.Replace(" ", "");

            for (int i = 0; i < res.Length; i++)
            {
                char currentSymbol = res[i];
                if (currentSymbol == SYMBOL_OPERATOR_ADD)
                {
                    char previosSymbol = SYMBOL_OPERATOR_MUL;

                    if (i > 0) previosSymbol = res[i - 1];

                    if (i < res.Length - 1)
                    {
                        char nextSymbol = res[i + 1];
                        if ((nextSymbol == SYMBOL_OPEN_BRACKET || char.IsDigit(nextSymbol)) && (_operators.Contains(previosSymbol) || previosSymbol == SYMBOL_OPEN_BRACKET))
                            res = InsertSymbol(res, SYMBOL_UNARY_PLUS, i);
                    }
                }

                if (currentSymbol == SYMBOL_OPERATOR_SUB)
                {
                    char previosSymbol = SYMBOL_OPERATOR_MUL;

                    if (i > 0) previosSymbol = res[i - 1];

                    if (i < res.Length - 1)
                    {
                        char nextSymbol = res[i + 1];
                        if ((nextSymbol == SYMBOL_OPEN_BRACKET || char.IsDigit(nextSymbol)) && (_operators.Contains(previosSymbol) || previosSymbol == SYMBOL_OPEN_BRACKET))
                            res = InsertSymbol(res, SYMBOL_UNARY_MINUS, i);
                    }
                }
            }

            return res;
        }
    }
}
