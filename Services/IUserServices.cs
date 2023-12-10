using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

public interface IUserServices
{
    ResponseService<List<GetUserDTO>> getAllUsers();
    ResponseService<GetUserDTO> getUserById(int id);
    ResponseService<GetUserDTO> addUser(AddUserDTO payload);
}
