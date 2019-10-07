using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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
            using (var context = new SqlConnection("Server=localhost;Database=PhonebookTestDb;Trusted_Connection=True;"))
            {
                var sql = @"SELECT Id, FirstName, LastName, PhoneNumber FROM [Entry]";
                var results = context.Query<PhonebookEntry>(sql).ToArray();
                return results;
            }
        }

        [HttpGet]
        [Route("phonebookDetail/{id}")]
        public ActionResult<PhonebookEntry> GetUser(int id)
        {
            using(var context = new SqlConnection("Server=localhost;Database=PhonebookTestDb;Trusted_Connection=True;"))
            {
                var sql = @"SELECT Id, FirstName, LastName, PhoneNumber FROM [Entry] WHERE Id = @Id";
                var results = context.Query<PhonebookEntry>(sql, new { @Id = id }).FirstOrDefault();
                return results;
            }
        }

        [HttpPost]
        [Route("phonebook/add")]
        public ActionResult AddEntry([FromBody]PhonebookEntry phonebookEntry)
        {
            using(var context = new SqlConnection("Server=localhost;Database=PhonebookTestDb;Trusted_Connection=True;"))
            {
                var sql = @"INSERT INTO [Entry] VALUES (@LastName, @FirstName, @PhoneNumber)";
                context.Execute(sql, new { @LastName = phonebookEntry.LastName, @FirstName = phonebookEntry.FirstName, @PhoneNumber = phonebookEntry.PhoneNumber });
            }
            return Ok();
        }
    }
}