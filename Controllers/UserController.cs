using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace latihan.api;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserServices _userServices;
    public readonly IMapper _mapper;
    public UserController(IUserServices userServices, IMapper mapper)
    {
        _userServices = userServices;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<ResponseService<List<GetUserDTO>>> getAllUsers()
    {
        
        var result = _userServices.getAllUsers();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<ResponseService<GetUserDTO>> getUserById(int id)
    {
       var result = _userServices.getUserById(id);
        if(result.Data is null) {
            result.Message = $"user with id: {id} is not found";
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<ResponseService<GetUserDTO>> addUser(AddUserDTO payload)
    {
        var result = _userServices.addUser(payload);

        return Ok(result);
    }

    [HttpPut]
    public ActionResult<ResponseService<GetUserDTO>> updateUser(UpdateUserDTO payload)
    {
        var result = _userServices.updateUser(payload);

        if(result.Data is null){
            return NotFound(result);
        }

        return Ok(result);
    }
}
