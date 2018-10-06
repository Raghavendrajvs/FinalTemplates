<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTemplates.aspx.cs" Inherits="NHUB.AddTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
        <div style="height: 493px; position: relative;" class="text-center"> <br />
            <h1 class="text-center"> Add Template </h1>
            <div class="text-center">
            <br />
            </div>
            <h2 class="text-center">
                &nbsp;</h2>
                <table class="auto-style1">
                    <tr>
                        <td style="width: 382px" class="text-center"> Service Line : </td>
                        <td style="width: 486px" class="text-center">
                            &nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style8" style="position: relative; left: -98px; top: 2px; width: 270px; height: 30px; right: 98px;" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString %>" SelectCommand="SELECT [Name], [Id] FROM [ServiceLine]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 382px" class="text-center"> Notification : </td>
                        <td style="width: 486px" class="text-center">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style7" style="position: relative; left: -97px; top: 0px; width: 261px; height: 30px" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString2 %>" SelectCommand="SELECT [Id], [Name] FROM [Event]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 382px" class="text-center"> Template Name : </td>
                        <td style="width: 486px" class="text-center">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" style="position: relative; left: -97px; top: 0px; width: 251px; height: 30px;"></asp:TextBox>
                        &nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 382px" class="text-center"> Mandatory event :</td>
                        <td style="width: 486px" class="text-left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Mandatry Event" />
&nbsp;&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 382px" class="text-center"> Select Channel : </td>
                        <td style="width: 486px" class="text-center">
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="auto-style6" style="position: relative; left: -93px; top: 0px; width: 270px; height: 30px" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Name">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString3 %>" SelectCommand="SELECT [Name], [Id] FROM [Channel]"></asp:SqlDataSource>
                            <div class="text-left">
                        &nbsp;</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 382px; height: 25px"></td>
                        <td style="width: 486px; height: 25px" class="text-left">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style5" style="position: relative; left: 23px; top: 0px; width: 195px" Height="30px" />
                            <div class="text-center">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 382px; height: 50px"></td>
                        <td style="width: 486px; height: 50px"></td>
                    </tr>
                    <tr>
                        <td style="width: 382px; height: 54px" class="text-center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" Text="Cancel" OnClick="Button4_Click" style="position: relative; left: -13px; top: 1px; height: 33px; width: 100px" />
                        </td>
                        <td class="auto-style3" style="width: 486px; height: 54px; text-align: center;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button3" runat="server" Text="Create" OnClick="Button3_Click" style="position: relative; left: -109px; top: -1px; width: 106px; height: 32px" />
                        </td>
                    </tr>
                </table>
             <h2>
                 &nbsp;</h2>
             <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;
                 </h2>
            <h2>
                &nbsp;</h2>
        </div>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
