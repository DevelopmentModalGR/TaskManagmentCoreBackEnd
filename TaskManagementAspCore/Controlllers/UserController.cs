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
using Microsoft.AspNetCore.Cors;

namespace TaskManagementAspCore.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        #region GETTERS
        private readonly DataContext context;

        public UserController(DataContext context)
        {
            this.context = context;
        }

        //RETORNA TODOS USUARIOS

        [HttpGet("")]
        [AllowAnonymous]
        //[Authorize(Roles = "employee")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .AsNoTracking()
            .ToListAsync();
            return Ok(users);
        }

        //RETORNA TODOS USUARIOS, INCLUINDO NOME DE COMPANIAS, DEPARTAMENTOS E JOBS
        [HttpGet("allinfo")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<User>>> GetUsersAllInfo()
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .Include(x => x.Departments)
            .Include(x => x.Jobs)
            .AsNoTracking()
            .ToListAsync();
            return Ok(users);
        }


        //RETORNA O USUARIO PELO ID PASSADO COMO PARAMETRO COM TODAS AS INFORMAÇÕES VINCULADAS
        [HttpGet("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<User>>> GetUserById(int id)
        {
            var users = await context
            .Users
            .Include(x => x.Company)
            .Include(x => x.Departments)
            .Include(x => x.Jobs)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .ToListAsync();
            return Ok(users);
        }

        //RETORNA O USUARIO PELO EMAIL INFORMADO
        [HttpGet("{email}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> GetAction(string email)
        {
            var user = await context
            .Users
            .Include(x => x.Company)
            .AsNoTracking()
            .Where(x => x.Email == email)
            .ToListAsync();
            return Ok(user);
        }

        #endregion

        #region VERIFICAR AUTENTICIDADE

        [HttpGet("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anonimo";

        [HttpGet("autenticado")]
        [Authorize]
        public string Autenticado() => "Autenticado";

        [HttpGet("funcionario")]
        [Authorize(Roles = "employee")]
        public string Funcionario() => "Funcionario";

        [HttpGet("gerente")]
        [Authorize(Roles = "manager")]
        public string Gerente() => "Gerente";

        #endregion

        #region POSTERS


        //INSERE UM USUARIO

        [HttpPost("newuser")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> PostUser(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.Company == null)
                return BadRequest(new { message = "Insira uma Companhia" });

            try
            {
                //Força o usuário a ser sempre "funcionário"
                //model.Role = "employee";

                context.Users.Add(model);
                model.Departments = null;
                model.Jobs = null;
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


        //LOGAR USUARIO E RETORNAR TOKEN DE AUTENTICIDADE

        [HttpPost("login")]
        [EnableCors("EnableCORS")]
        //[Authorize(Roles = "manager")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
        [FromBody] User model)
        {
            var user = await context.Users
            .AsNoTracking()
            .Where(x => x.Email == model.Email && x.Password == model.Password)
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
        #endregion

        #region PUTTERS

        //PUTTERS

        [HttpPut("{id:int}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> AlterUser(
                    [FromServices] DataContext context,
                    [FromBody] User model, int id)
        {
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return model;
        }

        #endregion

        #region DELETTERS


        //DELETTERS
        [HttpDelete("{id:int}")]
        // [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Delete(
            int id,
           [FromServices] DataContext context)
        {
            var users = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (users == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            try
            {
                context.Users.Remove(users);
                await context.SaveChangesAsync();
                return Ok(new { message = $"Usuário {users.Id} removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover a categoria" });
            }
        }
        #endregion
    }
}
