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
    public class FournisseursController : Controller
    {
        private readonly IFournisseurRepository _repository;

        public FournisseursController(IFournisseurRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Fournisseur fournisseur)
        {
            _repository.Add(fournisseur);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindbyId(int id)
        {
            Fournisseur fournisseur = _repository.GetById(id);
            if (fournisseur == null)
            {
                return NotFound();
            }
            return Ok(fournisseur);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Fournisseur fournisseur = _repository.GetById(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Delete(fournisseur);
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

