// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Util
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json.Linq;

    internal class ClientConfigurationManager : IClientConfigurationManager
    {
        /// <summary>
        /// Used to retrieve configuration values for the client.
        /// Input contains configuration keys defined in <see cref="ConfigurationKeys"/>.
        /// </summary>
        private Func<string, string> ConfigurationDelegate { get; set; }

        /// <summary>
        /// Used to retrieve configuration values from the environment variables.
        /// </summary>
        private static readonly Func<string, string> DefaultConfigurationDelegate = Environment.GetEnvironmentVariable;

        internal ClientConfigurationManager(Func<string, string> configurationDelegate = null)
        {
            this.ConfigurationDelegate = configurationDelegate ?? DefaultConfigurationDelegate;
        }

        public T GetConfiguration<T>(string variable, T defaultValue)
        {
            string value = this.ConfigurationDelegate(variable);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}