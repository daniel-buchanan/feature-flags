using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace feature_flags.Features {
    public class DynamicFeatureConfig : IFeatureConfig
    {
        private const int CacheExpiryMinutes = 5;
        private readonly IWebHostEnvironment _environment;
        private readonly List<CachedFlag> _flags;

        public DynamicFeatureConfig(IWebHostEnvironment environment)
        {
            _environment = environment;
            _flags = new List<CachedFlag>();
        }

        private class CachedFlag {
            public IFeature Feature {get;set;}
            public IFeatureFlag Flag {get;set;}
            public DateTimeOffset Expiry {get;set;}
        }

        private class Keys {
            public const string MissingIsEnabled = "Features/Config/MissingIsEnabled";
            public const string Specific = "Feature/";
        }

        private T GetProperty<T>(string property) => throw new System.NotImplementedException();

        public bool MissingIsEnabled => GetProperty<bool>(Keys.MissingIsEnabled);

        public IEnumerable<IFeatureFlag> All() {
            var allFeatures = KnownFeatures.All();
            var flags = new List<IFeatureFlag>();

            flags.AddRange(allFeatures.Select(Get));

            return flags;
        }

        public IFeatureFlag Get(IFeature feature) {
            var found = _flags.FirstOrDefault(f => f.Feature == feature);
            if(found == null) return null;

            if(found.Expiry > DateTimeOffset.Now) return found.Flag;

            var enabled = GetProperty<bool>(Keys.Specific + feature.Name);
            found.Flag = new FeatureFlag(feature, _environment.EnvironmentName);
            found.Expiry = DateTimeOffset.Now.AddMinutes(CacheExpiryMinutes);

            return found.Flag;
        }
    }
}