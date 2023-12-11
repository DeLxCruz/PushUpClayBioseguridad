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
public class PersonAddressController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonAddressDto>>> Get()
    {
        var result = await _unitOfWork.PersonAddresses.GetAllAsync();
        return _mapper.Map<List<PersonAddressDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonAddressDto>> Get(int id)
    {
        var result = await _unitOfWork.PersonAddresses.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<PersonAddressDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonAddressDto>> Post([FromBody] PersonAddressDto PersonAddressDto)
    {
        var result = _mapper.Map<Personaddress>(PersonAddressDto);
        _unitOfWork.PersonAddresses.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        PersonAddressDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = PersonAddressDto.Id }, PersonAddressDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonAddressDto>> Put(int id, [FromBody] PersonAddressDto PersonAddressDto)
    {
        if (PersonAddressDto == null)
            return BadRequest();
        if (PersonAddressDto.Id == 0)
            PersonAddressDto.Id = id;
        if (PersonAddressDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Personaddress>(PersonAddressDto);
        _unitOfWork.PersonAddresses.Update(result);
        await _unitOfWork.SaveAsync();
        return PersonAddressDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.PersonAddresses.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.PersonAddresses.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}