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
public class CountryController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var result = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var result = await _unitOfWork.Countries.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<CountryDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Post([FromBody] CountryDto CountryDto)
    {
        var result = _mapper.Map<Country>(CountryDto);
        _unitOfWork.Countries.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        CountryDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = CountryDto.Id }, CountryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto CountryDto)
    {
        if (CountryDto == null)
            return BadRequest();
        if (CountryDto.Id == 0)
            CountryDto.Id = id;
        if (CountryDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Country>(CountryDto);
        _unitOfWork.Countries.Update(result);
        await _unitOfWork.SaveAsync();
        return CountryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Countries.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Countries.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}