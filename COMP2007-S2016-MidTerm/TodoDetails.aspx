<%--  File name: TodoDetails.aspx --%>
<%--  Author's name: Pui In Kwok --%>
<%--  Web site name: Todo List App --%>
<%--  File description: This page will show todo details if it is exist,
                        and allow user to edit details, else user
                        can enter new todo details and save it --%>

<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <div class="row">
             <div class="col-md-offset-2 col-md-8">
                 <h1>Todo Details</h1>
                 <div class="form-group">
                     <label class="control-label" for="TodoNameTextBox">Todo Name</label>
                     <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="Todo Name" required="true"></asp:TextBox>
                 </div>
                 <div class="form-group">
                     <label class="control-label" for="TodoNotesTextBox">Todo Notes</label>
                     <asp:TextBox runat="server" CssClass="form-control" ID="TodoNotesTextBox" placeholder="Todo Notes" required="true"></asp:TextBox>
                 </div>
                 <div class="form-group">
                     <asp:CheckBox runat="server" ID="CompleteCheckBox" CssClass="form-control" Text="Completed" OnCheckedChanged="CompleteCheckBox_CheckedChanged"/>
                 </div>
                 <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
             </div>
         </div>
     </div>
</asp:Content>
