using System.Linq;
using System.Net.Http.Headers;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
    {
        private IStringMutator nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            nextMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            var resultArray = str.Select(x => x).Where(x => !char.IsDigit(x)).ToArray();
            var resultString = new string(resultArray);
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