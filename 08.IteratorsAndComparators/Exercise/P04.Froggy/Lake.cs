using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            for (int i = this.stones.Count - 1; i >= 0; i -= 2)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }

                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
