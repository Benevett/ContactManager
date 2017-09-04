using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contacts;
using ContactRepository.DomainModel;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace test.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        readonly IContactRepository _contactRepository;
        readonly ILogger _logger;

         /// <summary>
         /// This uses the default .netcore2 dependency injection which is wired up in ConfigureServices
         /// </summary>
         /// <param name="contactRepository"></param>
         /// <param name="logger"></param>
        public ContactsController(IContactRepository contactRepository,ILogger<ContactsController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;

        }

       
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {

            return _contactRepository.List();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact item)
        {
            _logger.LogInformation(LoggingEvents.InsertItem, "Creating Item", item.Email);
            if (item == null)
            {
                return BadRequest();
            }

            _contactRepository.Create(item);
            return CreatedAtAction("Create", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contact item)
        {
            _logger.LogInformation(LoggingEvents.UpdateItem, "Updating item {ID}", id);
            if (item == null  )
            {
                _logger.LogWarning(LoggingEvents.UpdateItemNotFound, "Update({ID}) NOT FOUND", id);

                return BadRequest();
            }

            var contact = _contactRepository.Update(item);
                   
            return new NoContentResult();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public Contact Contact(int Id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", Id);

            var item = _contactRepository.Get(Id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetContact({ID}) NOT FOUND", Id);
            }
            return item;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToDelete = _contactRepository.Get(id);
            _contactRepository.Delete(itemToDelete);

            return new NoContentResult();
        }


        [HttpPost]
        [Route("/api/contacts/upload")]
        public async Task Upload(IFormFile file)
        {
            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    var contactToUpdate =_contactRepository.Get(int.Parse(file.FileName));// id hidden in filename
                    contactToUpdate.Photo = fileContent;
                    //todo make repo async friendly
                    _contactRepository.Update(contactToUpdate);
                }
            }
        }
    }


    // from microsoft sample. would be in another file usually
    internal class LoggingEvents
    {
         
            public const int GenerateItems = 1000;
            public const int ListItems = 1001;
            public const int GetItem = 1002;
            public const int InsertItem = 1003;
            public const int UpdateItem = 1004;
            public const int DeleteItem = 1005;

            public const int GetItemNotFound = 4000;
            public const int UpdateItemNotFound = 4001;
       
    }
}


      
    
