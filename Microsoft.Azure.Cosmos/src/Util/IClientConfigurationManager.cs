namespace Microsoft.Azure.Cosmos.Util
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface IClientConfigurationManager
    {
        public T GetConfiguration<T>(string variable, T defaultValue);
    }
}
