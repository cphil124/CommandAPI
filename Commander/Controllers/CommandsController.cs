using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // Controller: Class containing commands which can be received by API End Users. Controller Classes are called via routes specified with class decorators. 
    //             Decorators on methods indicate the REST API command used to call the method, as well as any additional parameters taken in. These methods indicate
    //             the logic to be executed when the decorator-specified command and parameters are sent to the route, and the data returned to the caller.
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            // return Ok(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        // Should be able to use a NameOf parameter instead of Name=. TODO: Research Later
        [HttpGet("{id}", Name = "GetCommandByID")]
        public ActionResult<CommandReadDto> GetCommandByID(int id)
        {
            var commandItem = _repository.GetCommandByID(id);
            if (commandItem != null)
            {
                // return Ok(commandItem); //Old implementation, direct model return
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateaDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateaDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //CreatedAtRoute = 201 Created Return Code
            //nameof function gets the Name string from the route decorator, which is what the CreatedRoute function needs
            // routeValues = anonymous object containing parameter values
            // value =  The content value to format in the entity body. Is the object returned in the result payload. The Dto indicates the properties/columns/values 
            //          which actually get returned to the calling user. 
            // Returns an additional 'Location' Header indicating the URI of the command which returned the result body verifying the new record's creation
            return CreatedAtRoute(routeName: nameof(GetCommandByID), routeValues: new { Id = commandReadDto.Id }, value: commandReadDto);
            // return Ok(commandReadDto);

        }

        //PUT api/command/{id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            // Because we are updating the record, we are mapping the update data onto the result set of the record query.
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // Then we return the updated result set data back to the repository/database
            // The below line of code is not actually necessary as technically the update to the result object from the Map 
            // method will be persisted back to the database upon SaveChanges. However there are implementation scenarios where this will be useful.
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}