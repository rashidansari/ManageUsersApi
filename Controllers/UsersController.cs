using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ManageUsersApi.Models;
using ManageUsersApi.Data;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using ManageUsersApi.Dtos;
using ManageUsersApi.Util;
using System.Threading.Tasks;

namespace ManageUsersApi.Controller
{
 [Route("api/users")]
 [ApiController]
 public class UserController : ControllerBase
{
    private readonly IUserRepo _repository;
    private readonly IMapper _mapper;

    public UserController( IUserRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name="GetUserById")]
    public async Task<ActionResult <UserReadDto>> GetUserById(int id)
    {
        var item = await _repository.GetUserByIdAsync(id);
        if(item != null)
            {
                return Ok(new ApiOkResponse(_mapper.Map<UserReadDto>(item)));
            }
        return NotFound(new ApiResponse(404,"User not found."));       
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
    {
        var items = await _repository.GetUsersAsync();
        if(items != null)
            {
                return Ok(new ApiOkResponse(_mapper.Map<IEnumerable<UserReadDto>>(items)));
            }
        return NotFound(new ApiResponse(404,"Users not found."));  
    }
        
    [HttpPost] 
    public async Task<ActionResult <UserReadDto>> Create(UserCreateDto userCreateDto)
    {
        if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }
            
        var model = _mapper.Map<User>(userCreateDto);
        try{
            var user = await _repository.GetUserByEmailAsync(model.EmailAdress);
                if(user != null)
                {
                    return BadRequest(new ApiResponse(400, $"A user with same emailAdress [{user.EmailAdress}] already registered.")); 
                }
                _repository.CreateAsync<User>(model);
                if ( await _repository.SaveChangesAsync())
                {
                    var userReadDto = _mapper.Map<UserReadDto>(model);
                    return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);   
                }
                 return BadRequest(new ApiResponse(400, "Failed to save User.")); 
                   
            }
        catch(Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }
    }

    }
}   

   
