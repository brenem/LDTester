using OpenFeature;
using OpenFeature.Constant;
using OpenFeature.Model;

namespace FeatureManagement
{
    public class FeatureFlagClient(IFeatureClient featureClient) : IFeatureFlagClient
    {
        public void AddHandler(ProviderEventTypes type, EventHandlerDelegate handler)
        {
            featureClient.AddHandler(type, handler);
        }

        public void AddHooks(IEnumerable<Hook> hooks)
        {
            featureClient.AddHooks(hooks);
        }

        public Task<FlagEvaluationDetails<bool>> GetBooleanDetails(string flagKey, bool defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetBooleanDetails(flagKey, defaultValue, context, config);
        }

        public Task<bool> GetBooleanValue(string flagKey, bool defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetBooleanValue(flagKey, defaultValue, context, config);
        }

        public EvaluationContext GetContext()
        {
            return featureClient.GetContext();
        }

        public Task<FlagEvaluationDetails<double>> GetDoubleDetails(string flagKey, double defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetDoubleDetails(flagKey, defaultValue, context, config);
        }

        public Task<double> GetDoubleValue(string flagKey, double defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetDoubleValue(flagKey, defaultValue, context, config);
        }

        public IEnumerable<Hook> GetHooks()
        {
            return featureClient.GetHooks();
        }

        public Task<FlagEvaluationDetails<int>> GetIntegerDetails(string flagKey, int defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetIntegerDetails(flagKey, defaultValue, context, config);
        }

        public Task<int> GetIntegerValue(string flagKey, int defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetIntegerValue(flagKey, defaultValue, context, config);
        }

        public ClientMetadata GetMetadata()
        {
            return featureClient.GetMetadata();
        }

        public Task<FlagEvaluationDetails<Value>> GetObjectDetails(string flagKey, Value defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetObjectDetails(flagKey, defaultValue, context, config);
        }

        public Task<Value> GetObjectValue(string flagKey, Value defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetObjectValue(flagKey, defaultValue, context, config);
        }

        public Task<FlagEvaluationDetails<string>> GetStringDetails(string flagKey, string defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetStringDetails(flagKey, defaultValue, context, config);
        }

        public Task<string> GetStringValue(string flagKey, string defaultValue, EvaluationContext context = null, FlagEvaluationOptions config = null)
        {
            return featureClient.GetStringValue(flagKey, defaultValue, context, config);
        }

        public void RemoveHandler(ProviderEventTypes type, EventHandlerDelegate handler)
        {
            featureClient.RemoveHandler(type, handler);
        }

        public void SetContext(EvaluationContext context)
        {
            featureClient.SetContext(context);
        }
    }
}
