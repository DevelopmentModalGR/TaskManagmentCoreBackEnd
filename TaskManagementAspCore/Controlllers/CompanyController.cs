using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManagementAspCore.Controlllers
{
    [Route("companies")]
    public class CompanyController : Controller
    {
        /*
        //GETTERS
        */
        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Company>>> GetAction(
           [FromServices] DataContext context)
        {
            var companies = await context
            .Companies
            .Include(x => x.Users)
            .AsNoTracking()
            .ToListAsync();
            return companies;
        }

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Company>>> GetAction(
           [FromServices] DataContext context, int id)
        {
            var companies = await context
            .Companies
            .Include(x => x.Users)
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
            return companies;
        }

        /*
        //POSTERS
        */
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Company>> Post(
            [FromServices] DataContext context,
            [FromBody] Company model)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Força o usuário a ser sempre "funcionário"
                //model.Role = "employee";

                context.Companies.Add(model);
                await context.SaveChangesAsync();

                //Esconde a senha
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }

        /*
        //PUTTERS
        */
        [HttpPut]
        [Route("id:int")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Company>> Put(
                    [FromServices] DataContext context,
                    [FromBody] Company model, int id)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }

        /*
        //DELETTERS
        */
        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Company>>> Delete(
        int id,
        [FromServices] DataContext _context)
        {
            var companies = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (companies == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            try
            {
                _context.Companies.Remove(companies);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Usuário {companies.Id} removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover a categoria" });
            }

        }
    }
}
