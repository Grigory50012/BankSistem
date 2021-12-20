using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankSistem.Controllers
{
    [Route("api/towns")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TownsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTowns()
        {
            var towns = _repository.Town.GetTowns(trackChenges: false);
            var townsDto = _mapper.Map<IEnumerable<TownDto>>(towns);
            return Ok(townsDto);
        }
    }
}
