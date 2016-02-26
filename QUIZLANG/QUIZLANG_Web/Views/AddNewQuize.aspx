<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewQuize.aspx.cs" Inherits="QUIZLANG_Web.Views.AddNewQuize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>Learning language:<asp:DropDownList  ID="dropDownListLearning" Width="200" runat="server" OnSelectedIndexChanged="dropDownListLearning_SelectedIndexChanged" ></asp:DropDownList></td>
                
                <td>Native language:<asp:DropDownList ID="dropDownListNative" runat="server" Width="200" AutoPostBack="true" OnSelectedIndexChanged="dropDownListNative_SelectedIndexChanged"></asp:DropDownList></td>
                <td></td>
            </tr>
            <tr>
                <td style="column-span:all;text-align:left;">Questions:</td>             
            </tr>
            <tr>
                <td class="text-align:right;">
                <asp:ListBox ID="listBoxQuestion" Width="400" SelectionMode="Multiple" Height="300" runat="server">
                   
                </asp:ListBox>

                </td>
                <td><asp:Button ID="btnSelect" Width="75" runat="server" Text="Add" OnClick="btnSelect_Click1" /></td>             
                <td> <asp:ListBox ID="listBoxSelectQustion" SelectionMode="Multiple" Width="400" Height="300" runat="server"></asp:ListBox></td>
            </tr>
            <tr>
                 <td><asp:Button ID="btnAdd" Width="75" runat="server" Text="Add Quiz" OnClick="btnAdd_Click1" /></td>   
            </tr>
        </table>
    </div>
</asp:Content>
