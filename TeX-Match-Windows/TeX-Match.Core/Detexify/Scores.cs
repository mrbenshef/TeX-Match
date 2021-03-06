﻿using System.Collections;

namespace TeX_Match.Core.Detexify
{
    public class Scores : IEnumerable
    {
        internal unsafe void* Ptr { get; }

        internal unsafe Scores(void* v)
        {
            Ptr = v;
        }

        public uint Length()
        {
            unsafe { return Bindings.ScoresLength(Ptr); };
        }

        public Symbol GetSymbol(uint i)
        {
            unsafe { return new Symbol(Bindings.ScoresGetSymbol(Ptr, i)); }
        }

        public double GetScore(uint i)
        {
            unsafe { return Bindings.ScoresGetScore(Ptr, i); }
        }

        public IEnumerator GetEnumerator()
        {
            for (uint i = 0; i < Length(); i++)
            {
                yield return new Score(GetSymbol(i), GetScore(i));
            }
        }
    }
}