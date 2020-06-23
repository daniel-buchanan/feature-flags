namespace feature_flags.features.Decisions {
    public abstract class Chooser<TReturn, TC1, TC2> : IChooser<TReturn, TC1, TC2>
        where TC1 : TReturn
        where TC2 : TReturn
    {
        protected TC1 FirstChoice {get;set;}
        protected TC2 SecondChoice {get;set;}

        protected Chooser(TC1 firstChoice, TC2 secondChoice)
        {
            FirstChoice = firstChoice;
            SecondChoice = secondChoice;
        }

        public abstract TReturn Choose();
    }

    public abstract class Chooser<TReturn, TC1, TC2, TC3> 
        : Chooser<TReturn, TC1, TC2>, IChooser<TReturn, TC1, TC2, TC3>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
    {
        protected TC3 ThirdChoice { get; set; }

        protected Chooser(TC1 firstChoice, TC2 secondChoice, TC3 thirdChoice) 
            : base(firstChoice, secondChoice)
        {
            ThirdChoice = thirdChoice;
        }
    }

    public abstract class Chooser<TReturn, TC1, TC2, TC3, TC4> 
        : Chooser<TReturn, TC1, TC2, TC3>, IChooser<TReturn, TC1, TC2, TC3, TC4>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn
    {
        protected TC4 FourthChoice { get; set; }

        protected Chooser(TC1 firstChoice, TC2 secondChoice, TC3 thirdChoice, TC4 fourthChoice) 
            : base(firstChoice, secondChoice, thirdChoice)
        {
            FourthChoice = fourthChoice;
        }
    }

    public abstract class Chooser<TReturn, TC1, TC2, TC3, TC4, TC5> 
        : Chooser<TReturn, TC1, TC2, TC3, TC4>, IChooser<TReturn, TC1, TC2, TC3, TC4, TC5>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn
        where TC5 : TReturn
    {
        protected TC5 FifthChoice { get; set; }

        protected Chooser(TC1 firstChoice, TC2 secondChoice, TC3 thirdChoice, TC4 fourthChoice, TC5 fifthChoice) 
            : base(firstChoice, secondChoice, thirdChoice, fourthChoice)
        {
            FifthChoice = fifthChoice;
        }
    }

    public abstract class Chooser<TReturn, TC1, TC2, TC3, TC4, TC5, TC6>
        : Chooser<TReturn, TC1, TC2, TC3, TC4, TC5>, IChooser<TReturn, TC1, TC2, TC3, TC4, TC5, TC6>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn
        where TC5 : TReturn
        where TC6 : TReturn
    {
        protected TC6 SixthChoice { get; set; }

        protected Chooser(TC1 firstChoice, TC2 secondChoice, TC3 thirdChoice, TC4 fourthChoice, TC5 fifthChoice, TC6 sixthChoice)
            : base(firstChoice, secondChoice, thirdChoice, fourthChoice, fifthChoice)
        {
            SixthChoice = sixthChoice;
        }
    }
}