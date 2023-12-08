
namespace latihan.api;

public class UserServices : IUserServices
{
    private static List<Users> users = new List<Users> 
    {
        new Users() {id= 0, Age = 25},
        new Users() {id= 1, FirstName = "Labib", LastName= "Ansorudin", Age = 20}
    };
    public string addUser(Users payload)
    {
        var user = users.FirstOrDefault(p => p.id == payload.id);
        if(user != null){
            return "found";
        }

        users.Add(payload);
        return "success";
    }

    public List<Users> getAllUsers()
    {
        return users;
    }

    public Users? getUserById(int id)
    {
        var user = users.FirstOrDefault(p => p.id == id);
        if(user == null) 
        {
            return null;
        }

        return user;
    }
}
