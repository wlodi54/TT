namespace CHK.Common
{
    public class Sender
    {
        private readonly IServiceProvider _serviceProvider;

        public Sender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Send<T>(T command) where T : ICommand
        {
            Type type = typeof(ICommandHandler<>);
            var argumentsTypes = new Type[]
            {
                command.GetType(),
            };
            Type handlerType = type.MakeGenericType(argumentsTypes);
            dynamic handler =  _serviceProvider.GetService(handlerType);
            await handler.Handle((dynamic)command);
        }

        public async Task<TResult> Query<T,TResult>(T query) where T : IQuery
        {
            var baseType = typeof(IQueryHandler<,>);
            var genericTypes = new Type[]
            {
                typeof(T),
                typeof(TResult)
            };
            Type queryType = baseType.MakeGenericType(genericTypes);
            dynamic queryHandler = _serviceProvider.GetService(queryType);
            TResult result = await queryHandler.Get((dynamic)query);
            return result;
        }
    }
}
