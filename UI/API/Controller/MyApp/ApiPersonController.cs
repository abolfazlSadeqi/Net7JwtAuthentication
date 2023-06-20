
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;
using Contract.Repository;
using Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controller.MyApp;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "MYApp,Admin")]
public class ApiPersonController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public ApiPersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        _mapper = mapper;

    }





    [HttpGet]
    [Route("GetAllPersons")]
    public IActionResult GetAllPersons() => Ok(unitOfWork.Person.GetAll());

    [HttpGet]
    [Route("GetByIdPersons")]
    public IActionResult GetByIdPersons(int Id) => Ok(unitOfWork.Person.GetById(Id));




    [HttpPost]
    [Route("InsertToPersons")]
    public IActionResult InsertToPersons(PersonDto person)
    {

        var newperson = _mapper.Map<Person>(person);
        unitOfWork.Person.Add(newperson);

        unitOfWork.Save();
        return Ok(newperson);
    }


    [HttpPost]
    [Route("UpdatePerson")]

    public IActionResult UpdatePerson(PersonDto person)
    {

        var Personold = unitOfWork.Person.GetById(person.ID);
        Personold.LastName = person.LastName;
        Personold.FirstName = person.FirstName;
        Personold.Suffix = person.Suffix;
        Personold.Email = person.Email;
        Personold.AdditionalContactInfo = person.AdditionalContactInfo;
        Personold.CreateDate = person.CreateDate;
        Personold.ModifiedDate = person.ModifiedDate;


        unitOfWork.Save();
        return Ok(person);
    }
    [HttpPost]
    [Route("RemovePersons")]
    public IActionResult RemovePersons(int Id)
    {
        try
        {
            unitOfWork.Person.Remove(unitOfWork.Person.GetById(Id));
            unitOfWork.Save();
        }
        catch (Exception ex)
        {
            return Ok("faild" + ex.Message);
        }

        return Ok("Success");
    }

    //    HttpPut]
    //public async Task<IActionResult> PutAsync(Students studentToUpdate)
    //    {
    //        _myWorldDbContext.Students.Update(studentToUpdate);
    //        await _myWorldDbContext.SaveChangesAsync();
    //        return NoContent();
    //    }

}
