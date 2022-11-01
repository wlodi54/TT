using CHK.Queries.Devices;
using CHK.Queries.Infos;

namespace CHK.Common
{
    public interface IQueryHandler<T, TResult> where T : IQuery
    {
        Task<TResult> Get(T data);
    }
}
