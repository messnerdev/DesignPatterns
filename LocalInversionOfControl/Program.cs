using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LocalInversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Example example = new Example();
            example.AddingNumbers();
            example.ProcessCommand("AND");
        }
    }

    public class Example
    {
        public void AddingNumbers()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            //24.AddTo(list1).AddTo(list2);
            24.AddTo(list1, list2);
        }

        public void ProcessCommand(string opcode)
        {
            // if (opcode == "AND" || opcode == "OR" || opcode == "XOR")
            // if (new[] {"AND", "OR", "XOR"}.Contains(opcode))
            // if ("AND OR XOR".Split(' ').Contains(opcode))
            if (opcode.IsOneOf("AND", "OR", "XOR"))
            {
                // TODO
            }
        }

        public void Process(Person person)
        {
            // if (person.Names.Count == 0) { }
            // if (!person.Names.Any()) { }
            if (person.HasNo(p => p.Names))
            {
                // TODO
            }

            if (person.HasSome(p => p.Names).And.HasNo(p => p.Children))
            {
                // TODO
            }
        }
    }

    public class Person
    {
        public List<string> Names = new List<string>();
        public List<Person> Children = new List<Person>();
    }

    public static class ExtensionMethods
    {
        public static T AddTo<T>(this T self, params ICollection<T>[] cols)
        {
            foreach (ICollection<T> col in cols)
                col.Add(self);
            return self;
        }

        public static bool IsOneOf<T>(this T self, params T[] values)
        {
            return values.Contains(self);
        }

        public static BoolMarker<TSubject> HasNo<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> properties)
        {
            return new BoolMarker<TSubject>(!properties(self).Any(), self);
        }

        public static BoolMarker<TSubject> HasSome<TSubject, T>(this TSubject self, Func<TSubject, IEnumerable<T>> properties)
        {
            return new BoolMarker<TSubject>(properties(self).Any(), self);
        }

        public static BoolMarker<T> HasNo<T, U>(this BoolMarker<T> marker, Func<T, IEnumerable<U>> properties)
        {
            if (marker.PendingOp == BoolMarker<T>.Operation.And && !marker.Result)
                return marker;
            return new BoolMarker<T>(!properties(marker.Self).Any(), marker.Self);
        }
    }

    public struct BoolMarker<T>
    {
        public bool Result;
        public T Self;

        public enum Operation
        {
            None,
            And,
            Or
        }

        internal Operation PendingOp;

        internal BoolMarker(bool result, T self, Operation pendingOp)
        {
            Result = result;
            Self = self;
            PendingOp = pendingOp;
        }

        public BoolMarker(bool result, T self) : this(result, self, Operation.None)
        {
        }

        public static implicit operator bool(BoolMarker<T> marker)
        {
            return marker.Result;
        }

        public BoolMarker<T> And => new BoolMarker<T>(this.Result, this.Self, Operation.And);
    }
}
