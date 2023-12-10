using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

public interface IUserServices
{
    List<GetUserDTO> getAllUsers();
    GetUserDTO? getUserById(int id);
    string addUser(AddUserDTO payload);
}
