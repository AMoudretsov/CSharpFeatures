namespace CSharp6Features.Tests.AutoPropertyInitializers
{
    public class AutoPropertyContainer
    {
        public string ReadOnlyAutoProperty { get; } = nameof(ReadOnlyAutoProperty);

        public string AutoProperty { get; set; } = nameof(AutoProperty);

        public string NotInitializedReadOnlyAutoProperty { get; }

        public string NotInitializedAutoProperty { get; set; }
    }
}
