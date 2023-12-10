
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace latihan.api;

public class UserServices : IUserServices
{
    private static List<Users> users = new List<Users> 
    {
        new Users() {id= 0, FirstName = "Jacob", LastName = "Franklin", Age = 25, Gender = Gender.Male},
        new Users() {id= 1, FirstName = "Labib", LastName= "Ansorudin", Age = 20}
    };

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserServices(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ResponseService<List<GetUserDTO>>> getAllUsers()
    {
        var dbUsers = await _context.Users.ToListAsync();
        var allUser = dbUsers.Select(c => _mapper.Map<GetUserDTO>(c)).ToList();

        var response = new ResponseService<List<GetUserDTO>>
        {
            Success = true
        };

        var dataResponseModel = new DataResponseModel<List<GetUserDTO>>
        {
            Total = allUser.Count(),
            Data = allUser
        };
        response.Data = dataResponseModel;
        return response;
    }

    public async Task<ResponseService<GetUserDTO>> getUserById(int id)
    {
        var response = new ResponseService<GetUserDTO>();

        // bisa gini
        // var dbUsers = await _context.Users.ToListAsync();
        // var user = dbUsers.FirstOrDefault(p => p.id == id);

        // bisa juga gini
        var user = await _context.Users.FirstOrDefaultAsync(u => u.id == id);
        if(user == null) 
        {   
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        
        response.Success = true;

        var dataResponseModel = new DataResponseModel<GetUserDTO>
        {
            Total = 1,
            Data = _mapper.Map<GetUserDTO>(user)
        };
        response.Data = dataResponseModel;
        return response;
    }

    public async Task<ResponseService<GetUserDTO>> addUser(AddUserDTO payload)
    {
        var newUser = _mapper.Map<Users>(payload);

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        var response = new ResponseService<GetUserDTO>
        {
            Success = true
        };

        return response;
    }

    public async Task<ResponseService<GetUserDTO>> updateUser(UpdateUserDTO payload)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.id == payload.id);
        var response = new ResponseService<GetUserDTO>();

        if (user is null){
            response.Success = false;
            response.Message = $"user with id: {payload.id} is not found";
            return response;
        } 

        _mapper.Map(payload, user);   

        // user.FirstName = payload.FirstName;
        // user.LastName = payload.LastName;
        // user.Age = payload.Age;
        // user.Gender = payload.Gender;

        await _context.SaveChangesAsync();

        response.Success = true;
        response.Data = new DataResponseModel<GetUserDTO> 
            {
                Total = 1,
                Data = _mapper.Map<GetUserDTO>(user)
            };

        return response;
    }

    public async Task<ResponseService<List<GetUserDTO>>> deleteUser(int id)
    {
        var response = new ResponseService<List<GetUserDTO>>();

        var dbUsers = await  _context.Users.ToListAsync();
        var user = dbUsers.FirstOrDefault(u => u.id == id);
        if(user is null){
            response.Success = false;
            response.Message = $"user with id: {id} is not found";
            return response;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        response.Success = true;
        response.Data = new DataResponseModel<List<GetUserDTO>>
        {
            Total = await _context.Users.CountAsync(),
            Data = await _context.Users.Select(c => _mapper.Map<GetUserDTO>(c)).ToListAsync()
        };

        return response;
    }
}
