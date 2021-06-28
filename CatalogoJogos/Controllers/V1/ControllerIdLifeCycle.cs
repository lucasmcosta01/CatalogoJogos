using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.V1
{
    public class ControllerIdLifeCycle : ControllerBase
    {
        public readonly IExampleSingleton _exemploSingleton1;
        public readonly IExampleSingleton _exemploSingleton2;

        public readonly IExampleScoped _exemploScoped1;
        public readonly IExampleScoped _exemploScoped2;

        public readonly IExampleTransient _exemploTransient1;
        public readonly IExampleTransient _exemploTransient2;

        public ControllerIdLifeCycle(IExampleSingleton exampleSingleton1,
                                       IExampleSingleton exampleSingleton2,
                                       IExampleScoped exampleScoped1,
                                       IExampleScoped exampleScoped2,
                                       IExampleTransient exampleTransient1,
                                       IExampleTransient exampleTransient2)
        {
            _exemploSingleton1 = exampleSingleton1;
            _exemploSingleton2 = exampleSingleton2;
            _exemploScoped1 = exampleScoped1;
            _exemploScoped2 = exampleScoped2;
            _exemploTransient1 = exampleTransient1;
            _exemploTransient2 = exampleTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_exemploSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_exemploSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_exemploScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_exemploScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_exemploTransient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_exemploTransient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IGeneralExample
    {
        public Guid Id { get; }
    }

    public interface IExampleSingleton : IGeneralExample
    { }

    public interface IExampleScoped : IGeneralExample
    { }

    public interface IExampleTransient : IGeneralExample
    { }

    public class LifecycleExample : IExampleSingleton, IExampleScoped, IExampleTransient
    {
        private readonly Guid _guid;

        public LifecycleExample()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}

