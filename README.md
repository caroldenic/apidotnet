# 📌 API de Contatos - .NET 8

API REST desenvolvida em **.NET 8** para gerenciamento de contatos com **SQL Server**.

---

# 🚀 Tecnologias Utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core (LINQ to Entities)
* SQL Server
* Swagger
* xUnit 

---

# ⚙️ Configuração do Projeto

## 🔧 Pré-requisitos

* .NET 8 SDK
* SQL Server (instância local)

---

# 🗄️ Banco de Dados (SQL Server Local)

⚠️ **IMPORTANTE:**
Este projeto foi configurado para rodar com **SQL Server LOCAL**, ou seja, instalado na sua máquina.

👉 Exemplos válidos de servidor:

* `localhost`
* `localhost\SQLEXPRESS`

---

## 📌 1. Criar banco de dados

Abra o SQL Server Management Studio, cole o conteúdo de banco.sql que se encontra na raiz do projeto e execute

---

## 📌 2. Configurar conexão

No arquivo `appsettings.json`:

```json id="conn01"
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=apidotnet;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## 🧠 Observações importantes

* `Trusted_Connection=True` → usa autenticação do Windows
* Não é necessário usuário/senha para ambiente local
* Certifique-se de que o serviço do SQL Server está em execução

---


# 📦 Instalação

```bash id="lhufxe"
git clone https://github.com/seu-usuario/apidotnet.git
cd apidotnet
dotnet restore
```

---

# ▶️ Executar aplicação

```bash id="run01"
dotnet run
```

---

# 🌐 Acessar Swagger

```id="swagger01"
https://localhost:xxxx/swagger
```

---

# 📌 Funcionalidades

* Criar contato
* Listar contatos ativos
* Visualizar detalhes de contato
* Desativar contato (soft delete)
* Ativar contato
* Excluir contato

---

# 📊 Regras de Negócio

* Contato deve ser maior de idade (≥ 18 anos)
* Idade é calculada em tempo de execução
* Data de nascimento não pode ser futura
* Apenas contatos ativos são retornados na listagem
* Exclusão lógica via campo `Ativo`

---

# 🔁 Endpoints

| Método | Rota                         | Descrição              |
| ------ | ---------------------------- | ---------------------- |
| POST   | /api/contatos                | Criar contato          |
| GET    | /api/contatos                | Listar contatos ativos |
| GET    | /api/contatos/{id}           | Detalhar contato       |
| PATCH  | /api/contatos/{id}/desativar | Desativar contato      |
| PATCH  | /api/contatos/{id}/ativar    | Ativar contato         |
| DELETE | /api/contatos/{id}           | Excluir contato        |

---

# 🧪 Testes

```bash id="test01"
dotnet test
```
