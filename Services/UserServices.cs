
using AutoMapper;

namespace latihan.api;

public class UserServices : IUserServices
{
    private static List<Users> users = new List<Users> 
    {
        new Users() {id= 0, FirstName = "Jacob", LastName = "Franklin", Age = 25, Gender = Gender.Male},
        new Users() {id= 1, FirstName = "Labib", LastName= "Ansorudin", Age = 20}
    };

    private readonly IMapper _mapper;

    public UserServices(IMapper mapper)
    {
        _mapper = mapper;
    }
    public ResponseService<GetUserDTO> addUser(AddUserDTO payload)
    {
        var newUser = _mapper.Map<Users>(payload);
        newUser.id = users.Max(c => c.id) + 1;
        users.Add(newUser);

        var response = new ResponseService<GetUserDTO>();
        response.Success = true;

        return response;
    }

    public ResponseService<List<GetUserDTO>> getAllUsers()
    {
        var allUser = users.Select(c => _mapper.Map<GetUserDTO>(c)).ToList();

        var response = new ResponseService<List<GetUserDTO>>();
        response.Success = true;

        var dataResponseModel = new DataResponseModel<List<GetUserDTO>>();
        dataResponseModel.Total = allUser.Count();
        dataResponseModel.Data = allUser;
        response.Data = dataResponseModel;
        return response;
    }

    public ResponseService<GetUserDTO> getUserById(int id)
    {
        var response = new ResponseService<GetUserDTO>();

        var user = users.FirstOrDefault(p => p.id == id);
        if(user == null) 
        {   
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        
        response.Success = true;

        var dataResponseModel = new DataResponseModel<GetUserDTO>();
        dataResponseModel.Total = 1;
        dataResponseModel.Data = _mapper.Map<GetUserDTO>(user);
        response.Data = dataResponseModel;
        return response;
    }

    public ResponseService<GetUserDTO> updateUser(UpdateUserDTO payload)
    {
        var user = users.FirstOrDefault(u => u.id == payload.id);
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

        response.Success = true;
        response.Data = new DataResponseModel<GetUserDTO> 
            {
                Total = 1,
                Data = _mapper.Map<GetUserDTO>(user)
            };

        return response;
    }

    public ResponseService<List<GetUserDTO>> deleteUser(int id)
    {
        var response = new ResponseService<List<GetUserDTO>>();

        var user = users.FirstOrDefault(u => u.id == id);
        if(user is null){
            response.Success = false;
            response.Message = $"user with id: {id} is not found";
            return response;
        }

        users.Remove(user);
        response.Success = true;
        response.Data = new DataResponseModel<List<GetUserDTO>> 
            {
                Total = users.Count(),
                Data = users.Select(c => _mapper.Map<GetUserDTO>(c)).ToList()
            };

        return response;
    }
}
