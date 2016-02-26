<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EvaluatePerformance.aspx.cs" Inherits="QUIZLANG_Web.Views.EvaluatePerformance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server" ID="lbNote" Text="please select your student first" BackColor="Black" Font-Size="20" ForeColor="#3399ff" Font-Names="微软雅黑" Width="100%"></asp:Label><br />
        <asp:DropDownList runat="server" ID="dropDownListStudent" Width="200" AutoPostBack="true"></asp:DropDownList><br />
        <div style="text-align: center; width: 100%;">

            <asp:GridView runat="server" ID="gridViewStudentDetail" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>  <%--行号自行+1--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="time" HeaderText="Time">
                        <HeaderStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="result" HeaderText="TestResult" />
                    <asp:BoundField DataField="nativeLanName" HeaderText="nativeLanguageName" />
                    <asp:BoundField DataField="learntLanName" HeaderText="learntLanguageName" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel runat="server" ID="panelGrade" Visible="false">
            <asp:Label runat="server" ID="lbGrade" Text="Update student's grade&nbsp;" BackColor="Black" Font-Size="14" ForeColor="#6699ff" Font-Bold="true">
            </asp:Label>
            <asp:DropDownList runat="server" ID="dropDownListGrade" Width="80">
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="0">U</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button runat="server" ID="btnUpdate" Text="UpdateGrade" />
        </asp:Panel>
    </div>
</asp:Content>
