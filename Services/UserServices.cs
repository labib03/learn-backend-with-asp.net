
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
    public string addUser(AddUserDTO payload)
    {
        var newUser = _mapper.Map<Users>(payload);
        newUser.id = users.Max(c => c.id) + 1;
        var user = users.FirstOrDefault(p => p.id == newUser.id);
        if(user != null){
            return "found";
        }

        users.Add(newUser);
        return "success";
    }

    public List<GetUserDTO> getAllUsers()
    {
        return users.Select(c => _mapper.Map<GetUserDTO>(c)).ToList();
    }

    public GetUserDTO? getUserById(int id)
    {
        var user = users.FirstOrDefault(p => p.id == id);
        if(user == null) 
        {
            return null;
        }

        return _mapper.Map<GetUserDTO>(user);
    }
}
