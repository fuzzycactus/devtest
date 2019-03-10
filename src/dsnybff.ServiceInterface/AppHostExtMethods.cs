using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;
using dsnybff.ServiceModel.Types;

namespace dsnybff.ServiceInterface
{
    public static class AppHostExtMethods
    {
        public static void ReloadCsv<T>(this IAppHost appHost)
        {
            appHost.Register<List<T>>($"wwwroot/data/{typeof(T).Name.ToLower()}s.csv"
                .MapHostAbsolutePath()
                .ReadAllText().FromCsv<List<T>>());
        }
    }
}
