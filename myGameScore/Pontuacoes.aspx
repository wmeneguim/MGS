<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pontuacoes.aspx.cs" Inherits="Pontuacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel-content">
        <nav>
            <div class="nav nav-tabs" id="nav-tab" role="tablist">
                <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Lançar pontos</a>
                <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Resultados</a>
            </div>
        </nav>
        <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                <div class="container">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Always" ViewStateMode="Enabled" RenderMode="Inline">
                        <ContentTemplate>
                            <div class="form-group">
                                <label>Data do jogo:</label>
                                <asp:TextBox runat="server" ID="txtDataJogo" CssClass="form-control datepicker" Width="150" autocomplete="off"></asp:TextBox>
                                <small id="dataHelp" class="form-text text-muted">Informe a data em que o jogo ocorreu.</small>
                            </div>
                            <div class="form-group">
                                <label>Pontuação:</label>
                                <asp:TextBox runat="server" ID="txtPontuacao" autocomplete="off" Width="150"
                                    class="form-control" role="spinbutton" MaxLength="5"></asp:TextBox>
                                <small id="pontuacaoHelp" class="form-text text-muted">Informe a pontuação feita no jogo.</small>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="btnSalvarPontuacao" runat="server" CssClass="btn btn-success mb-2"
                                    OnClick="btnSalvarPontuacao_Click" Text="Salvar" Width="150" OnClientClick="$(this).attr('disable', true);">
                                </asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                <br />
                <asp:UpdatePanel runat="server" ID="UpdatePanel2" ChildrenAsTriggers="true" UpdateMode="Always" ViewStateMode="Enabled" RenderMode="Inline">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="form-inline">
                                    <label>Período de&nbsp;&nbsp;</label>
                                    <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtDtInicial" autocomplete="off"
                                        placeholder="Data inicial" name="txtDtInicial" required Width="110">
                                    </asp:TextBox>
                                    <div class="valid-feedback">Valid.</div>
                                    <div class="invalid-feedback">Por favor, informe a data inicial!</div>
                                    <label>&nbsp;a&nbsp;</label>
                                    <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtDtFinal" autocomplete="off"
                                        placeholder="Data final" name="dtFinal" required Width="110">
                                    </asp:TextBox>
                                    <div class="valid-feedback">Valid.</div>
                                    <div class="invalid-feedback">Por favor, informe a data inicial!</div>
                                    &nbsp;&nbsp;
                            <div>
                                <asp:LinkButton ID="btnConsultar" runat="server" CssClass="btn btn-success"
                                    OnClick="btnConsultar_Click" Text="Consultar" Width="150">
                                </asp:LinkButton>
                            </div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlResultados" runat="server">
                            <hr />
                            <div class="form-group">
                                <div class="col-sm-6 text-left">
                                    <h4>Resultados</h4>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label runat="server" ID="lblPeriodo" CssClass="text-right"></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Jogos disputados:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblJogosDisputados" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Total de pontos marcados na temporada:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblTotalPontos" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Média de pontos por jogo:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblMediaPontos" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Maior pontuação em um jogo:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblMaiorPontuacao" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Menor pontuação em um jogo:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblMenorPontuacao" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            Quantidade de vezes que bateu o próprio recorde:
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblQtdVezesBateuProprioRecorde" Text="0" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

