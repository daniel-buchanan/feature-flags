using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace feature_flags.Features {
    public interface IFeatureHelper {
        bool IsEnabled(IFeature feature);
    }

    public class FeatureHelper : IFeatureHelper
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IFeatureConfig _config;

        public FeatureHelper(IWebHostEnvironment environment,
            IFeatureConfig config)
        {
            _environment = environment;
            _config = config;
        }

        public bool IsEnabled(IFeature feature)
        {
            var flag = _config.Get(feature);
            if(flag == null) return _config.MissingIsEnabled;

            var environment = _environment.EnvironmentName;
            var enabledForEnvironment = flag.Environments.Contains(environment);
            return enabledForEnvironment && flag.Enabled;
        }
    }
}