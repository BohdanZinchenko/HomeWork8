using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private static string _line;

        public CustomStringBuilder()
        {
            _line = string.Empty;
        }

        public CustomStringBuilder(string text)
        {
            _line = text;
        }

        public ICustomStringBuilder Append(string str)
        {

            _line = _line + str;
            Debug.Write(_line);
            return new CustomStringBuilder(_line);

        }

        public ICustomStringBuilder Append(char ch)
        {
            _line = _line + ch;
            Debug.Write(_line);
            return new CustomStringBuilder(_line);
        }

        public ICustomStringBuilder AppendLine()
        {
            _line = _line + "\n";
            Debug.Write(_line);
            return new CustomStringBuilder(_line);
            
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            _line = _line + "\n"+str;
            return new CustomStringBuilder(_line);
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            _line = _line + "\n" + ch;
            return new CustomStringBuilder(_line);
            
        }

        public string Build()
        {
            Debug.WriteLine(_line);
            return _line;
        }
    }
}