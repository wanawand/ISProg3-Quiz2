<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Products_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a Product</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1 class="text-center">Add a Product</h1>
        <div class="col-lg-12">
            <div class="well clearfix">
                <form runat="server" class="form-horizontal">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label col-lg-4">Name</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtName" runat="server"
                                    class="form-control"
                                    MaxLength="50" autocomplete="off" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Category</label>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlCategory" runat="server"
                                    CssClass="form-control" autocomplete="off" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Code</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtCode" runat="server"
                                    CssClass="form-control" autocomplete="off"
                                    MaxLength="20" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Description</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"
                                    MaxLength="300" TextMode="MultiLine" Rows="5" autocomplete="off" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Image </label>
                            <div class="col-lg-8">
                                <asp:FileUpload ID="fullImage" runat="server" class="form-control" autocomplete="off" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Price</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtPrice" runat="server"
                                    class="form-control" type="number" min="0.01" max="500000.00"
                                    step="0.01" autocomplete="off" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Is Featured?</label>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlFeatured" runat="server" CssClass="form-control" autocomplete="off">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label col-lg-4">Available</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtAvailable" runat="server" CssClass="form-control"
                                    MaxLength="12" type="number" required></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-lg-4">Status</label>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" autocomplete="off">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Critical Level</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtCritical" runat="server"
                                    class="form-control" autocomplete="off"
                                    MaxLength="12" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Maximun</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtMaximum" runat="server"
                                    class="form-control" autocomplete="off"
                                    MaxLength="12" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-offset-4 col-lg-8">
                                <asp:Button ID="btnAdd" runat="server"
                                    class="btn btn-success pull-right" Text="Add"
                                    OnClick="btnAdd_Click" />
                            </div>
                        </div>
                    </div>
            </div>
            </form>
        </div>
    </div>


</body>
</html>
