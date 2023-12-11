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
public class StateController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StateDto>>> Get()
    {
        var result = await _unitOfWork.States.GetAllAsync();
        return _mapper.Map<List<StateDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StateDto>> Get(int id)
    {
        var result = await _unitOfWork.States.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<StateDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StateDto>> Post([FromBody] StateDto StateDto)
    {
        var result = _mapper.Map<State>(StateDto);
        _unitOfWork.States.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        StateDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = StateDto.Id }, StateDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StateDto>> Put(int id, [FromBody] StateDto StateDto)
    {
        if (StateDto == null)
            return BadRequest();
        if (StateDto.Id == 0)
            StateDto.Id = id;
        if (StateDto.Id != id)
            return NotFound();
        var result = _mapper.Map<State>(StateDto);
        _unitOfWork.States.Update(result);
        await _unitOfWork.SaveAsync();
        return StateDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.States.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.States.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}