using Azure.Core;
using CHK.Common;
using CHK.Domain;
using CHK.Infrastructure;
using CHK.Infrastructure.Repositories;
using Dapper;

namespace CHK.Queries.Infos
{
    public class InfoListQueryHandler : IQueryHandler<InfoListQuery, List<InfoListResultDto>>
    {
        private readonly ReadConnectionFactory _readConnectionFactory;

        public InfoListQueryHandler(ReadConnectionFactory infoRepository)
        {
            _readConnectionFactory = infoRepository;
        }
        public async Task<List<InfoListResultDto>> Get(InfoListQuery data)
        {
            using (var connection = _readConnectionFactory.Create())
            {
                const string sqlProducts = @"SELECT [Id]
                                                ,[OccurredDate]
                                                ,[SecurityStatus]
                                                ,[DeviceId]
                                                ,[DataId]
                                            FROM[CHK].[dbo].[Info] where [OccurredDate] > @date";

                var products = await connection.QueryAsync<InfoListResultDto>(sqlProducts, new { data.DateFrom });
                var result = products.ToList();
                return result;

            }
        }
    }
}
