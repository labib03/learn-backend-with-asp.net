using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

public interface IUserServices
{
    Task<ResponseService<List<GetUserDTO>>> getAllUsers();
    Task<ResponseService<GetUserDTO>> getUserById(int id);
    Task<ResponseService<GetUserDTO>> addUser(AddUserDTO payload);
    Task<ResponseService<GetUserDTO>> updateUser(UpdateUserDTO payload);
    Task<ResponseService<List<GetUserDTO>>> deleteUser(int id);
}
