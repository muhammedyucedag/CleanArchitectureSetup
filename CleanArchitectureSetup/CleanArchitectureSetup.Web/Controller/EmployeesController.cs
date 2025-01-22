using CleanArchitectureSetup.Application.Employees.Command;
using CleanArchitectureSetup.Application.Employees.Queries;
using CleanArchitectureSetup.Application.Employees.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSetup.Web.Controller;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<EmployeeDto>>> GetEmployees(ISender sender, [FromQuery] GetEmployeesQuery query)
    {
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromServices] ISender sender, [AsParameters] EmployeeCreateCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }
}