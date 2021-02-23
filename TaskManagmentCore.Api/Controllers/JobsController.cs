using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementCore.Api;
using TaskManagementCore.Models;

namespace TaskManagementAspCore.Controlllers
{
    [Route("jobs")]
    public class JobsController : Controller
    {
        #region GETTERS


        //RETORNA TODAS COMPANHIAS

        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Jobs>>> GetCompany(
           [FromServices] DataContext context)
        {
            var jobs = await context
            .Jobs
            .AsNoTracking()
            .ToListAsync();
            return jobs;
        }


        //RETORNA TODAS COMPANHIAS POR ID

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Jobs>>> GetCompanybyId(
           [FromServices] DataContext context, int id)
        {
            var jobs = await context
            .Jobs
            .Include(x => x.Users)
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
            return jobs;
        }


        //RETORNA TODAS COMPANHIAS POR NOME

        [HttpGet]
        [Route("{name}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Jobs>>> GetAction(
           [FromServices] DataContext context, string name)
        {
            var jobs = await context
            .Jobs
            .Include(x => x.Users)
            .AsNoTracking()
            .Where(x => x.Name == name)
            .ToListAsync();
            return jobs;
        }
        #endregion

        #region POSTERS

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Jobs>> Post(
            [FromServices] DataContext context,
            [FromBody] Jobs model)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Força o usuário a ser sempre "funcionário"
                //model.Role = "employee";

                context.Jobs.Add(model);
                await context.SaveChangesAsync();

                //Esconde a senha
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }

        #endregion

        #region PUTTERS

        [HttpPut]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Jobs>> Put(
                    [FromServices] DataContext context,
                    [FromBody] Jobs model, int id)
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
        #endregion

        #region DELETTERS

        //DELETTERS

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Jobs>>> Delete(
        int id,
        [FromServices] DataContext _context)
        {
            var jobs = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (jobs == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            try
            {
                _context.Jobs.Remove(jobs);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Usuário {jobs.Id} removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover a categoria" });
            }

        }
        #endregion
    }
}

