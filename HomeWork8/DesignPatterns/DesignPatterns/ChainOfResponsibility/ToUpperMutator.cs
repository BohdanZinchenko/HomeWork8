using System.Linq;
using System.Net.NetworkInformation;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ToUpperMutator : IStringMutator
    {
        private IStringMutator nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            nextMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            var resultString = str.ToUpper();
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