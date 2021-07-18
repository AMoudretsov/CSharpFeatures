namespace CSharp80Features.Tests.ReadOnlyStructMembers
{
    public struct Repeater
    {
        private string _value;

        public string Value
        {
            readonly get => _value;
            set => _value = value.ToUpper();
        }

        public readonly string Twice() => $"{_value}{_value}";

        public readonly string Trice() => $"{Value}{Value}{Value}";

        public readonly string FourFold()
        {
            // Commented assignment causes build error, since readonly method cannot modify state.
            // _value = _value.ToLower();

            return $"{_value}{_value}{_value}{_value}";
        }
    }
}
