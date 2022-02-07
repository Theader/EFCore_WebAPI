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
    public class SetorController : ControllerBase
    {
        
        private readonly IEFCoreRepository _repo;
        public SetorController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllSetores());
            }
            catch (Exception ex)
            {
               return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repo.GetSetorById(id));
        }

        [HttpGet("getsetorbynome/{nome}")]
        public async Task<IActionResult> GetSetorByNome(string nome)
        {
            return Ok(await _repo.GetSetorByNome(nome));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Setor model)
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
        public async Task<IActionResult> Put(int id, Setor model)
        {
            if ( await _repo.GetSetorById(id) != null)
            {
                _repo.Update(model);              
                return Ok(await _repo.SaveChangeAsync());
            }
            return BadRequest("Não encontrado");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var setor = await _repo.GetSetorById(id);
                if (setor != null)
                    _repo.Delete(setor);
                if(await _repo.SaveChangeAsync())
                    return Ok("Sucesso");
                else
                    return BadRequest("Erro");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
