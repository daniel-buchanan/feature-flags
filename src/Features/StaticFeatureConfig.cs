using System.Collections.Generic;
using System.Linq;

namespace feature_flags.Features {
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
}