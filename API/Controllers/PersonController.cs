using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class PersonController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var result = await _unitOfWork.Persons.GetAllAsync();
        return _mapper.Map<List<PersonDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var result = await _unitOfWork.Persons.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<PersonDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Post([FromBody] PersonDto PersonDto)
    {
        var result = _mapper.Map<Person>(PersonDto);
        _unitOfWork.Persons.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        PersonDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = PersonDto.Id }, PersonDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto PersonDto)
    {
        if (PersonDto == null)
            return BadRequest();
        if (PersonDto.Id == 0)
            PersonDto.Id = id;
        if (PersonDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Person>(PersonDto);
        _unitOfWork.Persons.Update(result);
        await _unitOfWork.SaveAsync();
        return PersonDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Persons.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Persons.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}