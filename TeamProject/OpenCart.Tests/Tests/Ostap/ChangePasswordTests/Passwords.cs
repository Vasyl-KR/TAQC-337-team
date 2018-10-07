namespace OpenCartTests.Tests.Ostap
{
    public static class Passwords
    {
        public const string Correct1 = "Qwerty1234/";
        public const string Correct2 = "Q1w2e3r4t5y6/";
        public const string Correct3 = "Asdfgh1234/";
        public const string TooShort = "Qwe";
        public const string TooLong = "Qwerty12345678901234567890/";
        public const string Empty = "";
        //public static readonly Passwords Correct1 = new Passwords("Qwerty1234/");
        //public static readonly Passwords Correct2 = new Passwords("Q1w2e3r4t5y6/");
        //public static readonly Passwords Correct3 = new Passwords("Asdfgh1234/");
        //public static readonly Passwords TooShort = new Passwords("Qwe");
        //public static readonly Passwords TooLong = new Passwords("Qwerty12345678901234567890/");
        //private Passwords(string value)
        //{
        //    Value = value;
        //}
        //public string Value { get; private set; }

        //public static implicit operator string(Passwords p) { return p.Value; }
    }
}
