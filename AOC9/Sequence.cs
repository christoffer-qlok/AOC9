using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC9
{
    internal class Sequence
    {
        public List<int> Content { get; set; }
        public Sequence Diffs { get; set; }

        public void GenerateDiffs()
        {
            var diffs = new List<int>();
            for (int i = 0; i < Content.Count() - 1; i++)
            {
                diffs.Add(Content[i + 1] - Content[i]);
            }
            Diffs = new Sequence() { Content = diffs };
            if (!diffs.All(i => i == diffs.First()))
            {
                Diffs.GenerateDiffs();
            }
        }

        public void ExpandSequenceForward()
        {
            if(Diffs == null)
            {
                return;
            }

            Diffs.ExpandSequenceForward();

            Content.Add(Content.Last() + Diffs.Content.Last());
        }

        public void ExpandSequenceBackward()
        {
            if (Diffs == null)
            {
                return;
            }

            Diffs.ExpandSequenceBackward();

            Content.Insert(0, Content.First() - Diffs.Content.First());
        }
    }
}
