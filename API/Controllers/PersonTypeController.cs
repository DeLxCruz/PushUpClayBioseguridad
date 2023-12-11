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
public class PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
    {
        var result = await _unitOfWork.PersonTypes.GetAllAsync();
        return _mapper.Map<List<PersonTypeDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonTypeDto>> Get(int id)
    {
        var result = await _unitOfWork.PersonTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<PersonTypeDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonTypeDto>> Post([FromBody] PersonTypeDto PersonTypeDto)
    {
        var result = _mapper.Map<Persontype>(PersonTypeDto);
        _unitOfWork.PersonTypes.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        PersonTypeDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = PersonTypeDto.Id }, PersonTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto PersonTypeDto)
    {
        if (PersonTypeDto == null)
            return BadRequest();
        if (PersonTypeDto.Id == 0)
            PersonTypeDto.Id = id;
        if (PersonTypeDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Persontype>(PersonTypeDto);
        _unitOfWork.PersonTypes.Update(result);
        await _unitOfWork.SaveAsync();
        return PersonTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.PersonTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.PersonTypes.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}