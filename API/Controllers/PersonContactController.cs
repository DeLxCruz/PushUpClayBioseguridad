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
public class PersonContactController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonContactDto>>> Get()
    {
        var result = await _unitOfWork.PersonContacts.GetAllAsync();
        return _mapper.Map<List<PersonContactDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonContactDto>> Get(int id)
    {
        var result = await _unitOfWork.PersonContacts.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<PersonContactDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonContactDto>> Post([FromBody] PersonContactDto PersonContactDto)
    {
        var result = _mapper.Map<Personcontact>(PersonContactDto);
        _unitOfWork.PersonContacts.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        PersonContactDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = PersonContactDto.Id }, PersonContactDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonContactDto>> Put(int id, [FromBody] PersonContactDto PersonContactDto)
    {
        if (PersonContactDto == null)
            return BadRequest();
        if (PersonContactDto.Id == 0)
            PersonContactDto.Id = id;
        if (PersonContactDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Personcontact>(PersonContactDto);
        _unitOfWork.PersonContacts.Update(result);
        await _unitOfWork.SaveAsync();
        return PersonContactDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.PersonContacts.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.PersonContacts.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}