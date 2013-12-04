<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BlackDragon.TimeSheets.Mvc.Models.SearchProfileModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Search</h2>
    <% using (Html.BeginForm())
       { %>
    <%: Html.LabelFor(x => x.Query) %>
    <%: Html.EditorFor(x => x.Query) %>
    <%: Html.ValidationMessageFor(x => x.Query) %>
    <button type="submit">
        Search</button>
    <% } %>
    <table id="user-index">
        <% foreach (var result in Model.Results) {%>
        <tr>
            <td>
                <%: Html.DisplayFor(model => result.FullName) %>
            </td>
        </tr>
        <% }%>
    </table>
</asp:Content>
