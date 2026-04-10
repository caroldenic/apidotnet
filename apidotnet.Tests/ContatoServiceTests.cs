using Xunit;
using Moq;
using apidotnet.Services;
using apidotnet.Repositories.Interfaces;
using apidotnet.DTOs;
using apidotnet.Domain.Entities;
using apidotnet.Domain.Enums;

namespace apidotnet.Tests
{
    public class ContatoServiceTests
    {
        private readonly Mock<IContatoRepository> _repoMock;
        private readonly ContatoService _service;

        public ContatoServiceTests()
        {
            _repoMock = new Mock<IContatoRepository>();
            _service = new ContatoService(_repoMock.Object);
        }

        [Fact]
        public async Task Deve_Criar_Contato_Valido()
        {
            var dto = new ContatoCreateDto
            {
                Nome = "Carol",
                DataNascimento = DateTime.Today.AddYears(-25),
                Sexo = Sexo.Feminino
            };

            var result = await _service.Criar(dto);

            Assert.Equal("Carol", result.Nome);
            Assert.True(result.Idade >= 18);
        }

        [Fact]
        public async Task Deve_Erro_Se_Menor_De_Idade()
        {
            var dto = new ContatoCreateDto
            {
                Nome = "Teste",
                DataNascimento = DateTime.Today.AddYears(-10),
                Sexo = Sexo.Masculino
            };

            await Assert.ThrowsAsync<Exception>(() => _service.Criar(dto));
        }

        [Fact]
        public async Task Deve_Ativar_Contato()
        {
            var contato = new Contato
            {
                Id = 1,
                Nome = "Teste",
                DataNascimento = DateTime.Today.AddYears(-25),
                Ativo = false
            };

            _repoMock.Setup(r => r.ObterPorIdSemFiltro(1))
                     .ReturnsAsync(contato);

            await _service.Ativar(1);

            Assert.True(contato.Ativo);
        }
    }
}