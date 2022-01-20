namespace BuildingBlocks.Application
{
    public interface IUseCase<in TInput, TResult> where TInput : IUseCaseInput<TResult>
    {
        Task<TResult> Handle(TInput input);
    }

    public interface IUseCaseInput<out TResponse> {}
}
