using apidotnet.Domain.Enums;

namespace apidotnet.DTOs
{
    public class ContatoCreateDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
    }
}