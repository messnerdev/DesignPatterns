﻿using System;

namespace Interpreter
{
    public class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen
        }

        public Type MyType;
        public string Text;

        public Token(Type myType, string text)
        {
            MyType = myType;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public Token(Type myType, char character) : this(myType, character.ToString()) { }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }
}