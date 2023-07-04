namespace Pet.Commerce.Domain.Commands.Responses
{
    public class LoginUserResponse : Response
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Role { get; set; }
        public string Token { get; set; }
    }
}
