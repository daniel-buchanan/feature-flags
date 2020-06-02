namespace feature_flags.Features.Decisions {
    public interface IDecision {
        bool MakeDecision();
    }

    public abstract class Decision : IDecision
    {
        protected IFeatureHelper Features {get;private set;}

        protected Decision(IFeatureHelper featureHelper)
        {
            Features = featureHelper;
        }

        public abstract bool MakeDecision();
    }
}