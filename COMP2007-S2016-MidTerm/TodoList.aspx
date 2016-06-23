﻿<%--  File name: TodoList.aspx --%>
<%--  Author's name: Pui In Kwok --%>
<%--  Web site name: Todo List App --%>
<%--  File description: --%>

<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <div class="row">
             <div class="col-md-offset-2 col-md-8">
                 <h1>Todo List</h1>
                 <div>
                     <a href="TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Todo</a>
                     <label>Records Per Page : </label>
                     <asp:DropDownList ID="TodoDropDownList" runat="server" AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle" OnSelectedIndexChanged="TodoDropDownList_SelectedIndexChanged">
                         <asp:ListItem Text="3" Value="3" />
                         <asp:ListItem Text="5" Value="5" />
                         <asp:ListItem Text="10" Value="10" />
                         <asp:ListItem Text="All" Value="10000" />
                     </asp:DropDownList>
                 </div>
                 <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="TodoGridView" 
                     AutoGenerateColumns="false" OnRowDeleting="TodoGridView_RowDeleting" DataKeyNames="TodoID" AllowPaging="true" 
                     PageSize="3" OnPageIndexChanged="TodoGridView_PageIndexChanging" AllowSorting="true" OnSorted="TodoGirdView_Sorting" OnRowDataBound="TodoGridView_RowDataBound">
                     <Columns>
                         <asp:BoundField DataField="TodoName" HeaderText="Todo" Visible="true" SortExpression="Todo" />
                         <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" SortExpression="Notes" />
                         <asp:CheckBoxField DataField="Completed" HeaderText="Completed" Visible="true" SortExpression="Completed" />
                         <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'><i> Edit" NavigateUrl="~/TodoDetails.aspx" 
                             ItemStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" 
                             ControlStyle-ForeColor="White" ItemStyle-VerticalAlign="Middle" />
                         <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'><i> Delete" ShowDeleteButton="true" ButtonType="Link" 
                             ControlStyle-CssClass="btn btn-danger btn-sm" />
                      </Columns>
                 </asp:GridView>
             </div>
         </div>
     </div>
</asp:Content>
