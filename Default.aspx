<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href='https://fonts.googleapis.com/css?family=Work+Sans:100,400' rel='stylesheet' type='text/css'/>
    <link href="ADOStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="wrapper">
    <form id="form1" runat="server">
    <div>
        <h1>Authors</h1>
        <hr />
        <p><em>Select an author from the list to see their books.</em></p>
        <asp:DropDownList ID="AuthorDropDownList" 
            runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="AuthorDropDownList_SelectedIndexChanged"
            CssClass="list">

        </asp:DropDownList>
        <asp:GridView ID="booksGridView" runat="server"></asp:GridView>
    </div>
    </form>
    </div>
</body>
</html>
