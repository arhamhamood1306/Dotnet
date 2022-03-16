using Autofac;
using AKD.AKDTrading.BuildingBlocks.EventBus.Abstractions;
using System.Reflection;

namespace AKDTrading.SignalrHub.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
