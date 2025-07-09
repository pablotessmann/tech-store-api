﻿using tech_store_api.Domain.Entities;
using tech_store_api.Domain.Interfaces;

namespace tech_store_api.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            return _repo.ListarTodos();
        }

        public Produto? ObterProdutoPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Produto CriarProduto(Produto produto)
        {
            _repo.Add(produto);
            return produto;
        }

        public Produto AtualizarProduto(Produto produto)
        {
            _repo.Atualizar(produto);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return produto;
        }

        public void RemoverProduto(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }

    }
}
