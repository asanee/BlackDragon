<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BlackDragon.TimeSheets.Shared.FullProfileDto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        View</h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            UserName</div>
        <div class="display-field">
            <%: Model.UserName %></div>
        <div class="display-label">
            FirstName</div>
        <div class="display-field">
            <%: Model.FirstName %></div>
        <div class="display-label">
            LastName</div>
        <div class="display-field">
            <%: Model.LastName %></div>
        <div class="display-label">
            Email</div>
        <div class="display-field">
            <%: Model.Email %></div>
        <table id="user-index">
            <% foreach (var result in Model.OwnCircles)
               {%>
            <tr>
                <td>
                    <%: Html.ActionLink(result, "View",
                    "Circle", new { userName = result}, null)%>
                </td>
            </tr>
            <% }%>
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
