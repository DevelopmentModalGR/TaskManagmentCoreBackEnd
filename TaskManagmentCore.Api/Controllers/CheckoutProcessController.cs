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
    [Route("Checkout")]
    public class CheckoutProcessController : Controller
    {
        #region GETTERS


        //RETORNA TODAS COMPANHIAS

        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<CheckoutProcess>>> GetCompany(
           [FromServices] DataContext context)
        {
            var jobs = await context
            .CheckOutProcesses
            .AsNoTracking()
            .ToListAsync();
            return jobs;
        }


        //RETORNA TODAS COMPANHIAS POR ID

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<CheckoutProcess>>> GetCompanybyId(
           [FromServices] DataContext context, int id)
        {
            var jobs = await context
            .CheckOutProcesses
            .Include(x => x.Jobs)
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
            return jobs;
        }


        //RETORNA TODAS COMPANHIAS POR NOME

        [HttpGet]
        [Route("{name}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<CheckoutProcess>>> GetAction(
           [FromServices] DataContext context, string name)
        {
            var checkout = await context
            .CheckOutProcesses
            .Include(x => x.Jobs)
            .AsNoTracking()
            .Where(x => x.Name == name)
            .ToListAsync();
            return checkout;
        }
        #endregion

        #region POSTERS

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<CheckoutProcess>> Post(
            [FromServices] DataContext context,
            [FromBody] CheckoutProcess model)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Força o usuário a ser sempre "funcionário"
                //model.Role = "employee";

                context.CheckOutProcesses.Add(model);
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
        public async Task<ActionResult<CheckoutProcess>> Put(
                    [FromServices] DataContext context,
                    [FromBody] CheckoutProcess model, int id)
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
        public async Task<ActionResult<List<CheckoutProcess>>> Delete(
        int id,
        [FromServices] DataContext _context)
        {
            var checkout = await _context.CheckOutProcesses.FirstOrDefaultAsync(x => x.Id == id);
            if (checkout == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            try
            {
                _context.CheckOutProcesses.Remove(checkout);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Usuário {checkout.Id} removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover a categoria" });
            }

        }
        #endregion
    }
}
