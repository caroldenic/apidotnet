using apidotnet.Domain.Entities;
using apidotnet.DTOs;
using apidotnet.Repositories.Interfaces;
using apidotnet.Services.Interfaces;

namespace apidotnet.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;

        public ContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContatoResponseDto> Criar(ContatoCreateDto dto)
        {
            Validar(dto);

            var contato = new Contato
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Sexo = dto.Sexo
            };

            await _repository.Criar(contato);

            return Map(contato);
        }

        public async Task<List<ContatoResponseDto>> Listar()
        {
            var contatos = await _repository.Listar();
            return contatos.Select(Map).ToList();
        }

        public async Task<ContatoResponseDto> Obter(int id)
        {
            var contato = await _repository.ObterPorIdSemFiltro(id);
            if (contato == null) throw new Exception("Contato não encontrado");

            return Map(contato);
        }

        public async Task Desativar(int id)
        {
            var contato = await _repository.ObterPorId(id);
            if (contato == null) throw new Exception("Contato não encontrado");

            contato.Ativo = false;
            await _repository.Atualizar(contato);
        }

        public async Task Ativar(int id)
        {
            var contato = await _repository.ObterPorIdSemFiltro(id);
            if (contato == null) throw new Exception("Contato não encontrado");

            contato.Ativo = true;
            await _repository.Atualizar(contato);
        }

        public async Task Excluir(int id)
        {
            var contato = await _repository.ObterPorIdSemFiltro(id);
            if (contato == null) throw new Exception("Contato não encontrado");

            await _repository.Remover(contato);
        }

        private void Validar(ContatoCreateDto dto)
        {
            if (dto.DataNascimento > DateTime.Today)
                throw new Exception("Data inválida");

            var idade = DateTime.Today.Year - dto.DataNascimento.Year;

            if (idade < 18)
                throw new Exception("Contato deve ser maior de idade");

            if (idade == 0)
                throw new Exception("Idade inválida");
        }

        private ContatoResponseDto Map(Contato contato)
        {
            return new ContatoResponseDto
            {
                Id = contato.Id,
                Nome = contato.Nome,
                DataNascimento = contato.DataNascimento,
                Sexo = contato.Sexo,
                Idade = contato.Idade
            };
        }
    }
}