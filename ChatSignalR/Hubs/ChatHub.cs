using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR.Hubs;

public class ChatHub : Hub
{
    // Chamado quando um usuário envia mensagem para todos
    public async Task EnviarMensagem(string usuario, string mensagem)
    {
        await Clients.All.SendAsync("ReceberMensagem", usuario, mensagem);
    }

    // Chamado quando um usuário entra em uma sala
    public async Task EntrarNaSala(string usuario, string sala)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, sala);
        await Clients.Group(sala).SendAsync("ReceberMensagem", "Sistema", $"{usuario} entrou na sala {sala}");
    }

    // Chamado quando um usuário envia mensagem para uma sala específica
    public async Task EnviarMensagemParaSala(string usuario, string sala, string mensagem)
    {
        await Clients.Group(sala).SendAsync("ReceberMensagem", usuario, mensagem);
    }

    // Disparado automaticamente quando um cliente conecta
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceberMensagem", "Sistema", $"Um novo usuário conectou. Total online: {GetConnectionCount()}");
        await base.OnConnectedAsync();
    }

    // Disparado automaticamente quando um cliente desconecta
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("ReceberMensagem", "Sistema", "Um usuário saiu do chat");
        await base.OnDisconnectedAsync(exception);
    }

    private string GetConnectionCount()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }
}