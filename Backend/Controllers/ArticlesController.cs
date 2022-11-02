using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            _repository.Add(article);
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
            Article article = _repository.GetById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Article article = _repository.GetById(id);
            if (article == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Delete(article);
                return Ok();

            }catch(Exception e)
            {
                //TODO : exception handling and logging
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

