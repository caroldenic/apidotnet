using apidotnet.Domain.Enums;

namespace apidotnet.DTOs
{
    public class ContatoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public int Idade { get; set; }
    }
}