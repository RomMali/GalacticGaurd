using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IUserService
    {
        // Example operations for a registered user
        [OperationContract]
        bool RegisterUser(string username, string password, string email);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        bool UpdateProfile(string username, string newEmail, string newPassword);

        [OperationContract]
        bool IsUsernameAvailable(string username);

        [OperationContract]
        void Logout();
    }
}
