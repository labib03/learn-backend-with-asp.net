using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<Users> users = new List<Users> 
    {
        new Users() {id= 0, Age = 25},
        new Users() {id= 1, FirstName = "Labib", LastName= "Ansorudin", Age = 20}
    };

    [HttpGet]
    public ActionResult<List<Users>> GetAllUsers()
    {
        
        ResponseSuccess<List<Users>> response = new ResponseSuccess<List<Users>> {message = "SUCCESS", data = users};
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Users> getUserById(int id)
    {
        var user = users.FirstOrDefault(p => p.id == id);
        if(user == null) {
            ResponseFailed ResponseFailed = new ResponseFailed() {message = "Failed", why = $"user with id: {id} is not found"};
            return NotFound(ResponseFailed);
        }

        ResponseSuccess<Users> response = new ResponseSuccess<Users> {message = "SUCCESS", data = user};
        return Ok(response);
    }

    [HttpPost]
    public ActionResult addUser(Users payload)
    {
        var user = users.FirstOrDefault(p => p.id == payload.id);
        if(user != null){
            ResponseFailed responseFailed = new ResponseFailed() {message = "FAILED", why = $"id: {payload.id} is already used of other user"};
            return BadRequest(responseFailed);
        }

        users.Add(payload);
        return Ok("User success created");
    }
}
