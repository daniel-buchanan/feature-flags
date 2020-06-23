namespace feature_flags.features.Decisions {
    public interface IChooser<TReturn>
    {
        TReturn Choose();
    }

    public interface IChooser<TReturn, TC1, TC2>  : IChooser<TReturn>
        where TC1 : TReturn
        where TC2 : TReturn { }

    public interface IChooser<TReturn, TC1, TC2, TC3> : IChooser<TReturn>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn { }

    public interface IChooser<TReturn, TC1, TC2, TC3, TC4> : IChooser<TReturn>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn { }

    public interface IChooser<TReturn, TC1, TC2, TC3, TC4, TC5> : IChooser<TReturn>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn
        where TC5 : TReturn { }

    public interface IChooser<TReturn, TC1, TC2, TC3, TC4, TC5, TC6> : IChooser<TReturn>
        where TC1 : TReturn
        where TC2 : TReturn
        where TC3 : TReturn
        where TC4 : TReturn
        where TC5 : TReturn
        where TC6 : TReturn { }
}