using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class GeneObject<T> : ValidatorObject where T : class
    {
        public string Gene { get; }

        public T Obj { get; }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Gene))
                throw new ArgumentException("Gene is not provided");

            if (Obj == null)
                throw new ArgumentException("Obj is not provided");
        }
        public GeneObject(T obj, string gene)
        {
            Gene = gene;
            Obj = obj;
        }

        public static IEnumerable<GeneObject<T>> Generate(IEnumerable<T> elements)
        {
            var result = new GeneObject<T>[elements.Count()];
            int maxValueGeneLength = Convert.ToString(result.Length - 1, 2).Length;
            StringBuilder geneBuilder = new StringBuilder(maxValueGeneLength);
            for (int i = 0; i < result.Length; i++)
            {
                geneBuilder.Clear();
                string currentGene = Convert.ToString(i, 2);
                geneBuilder.Append('0', maxValueGeneLength - currentGene.Length);
                geneBuilder.Append(currentGene);
                result[i] = new GeneObject<T>(elements.ElementAt(i), geneBuilder.ToString());
            }

            return result;
        }
    }
}
