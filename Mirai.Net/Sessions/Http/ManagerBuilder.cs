using Autofac;

namespace Mirai.Net.Sessions.Http
{
    public class ManagerBuilder
    {
        private ContainerBuilder _builder;
        private IContainer _container => _builder.Build();

        public ManagerBuilder(MiraiBot bot)
        {
            _builder = new ContainerBuilder();
            _builder.Register(context => bot);
        }

        public T Build<T>()
        {
            _builder.RegisterType<T>();

            return _container.Resolve<T>();
        }
    }
}