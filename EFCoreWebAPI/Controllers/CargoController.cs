using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreWebAPIMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public CargoController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllCargos());
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
                return Ok(await _repo.GetCargoById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro{ex}");
            }
        }
        [HttpGet("getcargobynome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                return Ok(await _repo.GetCargoByNome(nome));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro{ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Cargo model)
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
        public async Task<ActionResult> Put(int id, Cargo model)
        {
            await _repo.GetCargoById(id);
            _repo.Update(model);
            return Ok(await _repo.SaveChangeAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cargo = await _repo.GetCargoById(id);
                if (cargo != null)
                {
                    _repo.Delete(cargo);
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
