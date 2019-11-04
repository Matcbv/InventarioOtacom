using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using waInventario.Models.Local.Input;
using waInventario.Models.Local.Query;

namespace waInventario.DAO.Local
{
    public class LocalDAO
    {
        public IEnumerable<LocalViewModel> RetornarTodos(){
            
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    IEnumerable<LocalViewModel> result = conexao.Query<LocalViewModel>("select * from Local");
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível buscar todos os itens!", e);
                }
            }
        }

        public IEnumerable<LocalViewModel> RetornarPorDescricao(string busca)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    IEnumerable<LocalViewModel> result = conexao.Query<LocalViewModel>(
                    "select Local.* from Local " +
                    "where Item.Local like '%" + busca + "%' " +
                    "order by Item.Local");
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível buscar todos os itens!", e);
                }
            }
        }

        public LocalViewModel RetornarPeloId(int id)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    LocalViewModel result = conexao.QueryFirst<LocalViewModel>("select Local.* from Local where ID=@id");
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível buscar todos os itens!", e);
                }
            }
        }

        public void Inserir(LocalAdicionarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("insert into Local (Descricao) values (@descricao)", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível inserir o local!", e);
                }
            }
        }

        public void Alterar(LocalAtualizarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("update Local set Descricao=@descricao where ID=@id", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível inserir o local!", e);
                }
            }
        }

        public void Deletar(LocalDeletarViewModel objeto)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                try
                {
                    conexao.Execute("delete from Local where ID=@id", objeto);
                    conexao.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Não foi possível inserir o local!", e);
                }
            }
        }

        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDInventarioOtacom;Data Source=ANDRÔMEDA\SQL2014; User Id=sa; Password=adm123***;";

    }
}
