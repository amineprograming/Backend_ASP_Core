using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Repositories;
using Backend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceptionsController : Controller
    {
        private readonly IReceptionRepository _repository;

        public ReceptionsController(IReceptionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Reception reception)
        {
            _repository.Add(reception);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public IActionResult FindbyId(int id)
        {
            Reception reception = _repository.GetById(id);
            if (reception == null)
            {
                return NotFound();
            }
            return Ok(reception);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Reception reception = _repository.GetById(id);
            if (reception == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Delete(reception);
                return Ok();

            }
            catch (Exception e)
            {
                //TODO : exception handling and logging
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}

