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
public class AddressTypeController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AddressTypeDto>>> Get()
    {
        var result = await _unitOfWork.AddressTypes.GetAllAsync();
        return _mapper.Map<List<AddressTypeDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressTypeDto>> Get(int id)
    {
        var result = await _unitOfWork.AddressTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<AddressTypeDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressTypeDto>> Post([FromBody] AddressTypeDto AddressTypeDto)
    {
        var result = _mapper.Map<Addresstype>(AddressTypeDto);
        _unitOfWork.AddressTypes.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        AddressTypeDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = AddressTypeDto.Id }, AddressTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressTypeDto>> Put(int id, [FromBody] AddressTypeDto AddressTypeDto)
    {
        if (AddressTypeDto == null)
            return BadRequest();
        if (AddressTypeDto.Id == 0)
            AddressTypeDto.Id = id;
        if (AddressTypeDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Addresstype>(AddressTypeDto);
        _unitOfWork.AddressTypes.Update(result);
        await _unitOfWork.SaveAsync();
        return AddressTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.AddressTypes.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.AddressTypes.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}