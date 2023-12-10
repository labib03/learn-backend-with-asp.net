
using AutoMapper;

namespace latihan.api;

public class UserServices : IUserServices
{
    private static List<Users> users = new List<Users> 
    {
        new Users() {id= 0, Age = 25},
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
}
