<div align="center">
  
# Entrega de Advanced Business Development with .NET


</div>

---

Neste repositório está presente o desenvolvimento da entrega da Global Solution de 2025 da matéria **Advanced Business Development with .NET** da faculdade FIAP, com o projeto se chamando **NebuloHub**.

### Membros do grupo:
- Erick Alves - <a href="https://github.com/Erick0105">Erick0105</a> - Rm 5568682
- Vicenzo Oliveira - <a href="https://github.com/fFukurou">fFukurou</a> - Rm 554833
- Luiz Henrique - <a href="https://github.com/LuizHNR">LuizHNR</a> - Rm 556864

---
# 🤖 API RESTful

Este é um projeto de uma API RESTful desenvolvida em **ASP.NET Core**, armazena os dados que serão necessario para o projeto, como as startups e usuarios.
O sistema simula uma plataforma de controle de dados, com integração a banco de dados Oracle e uso de validações robustas via **FluentValidation**.

---

## 📌 Rotas Disponíveis

Todas as rotas estão disponíveis no controlador, por Exemplo: usuario, startup, avaliacao, habilidade, possui

| Método | Rota                   | Descrição                             |
|--------|------------------------|---------------------------------------|
| GET    | `/api/v2/habilidade`      | Retorna todos as habilidade por pagina  |
| GET    | `/api/v2/habilidade/{id}`   | Retorna uma habilidade por ID            |
| POST   | `/api/v2/habilidade`       | Cria uma nova habilidade                  |
| PUT    | `/api/v2/habilidade/{id}`   | Atualiza uma habilidade existente         |
| DELETE | `/api/v2/habilidade/{id}`   | Remove uma habilidade do sistema          |


## Link Deploy

http://webapp-nebulohub.azurewebsites.net/

---

## 🏗️ Justificativa da Arquitetura

O projeto foi desenvolvido utilizando **arquitetura em camadas**, com inspiração em **Clean Architecture**, para garantir separação de responsabilidades, fácil manutenção e escalabilidade:

- **Domain** → contém as entidades, enums e regras de negócio principais.  
- **Application** → concentra os DTOs, validações com FluentValidation e casos de uso (Use Cases).  
- **Infrastructure** → responsável pela persistência dos dados, configuração do **Entity Framework Core** e integração com **Oracle Database**.  
- **API** → camada de apresentação, expondo os endpoints REST por meio de controllers.  

Essa abordagem permite **maior testabilidade**, **baixo acoplamento** e facilita futuras mudanças ou integrações.

---

## 🧰 Tecnologias Utilizadas

- **.NET 8.0**
- **.NET 8 Runtime**
- **Entity Framework Core 8**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Design`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Microsoft.EntityFrameworkCore.Proxies`
- **Oracle.EntityFrameworkCore** — Suporte ao Oracle Database  
- **FluentValidation.AspNetCore** — Validação de dados  
- **Swagger (Swashbuckle.AspNetCore + Filters + Annotations)** — Documentação da API  
- **AutoMapper** — Mapeamento entre entidades e DTOs  


---

## 🚀 Como Executar o Projeto

### ✅ Pré-requisitos

- .NET SDK 8.0 ou superior
- Banco de dados Oracle instalado ou acesso a instância remota
- Ferramenta como DBeaver, Oracle SQL Developer, etc. para gerenciar o Oracle
- Git
- Editor de código (Visual Studio ou VS Code)

---

### 📦 Clonar o projeto

```bash
git clone https://github.com/NebuloHub/.NET.git
cd NebuloHub.NET
```

---

### Entrar no visual studio e selecionar o projeto, swagger somente liberado para o ambiente de desenvolvimento

- Apertar run para executar o projeto
 ```bash
    http://localhost:5100/swagger
```


- Selecionar a versão que você deseja testar, a versão 2 possui todos os Cruds de todas as Entidades
  <img width="1351" height="104" alt="image" src="https://github.com/user-attachments/assets/cbb2183b-0b96-4b75-b852-d4fe9ef98aa7" />


- O projeto possui nivel de acessos então para algumas coisas você precisa ter autorização de Admin

- Selecione o post do crud de Auth
  <img width="1325" height="153" alt="image" src="https://github.com/user-attachments/assets/7337adb0-0ebc-4422-b78b-ffb19b2ab914" />
  
   ```bash
   {
    "email": "luizhneri12@gmail.com",
    "senha": "Carrinhos@1234"
  }
  ```

- A resposta sera um token você copia ele e cola para se cadastrar no swagger
  <img width="1353" height="646" alt="image" src="https://github.com/user-attachments/assets/05861d22-9813-4e75-90d6-9b4db58a66d4" />

- Após isso você pode utilizar qualquer Crud de forma livre

- Para utilizar o Health Check você pode rodar a API e colocar na aba de pesquisa:
 ```bash
    http://localhost:5100/health-ui
```

 ```bash
    http://localhost:5100/health
```

- Ou, 5000 para produção 
 ```bash
    http://localhost:5000/health
```

 ```bash
    http://localhost:5000/health-ui
```


- Foi utilizado somente testes unitarios, para rodar voce pode ir no terminal

```bash
    dotnet test
```

- Ou pelo gerenciador de testes

<img width="1059" height="700" alt="image" src="https://github.com/user-attachments/assets/c903e400-5c72-47d4-9574-b2c290fbd96f" />

---

Caminho para o dll e .exe

```bash
    \.NET\NebuloHub\bin\Debug\net8.0\NebuloHub.dll
```

```bash
    \.NET\NebuloHub\bin\Debug\net8.0\NebuloHub.exe
```

---

### Nosso Professor:

###### Thiago Keller Torquato Vicco	

