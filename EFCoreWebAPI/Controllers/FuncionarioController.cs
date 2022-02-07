using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebAPIMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public FuncionarioController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllFuncionarios()); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repo.GetFuncionarioById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro{ex}");
            }      
        }
        [HttpGet("getfuncionariobynome/{nome}")]
        public async Task<IActionResult> GetFuncionarioByNome(string nome)
        {
            try
            {
                return Ok(await _repo.GetFuncionarioByNome(nome));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro{ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
        {
            try
            {             
                _repo.Add(model);
                return Ok(await _repo.SaveChangeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Funcionario model)
        {          
            await _repo.GetFuncionarioById(id);            
            _repo.Update(model);
            return Ok(await _repo.SaveChangeAsync());                      
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioById(id);
                if (funcionario != null)
                {
                    _repo.Delete(funcionario);
                    return Ok(await _repo.SaveChangeAsync());
                }
                else
                    return BadRequest("Não encontrado.");

 
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
