using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioSoft.Others
{
    public class Conexao
    {
        private String stringDeConexao = @"Data Source=.\SQLEXPRESS; Initial Catalog=dbfisio; User Id=seu login; password=sua senha";
        private SqlConnection conn;

        public SqlConnection openConnection()
        {
            try
            {
                this.conn = new SqlConnection(this.stringDeConexao);
                this.conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados! Erro: " + ex.Message);
                return null;
            }
        }
        public void closeConnection()
        {
            try
            {
                this.conn.Close();
                this.conn.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados! Erro: " + ex.Message);
            }
        }
    }
}
