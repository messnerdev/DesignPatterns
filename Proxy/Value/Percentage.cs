using System;

namespace Proxy.Value
{
    // Wrapper around primitive type (double -> percentage)
    public struct Percentage : IEquatable<Percentage>
    {
        private readonly double _value;

        internal Percentage(double value)
        {
            _value = value;
        }

        public static double operator * (double d, Percentage p)
        {
            return d * p._value;
        }

        public static double operator *(Percentage p, double d)
        {
            return d * p;
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a._value + b._value);
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }

        public bool Equals(Percentage other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }
    }
}