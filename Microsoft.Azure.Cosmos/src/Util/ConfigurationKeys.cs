// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Util
{
    internal class ConfigurationKeys
    {
        /// <summary>
        /// A read-only string containing the environment variable name for enabling replica validation.
        /// This will eventually be removed once replica validation is enabled by default for both preview
        /// and GA.
        /// </summary>
        internal static readonly string ReplicaConnectivityValidationEnabled = "AZURE_COSMOS_REPLICA_VALIDATION_ENABLED";

        /// <summary>
        /// A read-only string containing the environment variable name for enabling per partition automatic failover.
        /// This will eventually be removed once per partition automatic failover is enabled by default for both preview
        /// and GA.
        /// </summary>
        internal static readonly string PartitionLevelFailoverEnabled = "AZURE_COSMOS_PARTITION_LEVEL_FAILOVER_ENABLED";

        /// <summary>
        /// A read-only string containing the environment variable name for enabling per partition circuit breaker. The default value
        /// for this flag is false.
        /// </summary>
        internal static readonly string PartitionLevelCircuitBreakerEnabled = "AZURE_COSMOS_CIRCUIT_BREAKER_ENABLED";

        /// <summary>
        /// A read-only string containing the environment variable name for capturing the stale partition refresh task interval time
        /// in seconds. The default value for this interval is 60 seconds.
        /// </summary>
        internal static readonly string StalePartitionUnavailabilityRefreshIntervalInSeconds = "AZURE_COSMOS_PPCB_STALE_PARTITION_UNAVAILABILITY_REFRESH_INTERVAL_IN_SECONDS";

        /// <summary>
        /// A read-only string containing the environment variable name for capturing the unavailability duration applicable for a failed partition
        /// before the partition can be considered for a refresh by the background task.
        /// </summary>
        internal static readonly string AllowedPartitionUnavailabilityDurationInSeconds = "AZURE_COSMOS_PPCB_ALLOWED_PARTITION_UNAVAILABILITY_DURATION_IN_SECONDS";

        /// <summary>
        /// Environment variable name to enable thin client mode.
        /// </summary>
        internal static readonly string ThinClientModeEnabled = "AZURE_COSMOS_THIN_CLIENT_ENABLED";

        /// <summary>
        /// A read-only string containing the environment variable name for capturing the consecutive failure count for reads, before triggering per partition
        /// circuit breaker flow. The default value for this interval is 10 consecutive requests within 1 min window.
        /// </summary>
        internal static readonly string CircuitBreakerConsecutiveFailureCountForReads = "AZURE_COSMOS_PPCB_CONSECUTIVE_FAILURE_COUNT_FOR_READS";

        /// <summary>
        /// A read-only string containing the environment variable name for capturing the consecutive failure count for writes, before triggering per partition
        /// circuit breaker flow. The default value for this interval is 10 consecutive requests within 1 min window.
        /// </summary>
        internal static readonly string CircuitBreakerConsecutiveFailureCountForWrites = "AZURE_COSMOS_PPCB_CONSECUTIVE_FAILURE_COUNT_FOR_WRITES";

        /// <summary>
        /// Environment variable name for overriding optimistic direct execution of queries.
        /// </summary>
        internal static readonly string OptimisticDirectExecutionEnabled = "AZURE_COSMOS_OPTIMISTIC_DIRECT_EXECUTION_ENABLED";

        /// <summary>
        /// Environment variable name to disable sending non streaming order by query feature flag to the gateway.
        /// </summary>
        internal static readonly string HybridSearchQueryPlanOptimizationDisabled = "AZURE_COSMOS_HYBRID_SEARCH_QUERYPLAN_OPTIMIZATION_DISABLED";

        /// <summary>
        /// Environment variable name to enable distributed query gateway mode.
        /// </summary>
        internal static readonly string DistributedQueryGatewayModeEnabled = "AZURE_COSMOS_DISTRIBUTED_QUERY_GATEWAY_ENABLED";

        /// <summary>
        /// intent is If a client specify a value, we will force it to be atleast 100ms, otherwise default is going to be 500ms
        /// </summary>
        internal static readonly string MinInRegionRetryTimeForWritesInMs = "AZURE_COSMOS_SESSION_TOKEN_MISMATCH_IN_REGION_RETRY_TIME_IN_MILLISECONDS";
        internal static readonly int DefaultMinInRegionRetryTimeForWritesInMs = 500;
        internal static readonly int MinMinInRegionRetryTimeForWritesInMs = 100;

        /// <summary>
        /// intent is If a client specify a value, we will force it to be atleast 1, otherwise default is going to be 1(right now both the values are 1 but we have the provision to change them in future).
        /// </summary>
        internal static readonly string MaxRetriesInLocalRegionWhenRemoteRegionPreferred = "AZURE_COSMOS_MAX_RETRIES_IN_LOCAL_REGION_WHEN_REMOTE_REGION_PREFERRED";
        internal static readonly int DefaultMaxRetriesInLocalRegionWhenRemoteRegionPreferred = 1;
        internal static readonly int MinMaxRetriesInLocalRegionWhenRemoteRegionPreferred = 1;

        /// <summary>
        /// A read-only string containing the environment variable name for enabling binary encoding. This will eventually
        /// be removed once binary encoding is enabled by default for both preview
        /// and GA.
        /// </summary>
        internal static readonly string BinaryEncodingEnabled = "AZURE_COSMOS_BINARY_ENCODING_ENABLED";

        /// <summary>
        /// A read-only string containing the environment variable name for enabling binary encoding. This will eventually
        /// be removed once binary encoding is enabled by default for both preview
        /// and GA.
        /// </summary>
        internal static readonly string TcpChannelMultiplexingEnabled = "AZURE_COSMOS_TCP_CHANNEL_MULTIPLEX_ENABLED";
    }
}
