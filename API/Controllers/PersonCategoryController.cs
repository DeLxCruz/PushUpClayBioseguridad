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
public class PersonCategoryController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonCategoryDto>>> Get()
    {
        var result = await _unitOfWork.PersonCategories.GetAllAsync();
        return _mapper.Map<List<PersonCategoryDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonCategoryDto>> Get(int id)
    {
        var result = await _unitOfWork.PersonCategories.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<PersonCategoryDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonCategoryDto>> Post([FromBody] PersonCategoryDto PersonCategoryDto)
    {
        var result = _mapper.Map<Personcategory>(PersonCategoryDto);
        _unitOfWork.PersonCategories.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        PersonCategoryDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = PersonCategoryDto.Id }, PersonCategoryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonCategoryDto>> Put(int id, [FromBody] PersonCategoryDto PersonCategoryDto)
    {
        if (PersonCategoryDto == null)
            return BadRequest();
        if (PersonCategoryDto.Id == 0)
            PersonCategoryDto.Id = id;
        if (PersonCategoryDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Personcategory>(PersonCategoryDto);
        _unitOfWork.PersonCategories.Update(result);
        await _unitOfWork.SaveAsync();
        return PersonCategoryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.PersonCategories.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.PersonCategories.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}