using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSite.Data;
using MiniSite.Models;
using Newtonsoft.Json;

namespace MiniSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDataModel>>> GetUserDataModel()
        {
            if (_context.UserDataModel == null)
            {
                return NotFound();
            }
            await InsertLocalData();
            return await _context.UserDataModel.ToListAsync();
        }
        //Insert Local Data to DB
        public async Task InsertLocalData()
        {
            try
            {
                var jsonFile = "Data/data.json";
                using (StreamReader r = new StreamReader(jsonFile))
                {
                    string json = r.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<List<UserDataModel>>(json);

                    var data = await _context.UserDataModel.ToListAsync();
                    if (data.Count == 0)
                    {
                        foreach (var item in arr)
                        {
                            await PostUserDataModel(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        // GET: api/UserData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDataModel>> GetUserDataModel(int id)
        {
            if (_context.UserDataModel == null)
            {
                return NotFound();
            }
            var userDataModel = await _context.UserDataModel.FindAsync(id);

            if (userDataModel == null)
            {
                return NotFound();
            }
     
            return userDataModel;
        }

        // PUT: api/UserData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDataModel(int id, UserDataModel userDataModel)
        {
            if (id != userDataModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDataModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDataModel>> PostUserDataModel(UserDataModel userDataModel)
        {
          if (_context.UserDataModel == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserDataModel'  is null.");
          }
            _context.UserDataModel.Add(userDataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDataModel", new { id = userDataModel.Id }, userDataModel);
        }

        // DELETE: api/UserData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDataModel(int id)
        {
            if (_context.UserDataModel == null)
            {
                return NotFound();
            }
            var userDataModel = await _context.UserDataModel.FindAsync(id);
            if (userDataModel == null)
            {
                return NotFound();
            }

            _context.UserDataModel.Remove(userDataModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDataModelExists(int id)
        {
            return (_context.UserDataModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
