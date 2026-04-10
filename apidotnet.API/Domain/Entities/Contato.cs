using apidotnet.Domain.Enums;

namespace apidotnet.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public bool Ativo { get; set; } = true;

        public int Idade => CalcularIdade();

        private int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}