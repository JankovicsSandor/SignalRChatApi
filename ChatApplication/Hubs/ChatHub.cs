using ChatApplication.Database;
using ChatApplication.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        private IUserDatabase _userDatabase;

        public ChatHub(IUserDatabase userDatabase)
        {
            _userDatabase = userDatabase;
        }

        public override Task OnConnectedAsync()
        {
            UserModel newUser = new UserModel();
            _userDatabase.AddNewUser(Context.ConnectionId, newUser);
            Clients.AllExcept(Context.ConnectionId).SendAsync("UserConnected", newUser);
            Clients.Caller.SendAsync("UserConnectionAccepted", newUser);
            Clients.Caller.SendAsync("UserList", _userDatabase.GetUserListInList());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Clients.All.SendAsync("UserDisconnected", _userDatabase.GetUser(Context.ConnectionId));
            return base.OnDisconnectedAsync(exception);
        }

        public Task ChangeUserName(string newName)
        {
            UserModel user = _userDatabase.GetUser(Context.ConnectionId);
            user.UserName = newName;
            return Clients.AllExcept(Context.ConnectionId).SendAsync("UserNameChanged", new UserNameChangedModel() { NewUserName = newName, UserId = user.Id });
        }
        public Task SendChatMessage(string message)
        {
            UserModel user = _userDatabase.GetUser(Context.ConnectionId);
            return Clients.AllExcept(Context.ConnectionId).SendAsync("ChatMessage", new ChatMessageModel() { SenderId = user.Id, Message = message });
        }

    }
}
