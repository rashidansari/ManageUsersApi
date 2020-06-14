using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ManageUsersApi.Models;
using ManageUsersApi.Data;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using ManageUsersApi.Util;
using ManageUsersApi.Dtos;
using System.Threading.Tasks;

namespace ManageUsersApi.Controller
{
    [Route("api/users/{userid}/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepo _repository;    
        private readonly IMapper _mapper;

        public AccountController( IUserRepo repository, IMapper mapper)
        {
            _repository = repository;       
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult<AccountReadDto>> Post(int userid, AccountCreateDto accountCreateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }
            var item = await _repository.GetUserByIdAsync(userid);
            if(item == null)
            {
                return NotFound(new ApiResponse(404,"User not found."));   
            } 

            var itemAcc = await _repository.GetAccountByIdAsync(userid);
            if(itemAcc != null)
            {
                return BadRequest(new ApiResponse(400,"Account already created."));   
            } 

            if(ValidateUser(item))
            {
                return BadRequest(new ApiResponse(400,$"Account could not be create as saving is less then ${Constant.CREDITLIMIT}"));   
            } 
            var model = _mapper.Map<Account>(accountCreateDto);  
            _repository.CreateAsync<Account>(model);
            if(await _repository.SaveChangesAsync())
            {
                var accountReadDto = _mapper.Map<AccountReadDto>(model);
                return Ok(new ApiResponse(201,"Account created sucessfully."));  
            }
            return BadRequest(new ApiResponse(400, "Failed to save Account.")); 
        }
        private bool ValidateUser(User item)
        {
            return  item.MonthlySalary - item.MonthlyExpenes < Constant.CREDITLIMIT ? true : false;
        }
    }
}   

   
