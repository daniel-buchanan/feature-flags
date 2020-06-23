using System.Collections.Generic;

namespace feature_flags.Features
{
    public interface IFeatureConfig {
        IEnumerable<IFeatureFlag> All();
        IFeatureFlag Get(IFeature feature);
        bool MissingIsEnabled {get;}
    }
}