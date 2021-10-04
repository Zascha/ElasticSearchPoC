namespace ElasticSearchPoC.Common.Chain
{
    public interface IChainStep<T>
    {
        void SetNext(IChainStep<T> step);

        void Run(T stepParams);
    }
}