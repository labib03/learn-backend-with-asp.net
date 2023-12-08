using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

public interface IUserServices
{
    List<Users> getAllUsers();
    Users? getUserById(int id);
    string addUser(Users payload);
}
