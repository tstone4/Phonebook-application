using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhonebookAPI.Models;

namespace PhonebookAPI.Controllers
{
    public class PhonebookController : ControllerBase
    {
        [HttpGet]
        [Route("phonebook")]
        public ActionResult<PhonebookEntry[]> Get()
        {
            PhonebookEntry entry1 = new PhonebookEntry();
            entry1.FirstName = "Thomas";
            entry1.LastName = "Stone";
            entry1.Id = 1;
            entry1.PhoneNumber = "1111111111";

            PhonebookEntry entry2 = new PhonebookEntry();
            entry2.FirstName = "Ryan";
            entry2.LastName = "Mcnichol";
            entry2.Id = 2;
            entry2.PhoneNumber = "222222222";

            PhonebookEntry entry3 = new PhonebookEntry();
            entry3.FirstName = "Aaron";
            entry3.LastName = "Ziaja";
            entry3.Id = 3;
            entry3.PhoneNumber = "3333333333";
            
            
            
            PhonebookEntry[] array = new PhonebookEntry[3];
            array[0] = entry1;
            array[1] = entry2;
            array[2] = entry3;




            return array;
        }
    }
}