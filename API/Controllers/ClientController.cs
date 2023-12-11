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
public class ClientController(IUnitOfWork unitOfWork, IMapper mapper, BioSecurityContext context) : BaseController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly BioSecurityContext _context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var result = await _unitOfWork.Clients.GetAllAsync();
        return _mapper.Map<List<ClientDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> Get(int id)
    {
        var result = await _unitOfWork.Clients.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<ClientDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto ClientDto)
    {
        var result = _mapper.Map<Client>(ClientDto);
        _unitOfWork.Clients.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        ClientDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = ClientDto.Id }, ClientDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto ClientDto)
    {
        if (ClientDto == null)
            return BadRequest();
        if (ClientDto.Id == 0)
            ClientDto.Id = id;
        if (ClientDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Client>(ClientDto);
        _unitOfWork.Clients.Update(result);
        await _unitOfWork.SaveAsync();
        return ClientDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Clients.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Clients.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}