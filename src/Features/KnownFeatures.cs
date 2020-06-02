using System.Collections.Generic;

namespace feature_flags.Features {
    public static class KnownFeatures {
        public static IFeature TestOne => Feature.Create("TestOne", "This is a Test");
        public static IFeature TestTwo => Feature.Create("TestTwo", "This is a Test");

        public static IEnumerable<IFeature> All() {
            yield return TestOne;
            yield return TestTwo;
        }
    }
}