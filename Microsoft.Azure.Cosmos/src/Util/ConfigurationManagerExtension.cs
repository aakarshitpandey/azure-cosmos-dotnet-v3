//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Azure.Cosmos
{
    using System;
    using Microsoft.Azure.Cosmos.Util;

    internal static class ConfigurationManagerExtension
    {
        public static int GetMaxRetriesInLocalRegionWhenRemoteRegionPreferred(this ClientConfigurationManager clientConfigurationManager)
        {
            return Math.Max(
                clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.MaxRetriesInLocalRegionWhenRemoteRegionPreferred,
                        defaultValue: ConfigurationKeys.DefaultMaxRetriesInLocalRegionWhenRemoteRegionPreferred),
                ConfigurationKeys.MinMaxRetriesInLocalRegionWhenRemoteRegionPreferred);
        }

        public static TimeSpan GetMinRetryTimeInLocalRegionWhenRemoteRegionPreferred(this ClientConfigurationManager clientConfigurationManager)
        {
            return TimeSpan.FromMilliseconds(Math.Max(
                clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.MinInRegionRetryTimeForWritesInMs,
                        defaultValue: ConfigurationKeys.DefaultMinInRegionRetryTimeForWritesInMs),
                ConfigurationKeys.MinMinInRegionRetryTimeForWritesInMs));
        }

        /// <summary>
        /// Gets the boolean value of the replica validation environment variable. Note that, replica validation
        /// is enabled by default for the preview package and disabled for GA at the moment. The user can set the
        /// respective environment variable 'AZURE_COSMOS_REPLICA_VALIDATION_ENABLED' to override the value for
        /// both preview and GA. The method will eventually be removed, once replica valdiatin is enabled by default
        /// for  both preview and GA.
        /// </summary>
        /// <param name="clientConfigurationManager"></param>
        /// <param name="connectionPolicy">An instance of <see cref="ConnectionPolicy"/> containing the client options.</param>
        /// <returns>A boolean flag indicating if replica validation is enabled.</returns>
        public static bool IsReplicaAddressValidationEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            ConnectionPolicy connectionPolicy)
        {
            if (connectionPolicy != null
                && connectionPolicy.EnableAdvancedReplicaSelectionForTcp.HasValue)
            {
                return connectionPolicy.EnableAdvancedReplicaSelectionForTcp.Value;
            }

            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.ReplicaConnectivityValidationEnabled,
                        defaultValue: true);
        }

        /// <summary>
        /// Gets the boolean value of the partition level failover environment variable. Note that, partition level failover
        /// is disabled by default for both preview and GA releases. The user can set the  respective environment variable
        /// 'AZURE_COSMOS_PARTITION_LEVEL_FAILOVER_ENABLED' to override the value for both preview and GA. The method will
        /// eventually be removed, once partition level failover is enabled by default for  both preview and GA.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">A boolean field containing the default value for partition level failover.</param>
        /// <returns>A boolean flag indicating if partition level failover is enabled.</returns>
        public static bool IsPartitionLevelFailoverEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.PartitionLevelFailoverEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating whether the thin client mode is enabled based on the environment variable override.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">A boolean field containing the default value for thin client mode.</param>
        /// <returns>A boolean flag indicating if thin client mode is enabled.</returns>
        public static bool IsThinClientEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.ThinClientModeEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value of the partition level circuit breaker environment variable. Note that, partition level
        /// circuit breaker is disabled by default for both preview and GA releases. The user can set the respective
        /// environment variable 'AZURE_COSMOS_PARTITION_LEVEL_CIRCUIT_BREAKER_ENABLED' to override the value for both preview and GA.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">A boolean field containing the default value for partition level circuit breaker.</param>
        /// <returns>A boolean flag indicating if partition level circuit breaker is enabled.</returns>
        public static bool IsPartitionLevelCircuitBreakerEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.PartitionLevelCircuitBreakerEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the interval time in seconds for refreshing stale partition unavailability.
        /// The default value for this interval is 60 seconds. The user can set the respective
        /// environment variable 'AZURE_COSMOS_PPCB_STALE_PARTITION_UNAVAILABILITY_REFRESH_INTERVAL_IN_SECONDS'
        /// to override the value.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">An integer containing the default value for the refresh interval in seconds.</param>
        /// <returns>An integer representing the refresh interval in seconds.</returns>
        public static int GetStalePartitionUnavailabilityRefreshIntervalInSeconds(
            this ClientConfigurationManager clientConfigurationManager,
            int defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.StalePartitionUnavailabilityRefreshIntervalInSeconds,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the allowed partition unavailability duration in seconds.
        /// The default value for this duration is 5 seconds. The user can set the respective
        /// environment variable 'AZURE_COSMOS_PPCB_ALLOWED_PARTITION_UNAVAILABILITY_DURATION_IN_SECONDS'
        /// to override the value.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">An integer containing the default unavailability duration in seconds.</param>
        /// <returns>An integer representing the allowed partition unavailability duration in seconds.</returns>
        public static int GetAllowedPartitionUnavailabilityDurationInSeconds(
            this ClientConfigurationManager clientConfigurationManager,
            int defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.AllowedPartitionUnavailabilityDurationInSeconds,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the consecutive failure count for reads before triggering the per partition circuit breaker flow.
        /// The default value for this interval is 10 consecutive requests within a 1-minute window.
        /// The user can set the respective environment variable 'AZURE_COSMOS_PPCB_CONSECUTIVE_FAILURE_COUNT_FOR_READS' to override the value.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">An integer containing the default value for the consecutive failure count.</param>
        /// <returns>An integer representing the consecutive failure count for reads.</returns>
        public static int GetCircuitBreakerConsecutiveFailureCountForReads(
            this ClientConfigurationManager clientConfigurationManager,
            int defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.CircuitBreakerConsecutiveFailureCountForReads,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the consecutive failure count for writes (applicable for multi master accounts) before triggering
        /// the per partition circuit breaker flow. The default value for this interval is 5 consecutive requests within a 1-minute window.
        /// The user can set the respective environment variable 'AZURE_COSMOS_PPCB_CONSECUTIVE_FAILURE_COUNT_FOR_WRITES' to override the value.
        /// </summary>
        /// <param name="clientConfigurationManager">Configuration manager instance for the client.</param>
        /// <param name="defaultValue">An integer containing the default value for the consecutive failure count.</param>
        /// <returns>An integer representing the consecutive failure count for writes.</returns>
        public static int GetCircuitBreakerConsecutiveFailureCountForWrites(
            this ClientConfigurationManager clientConfigurationManager,
            int defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.CircuitBreakerConsecutiveFailureCountForWrites,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating whether optimistic direct execution is enabled based on the environment variable override.
        /// </summary>
        public static bool IsOptimisticDirectExecutionEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.OptimisticDirectExecutionEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating whether the hybrid search query plan optimization feature flag should be sent to the gateway
        /// based on the environment variable override.
        /// </summary>
        public static bool IsHybridSearchQueryPlanOptimizationDisabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.HybridSearchQueryPlanOptimizationDisabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating if distributed query gateway mode is enabled
        /// based on the environment variable override.
        /// </summary>
        public static bool IsDistributedQueryGatewayModeEnabled(
            this ClientConfigurationManager clientConfigurationManager,
            bool defaultValue)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.DistributedQueryGatewayModeEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating if binary encoding is enabled based on the environment variable override.
        /// Note that binary encoding is disabled by default for both preview and GA releases. The user can set the
        /// respective environment variable 'AZURE_COSMOS_BINARY_ENCODING_ENABLED' to override the value for both preview and GA.
        /// This method will eventually be removed once binary encoding is enabled by default for both preview and GA.
        /// </summary>
        /// <returns>A boolean flag indicating if binary encoding is enabled.</returns>
        public static bool IsBinaryEncodingEnabled(this ClientConfigurationManager clientConfigurationManager)
        {
            bool defaultValue = false;
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.BinaryEncodingEnabled,
                        defaultValue: defaultValue);
        }

        /// <summary>
        /// Gets the boolean value indicating if channel multiplexing enabled on TCP channel.
        /// Default: false
        /// </summary>
        /// <returns>A boolean flag indicating if channel multiplexing is enabled.</returns>
        public static bool IsTcpChannelMultiplexingEnabled(this ClientConfigurationManager clientConfigurationManager)
        {
            return clientConfigurationManager
                    .GetConfiguration(
                        variable: ConfigurationKeys.TcpChannelMultiplexingEnabled,
                        defaultValue: false);
        }
    }
}
