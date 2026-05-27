# ChatSignalR

Aplicação de chat em tempo real construída com ASP.NET Core e SignalR. Usuários conectados trocam mensagens instantaneamente, sem recarregar a página, usando WebSockets.

---

##  Tecnologias utilizadas

- [.NET 10](https://dotnet.microsoft.com/) — Framework principal
- [ASP.NET Core](https://learn.microsoft.com/aspnet/core) — Backend da aplicação
- [SignalR](https://learn.microsoft.com/aspnet/core/signalr/introduction) — Comunicação em tempo real via WebSockets
- HTML, CSS e JavaScript puro — Interface do cliente

---

##  Como executar o projeto

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)

### Passo a passo

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/ChatSignalR.git
cd ChatSignalR

# Execute o projeto
dotnet run
```

Acesse no navegador:
http://localhost:5096

Para testar o tempo real, **abra duas abas** com nomes de usuário diferentes e troque mensagens entre elas.

---

##  Funcionalidades

- Entrar no chat com nome de usuário
- Escolher entre três salas: Geral, VIP e Suporte
- Trocar de sala sem sair do chat
- Mensagens em tempo real para todos na mesma sala
- Notificação quando um usuário entra ou sai
- Indicador visual de conexão ativa
- Diferenciação visual entre suas mensagens e as dos outros

---

##  Como funciona

O SignalR mantém uma conexão persistente entre o navegador e o servidor via WebSockets. Quando um usuário envia uma mensagem, o servidor a repassa instantaneamente para todos os clientes conectados na mesma sala — sem necessidade de requisições HTTP adicionais.
Cliente A ──┐
Cliente B ──┼──► Hub (servidor) ──► todos na sala
Cliente C ──┘

O `ChatHub` gerencia as conexões e expõe três métodos:
- `EnviarMensagem` — envia para todos os conectados
- `EntrarNaSala` — adiciona o usuário a um grupo
- `EnviarMensagemParaSala` — envia apenas para o grupo

---

##  Conceitos aplicados

- **SignalR Hubs** — classe central que gerencia conexões e mensagens
- **WebSockets** — protocolo de comunicação bidirecional e persistente
- **Grupos de conexão** — sistema de salas com envio segmentado
- **Eventos de ciclo de vida** — `OnConnectedAsync` e `OnDisconnectedAsync`
- **Reconexão automática** — cliente reconecta automaticamente se cair
- **Arquivos estáticos** — servidor .NET servindo HTML/CSS/JS diretamente

---
