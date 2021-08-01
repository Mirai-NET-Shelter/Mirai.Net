using Autofac;

namespace Mirai.Net.Sessions.Http
{
    public class ManagerBuilder
    {
        private readonly ContainerBuilder _builder;

        public ManagerBuilder(MiraiBot bot)
        {
            _builder = new ContainerBuilder();
            _builder.Register(context => bot);
        }

        private IContainer _container => _builder.Build();

        public T Build<T>()
        {
            _builder.RegisterType<T>();

            return _container.Resolve<T>();
        }
    }
}