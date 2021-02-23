using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using TaskManagementCore.Api;
using TaskManagementCore.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAspCore.Controllers
{
    [Route("department")]
    public class DepartmentController : Controller
    {
        #region GETTERS

        //GETTERS

        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Department>>> GetAllDepartments(
           [FromServices] DataContext context,
           [FromBody] Department model)
        {
            var department = await context
            .Departments
            .AsNoTracking()
            .ToListAsync();
            return department;
        }

        [HttpGet]
        [Route("allinfo")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Department>>> GetDepartmentsAllInfo(
          [FromServices] DataContext context,
          [FromBody] Department model)
        {
            var department = await context
            .Departments
            .Include(x => x.CheckoutProcesses)
            .Include(x => x.Users)
            .AsNoTracking()
            .ToListAsync();
            return department;
        }

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Department>>> GetUserById(
        int id, [FromServices] DataContext context,
         [FromBody] Department model)
        {
            var departments = await context
            .Departments
            .Include(x => x.CheckoutProcesses)
            .Include(x => x.Users)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .ToListAsync();
            return departments;
        }

        #endregion

        #region POSTERS

        //POSTERS

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Department>> Post(
            [FromServices] DataContext context,
            [FromBody] Department model)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Força o usuário a ser sempre "funcionário"
                //model.Role = "employee";

                context.Departments.Add(model);
                await context.SaveChangesAsync();

                //Esconde a senha
                //model.Password = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }
        #endregion

        #region PUTTERS


        //PUTTERS

        [HttpPut]
        [Route("{id:int}")]
        // [Authorize(Roles = "manager")]
        public async Task<ActionResult<Department>> Put(
                    [FromServices] DataContext context,
                    [FromBody] Department model, int id)
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
        // [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Delete(
        int id,
        [FromServices] DataContext context)
        {
            var departments = await context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (departments == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            try
            {
                context.Departments.Remove(departments);
                await context.SaveChangesAsync();
                return Ok(new { message = $"Usuário {departments.Id} removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover a categoria" });
            }

        }
        #endregion
    }
}
