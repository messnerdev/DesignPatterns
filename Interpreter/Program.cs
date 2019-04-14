using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "(13+4)-(12+1)";
            var tokens = Lex(input).ToList();
            Console.WriteLine(string.Join('\t', tokens));

            var parsed = Parse(tokens);
            Console.WriteLine($"{input} = {parsed.Value}");
        }

        static IEnumerable<Token> Lex(string input)
        {
            for (var index = 0; index < input.Length; index++)
            {
                char c = input[index];
                switch (c)
                {
                    case '+':
                        yield return new Token(Token.Type.Plus, c);
                        break;
                    case '-':
                        yield return new Token(Token.Type.Minus, c);
                        break;
                    case '(':
                        yield return new Token(Token.Type.Lparen, c);
                        break;
                    case ')':
                        yield return new Token(Token.Type.Rparen, c);
                        break;
                    default:
                        var sb = new StringBuilder(c.ToString());
                        for (int j = index + 1; index < input.Length; ++j)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                index++;
                            }
                            else
                            {
                                yield return new Token(Token.Type.Integer, sb.ToString());
                                break;
                            }
                        }
                        break;
                }
            }
        }

        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLeft = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(Convert.ToInt32(token.Text));
                        if (!haveLeft)
                        {
                            result.Left = integer;
                            haveLeft = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].MyType == Token.Type.Rparen)
                                break;
                        var subExpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subExpression);
                        if (!haveLeft)
                        {
                            result.Left = element;
                            haveLeft = true;
                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
    }
}
