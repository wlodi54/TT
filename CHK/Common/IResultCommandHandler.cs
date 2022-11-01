namespace CHK.Common
{
    public interface IResultCommandHandler<T, TResult> where T : ICommand
    {
        Task<TResult> Handle(T command);
    }
}
