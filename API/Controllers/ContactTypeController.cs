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
public class ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get()
    {
        var result = await _unitOfWork.ContactTypes.GetAllAsync();
        return _mapper.Map<List<ContactTypeDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactTypeDto>> Get(int id)
    {
        var result = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<ContactTypeDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactTypeDto>> Post([FromBody] ContactTypeDto ContactTypeDto)
    {
        var result = _mapper.Map<Contacttype>(ContactTypeDto);
        _unitOfWork.ContactTypes.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        ContactTypeDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = ContactTypeDto.Id }, ContactTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactTypeDto>> Put(int id, [FromBody] ContactTypeDto ContactTypeDto)
    {
        if (ContactTypeDto == null)
            return BadRequest();
        if (ContactTypeDto.Id == 0)
            ContactTypeDto.Id = id;
        if (ContactTypeDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Contacttype>(ContactTypeDto);
        _unitOfWork.ContactTypes.Update(result);
        await _unitOfWork.SaveAsync();
        return ContactTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.ContactTypes.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}