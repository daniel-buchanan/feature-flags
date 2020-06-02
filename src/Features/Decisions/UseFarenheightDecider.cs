namespace feature_flags.Features.Decisions {
    public interface IUseFarenheightDecider : IDecision { }

    public class UseFarenheightDecider : Decision, IUseFarenheightDecider
    {
        public UseFarenheightDecider(IFeatureHelper featureHelper) : base(featureHelper)
        {
        }

        public override bool MakeDecision()
        {
            return Features.IsEnabled(KnownFeatures.TestOne) && 
                   !Features.IsEnabled(KnownFeatures.TestTwo);
        }
    }
}