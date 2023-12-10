using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

public interface IUserServices
{
    ResponseService<List<GetUserDTO>> getAllUsers();
    ResponseService<GetUserDTO> getUserById(int id);
    ResponseService<GetUserDTO> addUser(AddUserDTO payload);
    ResponseService<GetUserDTO> updateUser(UpdateUserDTO payload);
    ResponseService<List<GetUserDTO>> deleteUser(int id);
}
