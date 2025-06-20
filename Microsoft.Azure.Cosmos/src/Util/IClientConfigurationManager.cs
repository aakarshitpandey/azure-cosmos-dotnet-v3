namespace Microsoft.Azure.Cosmos.Util
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface ClientConfigurationManager
    {
        public T GetConfiguration<T>(string variable, T defaultValue);
    }
}
