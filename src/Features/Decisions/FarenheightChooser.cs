using feature_flags.features.Decisions;

namespace feature_flags.Decisions {
    public class FarenheightChooser : Chooser<int, int, int>
    {
        public FarenheightChooser() : base(5, 10)
        {
        }

        public override int Choose()
        {
            if(false) return FirstChoice;
            else return SecondChoice;
        }
    }
}