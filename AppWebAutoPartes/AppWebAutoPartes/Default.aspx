<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppWebAutoPartes._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>Bienvenidos a AutoPartes</h1>
            </hgroup>
            <p>
                Creado por: Daniel Esteban Tabares Taborda &amp; Arley Mauricio Santana</p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>
        Es una organización dedicada a la comercialización de auto partes multimarcas originales nuevas y usadas,suministramos productos de colombianos e importados de alta Calidad, con un excelente nivel de servicio y a precios razonables para satisfacer las necesidades del cliente.</p>
</asp:Content>
