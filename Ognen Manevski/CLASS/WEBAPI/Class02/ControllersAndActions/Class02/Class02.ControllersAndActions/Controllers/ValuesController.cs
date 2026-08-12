using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02.ControllersAndActions.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet] //no additional route
    //https://localhost:5001/api/values
    public List<string> Get()
    {
        return new List<string> { "value1", "value2" };
    }


    [HttpGet("info")] //additional route /info
    //https://localhost:5001/api/values/info
    public string GetInfo()
    {
        return "This is a simple api controller that returns information.";
    }

    //HAS SAME HTTP METHOD AND SAME ADDRESS!!!! -> WILL CAUSE ERROR
    //[HttpGet] //no additional route
    //[HttpGet] <-- give a custom name in order to work ex.[HttpGet("string")]
    //public string GetString()
    //{
    //    return "test";
    //}


    //this wont cause issues since its a different HTTP method (Post)
    [HttpPost]
    public string Post()
    {
        return "OK";
    }

    //this will cause issues since its a same HTTP method (Post) and same address
    //
    //[HttpPost]
    //public string Post(WeatherForecast model)
    //{
    //    return "OK";
    //}

    [HttpGet("details/{id:int}")]
    //https://localhost:5001/api/values/details/5
    public string GetById(int id)
    {
        return $"value {id}";
    }



}
