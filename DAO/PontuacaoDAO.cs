using MGS_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace MGS_DAO
{
    public class PontuacaoDAO
    {
        string _currentSystemDateFormat = ConfigurationManager.AppSettings["cultureDataFormat"];

        public List<Pontuacao> ListarPontuacoes(DateTime dtInicial, DateTime dtFinal)
        {
            List<Pontuacao> lstPontuacao = new List<Pontuacao>();
            StringBuilder sql = new StringBuilder();

            try
            {
                using (SqlConnection cnn = IniciarConexao())
                using (SqlCommand cmd = new SqlCommand())
                {
                    sql.Append($"SELECT * FROM pontuacoes WHERE DataJogo BETWEEN '{dtInicial.ToString(_currentSystemDateFormat)}' AND '{dtFinal.ToString(_currentSystemDateFormat)}' ORDER BY DataJogo asc");

                    cmd.Connection = cnn;
                    cmd.CommandText = sql.ToString();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lstPontuacao.Add(
                        new Pontuacao()
                        {
                            CodPontuacao = Convert.ToInt32(dr["CodPontuacao"]),
                            DataJogo = Convert.ToDateTime(dr["DataJogo"]),
                            QuantidadePontuacao = Convert.ToInt32(dr["Pontuacao"])
                        });
                    }
                }

                return lstPontuacao;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SalvarPontuacao(DateTime DataJogo, int qtdPontos)
        {
            StringBuilder sql = new StringBuilder();

            try
            {
                using (SqlConnection cnn = IniciarConexao())
                using (SqlCommand cmd = new SqlCommand())
                {
                    sql.Append($"INSERT INTO pontuacoes (DataJogo, Pontuacao) VALUES ('{DataJogo.ToString(_currentSystemDateFormat)}',{qtdPontos})");

                    cmd.Connection = cnn;
                    cmd.CommandText = sql.ToString();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static SqlConnection IniciarConexao()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["GameScoreCNN"].ConnectionString);

                cnn.Open();

                return cnn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
