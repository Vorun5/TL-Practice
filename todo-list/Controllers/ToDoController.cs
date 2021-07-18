using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using todo_list.DbInfrastructure;
using todo_list.DTO;
using todo_list.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoRepository _repository;
        private IUnitOfWork _unitOfWork;

        public ToDoController(IToDoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public IEnumerable<ToDoDto> Get()
        {
            return _repository.GetAll()
                .Select(x => new ToDoDto { Id = x.Id, Name = x.Name, Done = x.Done })
                .ToArray();
        }

        // POST api/<ToDoController>
        [HttpPost]
        public int Post([FromBody] ToDoDto dto)
        {
            ToDoEntity newEntity = new ToDoEntity
            {
                Name = dto.Name,
                Done = dto.Done
            };
            _repository.Add(newEntity);
            _unitOfWork.Commit();

            return newEntity.Id;
        }
        /*public int Add(ToDoDto toDoDto)
        {
            ToDoEntity newEntity = new ToDoEntity
            {
                Name = toDoDto.Name,
                Done = toDoDto.Done
            };
            _repository.Add(newEntity);
            _unitOfWork.Commit();

            return newEntity.Id;
        }*/

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoDto dto)
        {
            ToDoEntity entity = _repository.GetById(id);
            entity.Name = dto.Name;
            entity.Done = dto.Done;
            _unitOfWork.Commit();
        }
    }
}