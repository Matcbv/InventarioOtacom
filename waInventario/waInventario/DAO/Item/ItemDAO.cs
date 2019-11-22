using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using waInventario.Models.Item.Input;
using waInventario.Models.Item.Query;

namespace waInventario.DAO.Item
{
    public class ItemDAO{

        public IEnumerable<RetornarPorId> RetornarTodos()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    IEnumerable<RetornarPorId> result = conexao.Query<RetornarPorId>("select * from Item");
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível buscar todos os itens!", e);
                }
            }
        }

        public IEnumerable<RetornarPorId> RetornarPorNome(string busca)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    IEnumerable<RetornarPorId> result = conexao.Query<RetornarPorId>(
                        "select Item.* from Item " +
                        "where Item.Nome like '%" + busca + "%' " +
                        "order by Item.Nome");
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível buscar os itens pelo nome!", e);
                }
            }
        }

        public RetornarPorId RetornarPorId(int id)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    RetornarPorId result = conexao.QueryFirst<RetornarPorId>("select Item.* from Item where ID=@id", new { id = id });
                    conexao.Close();
                    return result;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public void Inserir(ItemAdicionarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("insert into Item (FKLocal, Nome, Autor ,Edicao, ISBN, PathImagem) values (@fklocal, @nome, @autor, @edicao, @isbn, @pathimagem)", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível inserir o item!", e);
                }
            }
        }

        public void Alterar(ItemAtualizarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("update Item set FKLocal=@fklocal, Nome=@nome, Autor=@autor, Edicao=@edicao, ISBN=@isbn, PathImagem=@pathimagem where ID=@id", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível alterar o item!", e);
                }
            }
        }

        public void Deletar(ItemDeletarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("delete from Item where ID=@id", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível apagar o item!", e);
                }
            }
        }

        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDInventarioOtacom;Data Source=ANDRÔMEDA\SQL2014; User Id=sa; Password=adm123***;";
    }
}
