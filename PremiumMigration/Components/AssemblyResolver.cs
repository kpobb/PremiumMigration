using System;
using System.Reflection;

namespace PremiumMigration.Components
{
    internal class AssemblyResolver
    {
        public void Resolve()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var resourceName = new AssemblyName(args.Name).Name + ".dll";
                var resource = Array.Find(GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                byte[] assemblyData;

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                }

                return Assembly.Load(assemblyData);
            };
        }
    }
}
