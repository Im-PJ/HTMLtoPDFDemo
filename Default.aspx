<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SFHTMLtoPDF._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Enter Website URL</h1>
        <p>
            <asp:TextBox Width="200em" runat="server" ID="txtURL" />
        <p>
            <asp:Button Text="SyncFusion PDF" ID="btnPDF" runat="server" OnClick="btnPDF_Click" />
            <asp:Button Text="Puppeteer PDF" ID="btnPupet" runat="server" OnClick="btnPupet_Click" />

        </p>
    </div>


</asp:Content>
