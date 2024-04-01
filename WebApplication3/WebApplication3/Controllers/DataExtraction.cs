using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure;
using System.Security.Policy;
using WebApplication3.DAL;

namespace WebApplication3.Controllers { 
    [Route("api/[controller]")]
    [ApiController]
    public class DataExtraction
    {
        [HttpGet]
        [Route("getAllUsers")]
        public List<user> getUsers()
        {
            Dal dal = new Dal();
            List<user> users = dal.getUsers();
            return users;
        }
    }
}
