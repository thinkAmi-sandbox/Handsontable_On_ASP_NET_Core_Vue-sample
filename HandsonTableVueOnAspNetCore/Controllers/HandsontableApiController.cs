using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using Bogus;
using HandsonTableVueOnAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandsonTableVueOnAspNetCore.Controllers
{
    [Route("api/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class HandsontableApiController : ControllerBase
    {
        private readonly HandsontableContext _context;

        public HandsontableApiController(HandsontableContext context)
        {
            this._context = context;
        }
        
        [HttpGet("const")]
        public IActionResult GetConstResponse()
        {
            var apples = new List<dynamic>
            {
                new List<dynamic> {1, "秋映", 100},
                new List<dynamic> {2, "シナノゴールド", 200},
                new List<dynamic> {3, "ピンクレディ", 300}
            };
            return Ok(JsonSerializer.Serialize(apples));
        }
        
        [HttpGet("model")]
        public IActionResult GetApplesResponse()
        {
            var response = _context.Customers.Select(c => new ArrayList
            {
                c.Id, c.Name, c.Age
            });
            
            return Ok(JsonSerializer.Serialize(response));
        }
        
        [HttpGet("seed")]
        public IActionResult Seed()
        {
            var faker = new Faker<Customer>("ja")
                .RuleFor(r => r.Name, f => $"{f.Name.LastName()} {f.Name.FirstName()}")
                .RuleFor(r => r.Age, f => f.Random.Number(20, 60));

            var fakes = faker.Generate(3);
            
            _context.Customers.AddRange(fakes.ToArray());
            _context.SaveChanges();

            var customers = fakes.Select(a => new ArrayList
            { 
                a.Id, a.Name, a.Age
            });

            return Ok(JsonSerializer.Serialize(customers));
        }
    }
}