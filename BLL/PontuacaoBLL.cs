using MGS_DAO;
using MGS_Model;
using System;
using System.Collections.Generic;

namespace MGS_BLL
{
    public class PontuacaoBLL
    {
        PontuacaoDAO _pontDAO = new PontuacaoDAO();

        public List<Pontuacao> ListarPontuacoes(DateTime dtInicial, DateTime dtFinal)
        {
            return _pontDAO.ListarPontuacoes(dtInicial, dtFinal);
        }

        public void SalvarPontuacao(DateTime dataPontuacao, int qtdPontos)
        {
            _pontDAO.SalvarPontuacao(dataPontuacao, qtdPontos);
        }
    }
}
