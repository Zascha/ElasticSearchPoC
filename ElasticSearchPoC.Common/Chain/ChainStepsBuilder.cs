using System.Collections.Generic;
using System.Linq;

namespace ElasticSearchPoC.Common.Chain
{
    public static class ChainStepsBuilder
    {
        public static void BuildChain<T>(IEnumerable<IChainStep<T>> chainSteps)
        {
            var chainStepsArray = chainSteps.ToArray();

            for (int i = chainStepsArray.Count() - 1; i > 0; i--)
            {
                var currentStep = chainStepsArray[i];
                var previousStep = chainStepsArray[i - 1];

                previousStep.SetNext(currentStep);
            }
        }
    }
}