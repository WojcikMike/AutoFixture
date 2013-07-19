using System;

namespace Ploeh.AutoFixture.Idioms
{
    public class EqualityException : Exception
    {
        public EqualityException(string s): base(s)
        {
        }
    }
}