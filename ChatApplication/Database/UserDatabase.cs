using ChatApplication.Models;

namespace ChatApplication.Database
{
    public class UserDatabase: IUserDatabase
    {
        public Dictionary<string, UserModel> _userList;

        public UserDatabase()
        {
            _userList = new Dictionary<string, UserModel>();
        }

        public UserModel GetUser(string conntectionId)
        {
            return _userList[conntectionId];
        }

        public IEnumerable<UserModel> GetUserListInList()
        {
            return _userList.Select(e => e.Value).ToList();
        }

        public void UpdateUser(string connectionId,UserModel newModel)
        {
            _userList[connectionId] = newModel;
        }

        public void AddNewUser(string conntectionId, UserModel newModel)
        {
            _userList.Add(conntectionId, newModel);
        }

    }
}
