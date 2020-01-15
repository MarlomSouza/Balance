using System.Text.RegularExpressions;

namespace Balance.Domain.VOs
{
    public class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Valiade(address);

            Address = address;
        }

        private static void Valiade(string address)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(address);
            DomainValidator.New().When(match.Success, "Email address is incorrect");
        }
    }
}