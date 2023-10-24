﻿using Application.Dtos;
using Application.UseCases.Produto.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.Gerenciamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : CustomController<ProdutoController>
    {
        private readonly IProdutoCriarUseCase _produtoCriarUseCase;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoCriarUseCase produtoCriarUseCase) : base(logger)
        {
            _produtoCriarUseCase = produtoCriarUseCase;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto produto)
        {
            return Result(await _produtoCriarUseCase.Execute(produto));
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}