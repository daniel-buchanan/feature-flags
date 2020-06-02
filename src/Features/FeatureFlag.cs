using System.Collections.Generic;

namespace feature_flags.Features {
    public interface IFeatureFlag {
        IFeature Feature {get;}
        IEnumerable<string> Environments {get;}
        bool Enabled {get;}
    }

    public class FeatureFlag : IFeatureFlag
    {
        public IFeature Feature {get;private set;}

        public IEnumerable<string> Environments {get;private set;}

        public bool Enabled {get;private set;}

        public FeatureFlag(IFeature feature, IEnumerable<string> environments, bool enabled = true)
        {
            Feature = feature;
            Environments = environments;
            Enabled = enabled;

            if(Environments == null) Environments = new string[0];
        }

        public FeatureFlag(IFeature feature, string environment, bool enabled = true) 
            : this(feature, new[] { environment }, enabled) { }
    }
}