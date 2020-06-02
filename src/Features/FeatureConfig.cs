using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace feature_flags.Features {
    public interface IFeatureConfig {
        IEnumerable<IFeatureFlag> All();
        IFeatureFlag Get(IFeature feature);
        bool MissingIsEnabled {get;}
    }

    public class StaticFeatureConfig : IFeatureConfig
    {
        private readonly List<IFeatureFlag> _flags;

        public StaticFeatureConfig() { 
            _flags = new List<IFeatureFlag>();
        }

        public StaticFeatureConfig(bool missingIsEnabled, IEnumerable<IFeatureFlag> flags)
        {
            MissingIsEnabled = missingIsEnabled;
            _flags = flags?.ToList() ?? new List<IFeatureFlag>();
        }

        public bool MissingIsEnabled {get;private set;}

        public IEnumerable<IFeatureFlag> All() => _flags.AsReadOnly();

        public IFeatureFlag Get(IFeature feature) => _flags.FirstOrDefault(f => f.Feature == feature);
    }

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

        private IFeatureFlag GetFlag(IFeature feature) {
            var found = _flags.FirstOrDefault(f => f.Feature == feature);
            if(found == null) return null;

            if(found.Expiry > DateTimeOffset.Now) return found.Flag;

            var enabled = GetProperty<bool>(Keys.Specific + feature.Name);
            found.Flag = new FeatureFlag(feature, _environment.EnvironmentName);
            found.Expiry = DateTimeOffset.Now.AddMinutes(CacheExpiryMinutes);

            return found.Flag;
        }

        public IEnumerable<IFeatureFlag> All() {
            var allFeatures = KnownFeatures.All();
            var flags = new List<IFeatureFlag>();

            foreach(var f in allFeatures) {
                flags.Add(GetFlag(f));
            }

            return flags;
        }

        public IFeatureFlag Get(IFeature feature) => GetFlag(feature);
    }
}