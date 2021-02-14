namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : IStringMutator
    {
        private IStringMutator nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            nextMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            var resultString = str.Trim();
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