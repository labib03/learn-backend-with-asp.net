using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserServices _userServices;
    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet]
    public ActionResult<List<Users>> getAllUsers()
    {
        
        var result = _userServices.getAllUsers();

        var response = new ResponseSuccess<List<Users>>();
        response.message = "SUCCESS";
        response.data = result;

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Users> getUserById(int id)
    {
       var result = _userServices.getUserById(id);
        if(result == null) {
            var ResponseFailed = new ResponseFailed();
            ResponseFailed.message = "FAILED";
            ResponseFailed.why = $"user with id: {id} is not found.";
            return NotFound(ResponseFailed);
        }

        var response = new ResponseSuccess<Users> {message = "SUCCESS", data = result};
        return Ok(response);
    }

    [HttpPost]
    public ActionResult addUser(Users payload)
    {
        var result = _userServices.addUser(payload);
        
        if(result == "found"){
            var responseFailed = new ResponseFailed();
            responseFailed.message = "FAILED";
            responseFailed.why = $"id: {payload.id} is already used of other user";
            return BadRequest(responseFailed);
        }

        return Ok("User has been successfully created");
    }
}
