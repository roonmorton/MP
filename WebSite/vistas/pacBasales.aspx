<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="pacBasales.aspx.cs" Inherits="vistas_pacBasales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:TextBox runat="server" ID="txtprueba" CssClass="fecha"></asp:TextBox>
<asp:Button runat="server" ID="btnPrueba" onclick="btnPrueba_Click" />
</asp:Content>

