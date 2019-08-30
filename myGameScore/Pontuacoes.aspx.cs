using MGS_BLL;
using MGS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


public partial class Pontuacoes : System.Web.UI.Page
{

    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                LimparCampos();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarConsulta())
                CarregarPontuacoes();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'error',title: 'Erro',text: 'Ocorreu um erro inesperado, se o problema persistir, entre em contato com o suporte!'});", true);
        }
    }

    protected void btnSalvarPontuacao_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarInclusao())
            {
                PontuacaoBLL pontBLL = new PontuacaoBLL();

                pontBLL.SalvarPontuacao(Convert.ToDateTime(txtDataJogo.Text), Convert.ToInt32(txtPontuacao.Text));

                LimparCampos();

                ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'success',title: 'Ok',text: 'Dados do jogo salvos com sucesso!'});", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'error',title: 'Erro',text: 'Ocorreu um erro inesperado, se o problema persistir, entre em contato com o suporte!'});", true);
        }
    }

    #endregion

    #region Funções

    private void CarregarPontuacoes()
    {
        PontuacaoBLL pontBLL = new PontuacaoBLL();
        List<Pontuacao> lstPontuacoes = new List<Pontuacao>();

        try
        {
            lstPontuacoes = pontBLL.ListarPontuacoes(Convert.ToDateTime(txtDtInicial.Text), Convert.ToDateTime(txtDtFinal.Text));

            if (lstPontuacoes.Any())
            {
                pnlResultados.Visible = true;

                lblPeriodo.Text = $"{lstPontuacoes.Min(o => o.DataJogo).ToString("dd/MM/yyyy")} até {lstPontuacoes.Max(o => o.DataJogo).ToString("dd/MM/yyyy")}";

                //Carrega totalizadores
                lblJogosDisputados.Text = lstPontuacoes.Count().ToString("##,##");
                lblTotalPontos.Text = lstPontuacoes.Sum(p => p.QuantidadePontuacao).ToString("##,##");
                lblMediaPontos.Text = (lstPontuacoes.Sum(p => p.QuantidadePontuacao) / lstPontuacoes.Count()).ToString("##,##");
                lblMaiorPontuacao.Text = lstPontuacoes.Max(p => p.QuantidadePontuacao).ToString("##,##");
                lblMenorPontuacao.Text = lstPontuacoes.Min(p => p.QuantidadePontuacao).ToString("##,##");

                int lastPont = 0;
                int recordesQuebrados = 0;
                int ultimaPontuacaoRecorde = 0;

                foreach (var pont in lstPontuacoes)
                {
                    if (pont.QuantidadePontuacao > ultimaPontuacaoRecorde )
                        ultimaPontuacaoRecorde = pont.QuantidadePontuacao;

                    if (pont.QuantidadePontuacao == ultimaPontuacaoRecorde && lstPontuacoes.IndexOf(pont) != 0)
                    {
                        recordesQuebrados++;
                        ultimaPontuacaoRecorde = pont.QuantidadePontuacao;
                    }

                    lastPont = pont.QuantidadePontuacao;
                }


                lblQtdVezesBateuProprioRecorde.Text = recordesQuebrados.ToString();
            }
            else
            {
                pnlResultados.Visible = false;

                ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'warning',title: 'Atenção',text: 'Não foram encontrado jogos no período selecionado'});", true);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void LimparCampos()
    {
        txtDataJogo.Text = string.Empty;
        txtPontuacao.Text = string.Empty;

        lblPeriodo.Text = string.Empty;

        lblJogosDisputados.Text = "";
        lblTotalPontos.Text = "";
        lblMediaPontos.Text = "";
        lblMaiorPontuacao.Text = "";
        lblMenorPontuacao.Text = "";
        lblQtdVezesBateuProprioRecorde.Text = "";

        pnlResultados.Visible = false;
    }

    private bool ValidarConsulta()
    {
        string msgValidacao = string.Empty;
        bool camposOK = true;

        try
        {
            if (!DateTime.TryParse(txtDtInicial.Text, out DateTime outData))
            {
                msgValidacao += "Insira uma data inicial válida, no formato dd/mm/yyyy.";
                camposOK = false;
            }

            if (!DateTime.TryParse(txtDtFinal.Text, out DateTime outData2))
            {
                msgValidacao += "Insira uma data final válida, no formato dd/mm/yyyy.";
                camposOK = false;
            }

            if (outData > outData2)
            {
                msgValidacao += "Data inicial não pode ser maior que a final.";
                camposOK = false;
            }

            if (!camposOK)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'warning',title: 'Oopsss...',text: '" + msgValidacao + "'});", true);
                return false;
            }
            else
                return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private bool ValidarInclusao()
    {
        string msgValidacao = string.Empty;
        bool camposOK = true;

        try
        {
            if (!DateTime.TryParse(txtDataJogo.Text, out DateTime outData))
            {
                msgValidacao += "Por favor, insira uma data de jogo válida, no formato dd/mm/yyyy.";
                camposOK = false;
            }

            if (!int.TryParse(txtPontuacao.Text, out int outInt) || outInt < 0)
            {
                msgValidacao += " Insira o total de pontuação, que pode ser igual ou maior que zero.";
                camposOK = false;
            }

            if (!camposOK)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "validação", "Swal.fire({type: 'warning',title: 'Oopsss...',text: '" + msgValidacao + "'});", true);
                return false;
            }
            else
                return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion

}