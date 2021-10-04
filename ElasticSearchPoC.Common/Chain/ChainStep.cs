using System;

namespace ElasticSearchPoC.Common.Chain
{
    public class ChainStep<T> : IChainStep<T>
    {
        private IChainStep<T> _nextStep;

        public virtual void Run(T stepParams)
        {
            Console.WriteLine("> ...");

            _nextStep?.Run(stepParams);
        }

        public void SetNext(IChainStep<T> step)
        {
            if (step != null)
            {
                _nextStep = step;
            }
        }
    }
}
