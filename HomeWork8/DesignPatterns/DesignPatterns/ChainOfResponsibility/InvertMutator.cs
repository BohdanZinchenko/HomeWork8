using System;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
    {
        private IStringMutator nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            nextMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            var resultaArray = str.ToCharArray();
            Array.Reverse(resultaArray);
            var resultString = new string(resultaArray);
            if (nextMutator != null)
            {
                
                return nextMutator.Mutate(resultString);
            }
            else
            {
                return resultString;
            }
        }
    }
}