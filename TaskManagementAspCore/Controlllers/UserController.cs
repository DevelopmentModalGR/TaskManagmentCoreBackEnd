using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using TaskManagementAspCore.Services;
using TaskManagementAspCore.Models;
using TaskManagementAspCore.Data;

namespace TaskManagementAspCore.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        /*
        //GETTERS
        */
        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> GetUsers(
           [FromServices] DataContext context,
           [FromBody] User model)
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .AsNoTracking()
            .ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("Completeinfo")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> GetUsersWithCompleteInfo(
           [FromServices] DataContext context,
           [FromBody] User model)
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .Include(x => x.Departments)
            .Include(x => x.Jobs)
            .AsNoTracking()
            .ToListAsync();
            return users;
        }


        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> GetUserById(
           int id, [FromServices] DataContext context,
           [FromBody] User model)
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .Include(x => x.Departments)
            .Include(x => x.Jobs)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .ToListAsync();
            return users;
        }

            /*[HttpGet]
            [Route("anonimo")]
            [AllowAnonymous]
            public string Anonimo() => "Anonimo";

            [HttpGet]
            [Route("autenticado")]
            [Authorize]
            public string Autenticado() => "Autenticado";

            [HttpGet]
            [Route("funcionario")]
            [Authorize(Roles = "employee")]
            public string Funcionario() => "Funcionario";

            [HttpGet]
            [Route("gerente")]
            [Authorize(Roles = "manager")]
            public string Gerente() => "Gerente";*/



            /*
            //POSTERS
            */
            [HttpPost]
            [Route("")]
            [AllowAnonymous]
            //[Authorize(Roles = "manager")]
            public async Task<ActionResult<User>> Post(
                [FromServices] DataContext context,
                [FromBody] User model)
            {
                //Verifica se os dados são válidos
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    //Força o usuário a ser sempre "funcionário"
                    //model.Role = "employee";

                    context.Users.Add(model);
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

            [HttpPost]
            [Route("login")]
            //[Authorize(Roles = "manager")]
            [AllowAnonymous]
            public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model)
            {
                var user = await context.Users
                .AsNoTracking()
                .Where(x => x.Name == model.Name && x.Password == model.Password)
                .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou senha Inválidos" });
                }

                var token = TokenService.GerateToken(user);
                // Esconde a senha
                user.Password = "";
                return new { user = user, token = token };
            }


            /*
            //PUTTERS
            */
            [HttpPut]
            [Route("{id:int}")]
            // [Authorize(Roles = "manager")]
            public async Task<ActionResult<User>> Put(
                        [FromServices] DataContext context,
                        [FromBody] User model, int id)
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
            // [Authorize(Roles = "manager")]
            public async Task<ActionResult<List<User>>> Delete(
            int id,
           [FromServices] DataContext _context)
            {
                var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (users == null)
                {
                    return NotFound(new { message = "Usuario não encontrado" });
                }
                try
                {
                    _context.Users.Remove(users);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = $"Usuário {users.Id} removido com sucesso" });
                }
                catch
                {
                    return BadRequest(new { message = "Não foi possivel remover a categoria" });
                }

            }
        }
    }
