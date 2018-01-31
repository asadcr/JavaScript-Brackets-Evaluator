using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript_Evaluator
{
    public class Pairs
    {
        public string Opening { get; set; }
        public string Closing { get; set; }
    }

    public class Program
    {
        private static List<Pairs> Pairs = new List<Pairs>()
        {
            new Pairs { Opening = "{", Closing = "}" },
            new Pairs { Opening = "[", Closing = "]" },
            new Pairs { Opening = "(", Closing = ")" }
        };

        static bool Validate(string InputString)
        {
            if (InputString.Trim() == string.Empty)
            {
                return true;
            }

            var Input = InputString.Split(' ').ToList();
            var ClosingBraces = Pairs.Select(a => a.Closing).ToList();

            var ClosingBraceIndex = Input.FindIndex(a => ClosingBraces.Contains(a));
            var ClosingBrace = Input[ClosingBraceIndex];

            var ItemBeforeClosingBraceIndex = ClosingBraceIndex - 1;
            var ItemBeforeClosingBrace = Input[ItemBeforeClosingBraceIndex];

            var OpeningBrace = Pairs.First(a => a.Closing == ClosingBrace).Opening;

            if (ItemBeforeClosingBrace == OpeningBrace)
            {
                Input.RemoveAt(ClosingBraceIndex);
                Input.RemoveAt(ItemBeforeClosingBraceIndex);
                return Validate(string.Join(" ", Input.ToArray()));
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Validate("{ [ ] ( ) }"));
            Console.WriteLine(Validate("{ [ ] ( [ { } ] ) { ( ) } }"));
            Console.WriteLine(Validate("{ [ ( ] ) }"));
            Console.WriteLine(Validate("{ [ }"));
            Console.ReadLine();
        }

    }
}
