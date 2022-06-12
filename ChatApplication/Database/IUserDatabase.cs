using ChatApplication.Models;

namespace ChatApplication.Database
{
    public interface IUserDatabase
    {
        void AddNewUser(string conntectionId, UserModel newModel);
        UserModel GetUser(string id);
        IEnumerable<UserModel> GetUserListInList();
        void UpdateUser(string id, UserModel newModel);
    }
}
