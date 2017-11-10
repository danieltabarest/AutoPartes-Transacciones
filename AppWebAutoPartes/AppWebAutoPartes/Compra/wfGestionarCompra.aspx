<%@ Page Title="Gestión Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfGestionarCompra.aspx.cs" Inherits="AppWebAutoPartes.Pedido.wfGestionarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Gestión Compra</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="aupCabOrd" runat="server">
        <ContentTemplate>
            <table style="width:50%;"align="center">
                <tr>
                    <td>Número de Compra:</td>
                    <td>
                        <asp:TextBox ID="txtNumCompra" runat="server" Height="12px" Width="105px" TabIndex="1"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" TabIndex="2" Text="B" Height="24px" />
                    </td>
                </tr>
                <tr>
                    <td>Fecha:</td>
                    <td>
                        <asp:Calendar ID="calFecOrd" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="160px" Width="182px" TabIndex="3">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>Cliente:</td>
                    <td>
                        <asp:DropDownList ID="ddlCliente" runat="server" TabIndex="4">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Empleado:</td>
                    <td>
                        <asp:DropDownList ID="ddlEmpleado" runat="server" TabIndex="5">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Valor:</td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server" Height="12px" Width="105px" TabIndex="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Iva:</td>
                    <td>
                        <asp:TextBox ID="txtIva" runat="server" Height="12px" Width="105px" TabIndex="7"></asp:TextBox>
                    </td>
                </tr>
                 <tr style="text-align: center">
                    <td colspan="2" aria-hidden="False">
                        <asp:Button ID="btnNuevoCab" runat="server" OnClick="btnNuevoCab_Click" Text="Nuevo" />
                        <asp:Button ID="btnGuardarCab" runat="server" Text="Guardar" OnClick="btnGuardarCab_Click" />
                        <asp:Button ID="btnGuardarComision" runat="server" OnClick="btnGuardarComision_Click" Text="Guarda Comision" Width="127px" />
                        <asp:Button ID="btnCancelarCab" runat="server" OnClick="btnCancelarCab_Click" Text="Cancelar" />
                        <asp:Button ID="btnEliminarCab" runat="server" OnClick="btnEliminarCab_Click" Text="Eliminar" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2">
                        <asp:Label ID="lblMsjCab" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="aupDetOrd" runat="server">
        <ContentTemplate>
            <table style="width:50%;" align="center">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvDetalle" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnPageIndexChanging="gvDetalle_PageIndexChanging" PageSize="5" OnRowEditing="gvDetalle_RowEditing">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Producto:</td>
                    <td>
                        <asp:DropDownList ID="ddlProducto" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Cantidad:</td>
                    <td>
                        <asp:TextBox ID="txtCant" runat="server" Height="12px" Width="103px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Valor:</td>
                    <td>
                        <asp:TextBox ID="txtVlrServ" runat="server" Height="12px" Width="103px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnNuevoDet" runat="server" Text="Nuevo" OnClick="btnNuevoDet_Click" />
                        <asp:Button ID="btnAgregarDet" runat="server" OnClick="btnAgregarDet_Click" Text="Agregar" />
                        <asp:Button ID="btnEliminarDet" runat="server" Text="Eliminar" OnClick="btnEliminarDet_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMsjDet" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
