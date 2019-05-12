namespace _04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Lake : IEnumerable<int>
    {
        private List<int> stoneValues;

        public Lake(params int[] stoneValues)
        {
            this.stoneValues = stoneValues.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stoneValues.Count; i+=2)
            {
                yield return stoneValues[i];
            }

            for (int i = this.stoneValues.Count - 1; i >= 0; i--)
            {
                if(i%2==1)
                {
                    yield return stoneValues[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
