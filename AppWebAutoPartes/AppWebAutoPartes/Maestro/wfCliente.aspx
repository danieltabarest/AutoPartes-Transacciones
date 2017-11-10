<%@ Page Title="Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfCliente.aspx.cs" Inherits="AppWebAutoPartes.Maestro.wfCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Gestion Clientes</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        
    <table style="width:50%;"align="center">  <tr>
                    <td>Identificación Cliente:</td>
                    <td>
                        <asp:TextBox ID="txtIdCliente" runat="server" Height="12px" Width="105px" TabIndex="1"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" TabIndex="2" Text="B" Height="33px" Visible="False" />
                    </td>
                </tr>
          </table>
    <asp:UpdatePanel ID="aupCabOrd" runat="server">
        <ContentTemplate>
            <table style="width:50%;"align="center">
          
                <tr>
                    <td>Fecha Nacimiento:</td>
                    <td>
                        <asp:Calendar ID="dtmFechaNac" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="160px" Width="182px" TabIndex="3">
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
                    <td>Ciudad:</td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server" TabIndex="4">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Genero:</td>
                    <td>
                        <asp:DropDownList ID="ddlGenero" runat="server" TabIndex="5">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Nombre:</td>
                    <td>
                        <asp:TextBox ID="txtNombres" runat="server" Height="12px" Width="105px" TabIndex="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Apellidos:</td>
                    <td>
                        <asp:TextBox ID="txtApellidos" runat="server" Height="12px" Width="105px" TabIndex="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Telefonos:</td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" Height="12px" TabIndex="7" Width="95px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>E-Mail:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Height="12px" TabIndex="7" Width="105px"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
                <table style="width:50%;"align="center">  <tr style="text-align: center">
                    <td colspan="2">
                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                    </table>
    <asp:UpdatePanel ID="aupDetOrd" runat="server">
        <ContentTemplate>
            <table style="width:50%;" align="center">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvCliente" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnPageIndexChanging="gvDetalle_PageIndexChanging" PageSize="5">
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
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnBuscar1" runat="server" Text="Buscar" OnClick="btnBuscar1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
