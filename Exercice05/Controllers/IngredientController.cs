using AutoMapper;
using Exercice05.DTOs;
using Exercice05.Models;
using Exercice05.Repositories;
using Exercice05.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercice05.Controllers
{

    [Route("ingredients")]
    [ApiController]
    [Authorize]
    public class IngredientController : ControllerBase
    {
        private readonly IRepository<Ingredient> _repository;
        private readonly IMapper _mapper;

        public IngredientController(IRepository<Ingredient> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok(_repository.GetAll());
            IEnumerable<Ingredient> ingredients = await _repository.GetAll();

            IEnumerable<IngredientDTO> ingredientDTOs = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients)!;
            //IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts)!;

            // possible d'ajouter des modification par rapport aux DTOs ici

            return Ok(ingredientDTOs);
        }

        //GET /contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _repository.Get(id);

            if (ingredient == null)
                return NotFound(new
                {
                    Message = "There is no Ingredient with this Id."
                });

            IngredientDTO ingredientDTO = _mapper.Map<IngredientDTO>(ingredient)!;

            return Ok(new
            {
                Message = "Ingredient found.",
                Contact = ingredientDTO
            });
        }

        //POST /contacts
        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Post([FromBody] IngredientDTO ingredientDTO)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDTO)!;

            var ingredientAdded = await _repository.Add(ingredient);

            var ingredientAddedDTO = _mapper.Map<IngredientDTO>(ingredientAdded)!;

            if (ingredientAdded != null)
                return CreatedAtAction(nameof(GetById),
                                       new { id = ingredientAddedDTO.Id },
                                       new
                                       {
                                           Message = "Ingredient Added.",
                                           Contact = ingredientAddedDTO
                                       });

            return BadRequest("Something went wrong...");
        }

        //PUT /contacts/4
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] IngredientDTO ingredientDTO)
        {
            var ingredientFromDb = await _repository.Get(id);

            if (ingredientFromDb == null)
                return NotFound("There is no Ingredient with this Id.");

            ingredientDTO.Id = id; // nécessaire dans le cas où l'id n'est pas ou mal définit dan la requete

            var ingredient = _mapper.Map<Ingredient>(ingredientDTO)!;

            var ingredientUpdated = await _repository.Update(ingredient);

            var ingredientUpdatedDTO = _mapper.Map<IngredientDTO>(ingredientUpdated);

            if (ingredientUpdated != null)
                return Ok(new
                {
                    Message = "Ingredient Updated.",
                    Contact = ingredientUpdatedDTO
                });

            return BadRequest("Something went wrong...");
        }


        //DELETE /contacts/12
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.Delete(id))
                return Ok("Ingredient Deleted");

            //return NotFound("Contact Not Found");
            return BadRequest("Something went wrong...");
        }


        ////GET /contacts
        //[HttpGet("fullnames")]
        //public async Task<IActionResult> GetAllFullNames()
        //{
        //    IEnumerable<Contact> contacts = await _repository.GetAll();

        //    IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<ContactDTO>>(contacts)!;

        //    IEnumerable<ContactFullNameDTO> fullnames = _mapper.Map<IEnumerable<ContactFullNameDTO>>(contactDTOs)!;

        //    return Ok(fullnames);
        //}
    }
}
