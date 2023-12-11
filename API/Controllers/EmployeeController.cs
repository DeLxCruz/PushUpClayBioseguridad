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
public class EmployeeController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
    {
        var result = await _unitOfWork.Employees.GetAllAsync();
        return _mapper.Map<List<EmployeeDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDto>> Get(int id)
    {
        var result = await _unitOfWork.Employees.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<EmployeeDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmployeeDto>> Post([FromBody] EmployeeDto EmployeeDto)
    {
        var result = _mapper.Map<Employee>(EmployeeDto);
        _unitOfWork.Employees.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        EmployeeDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = EmployeeDto.Id }, EmployeeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto EmployeeDto)
    {
        if (EmployeeDto == null)
            return BadRequest();
        if (EmployeeDto.Id == 0)
            EmployeeDto.Id = id;
        if (EmployeeDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Employee>(EmployeeDto);
        _unitOfWork.Employees.Update(result);
        await _unitOfWork.SaveAsync();
        return EmployeeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Employees.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Employees.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}