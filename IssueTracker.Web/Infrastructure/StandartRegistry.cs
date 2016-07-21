using StructureMap.Configuration.DSL;

namespace IssueTracker.Web.Infrastructure
{
    public class StandartRegistry : Registry
    {
        public StandartRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}