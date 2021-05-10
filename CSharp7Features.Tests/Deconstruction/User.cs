namespace CSharp7Features.Tests.Deconstruction
{
    public class User
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public void Deconstruct(out string userName, out string firstName, out string lastName)
        {
            userName = UserName;
            firstName = FirstName;
            lastName = LastName;
        }

        public void Deconstruct(out string userName, out string firstName, out string lastName, out string phoneNumber, out string email)
        {
            userName = UserName;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;
            email = Email;
        }
    }
}
