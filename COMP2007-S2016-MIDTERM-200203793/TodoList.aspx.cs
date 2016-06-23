using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MIDTERM_200203793.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MIDTERM_200203793
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["SortColumn"] = "TodoID";
                Session["SortDirection"] = "ASC";

                this.GetTodo();
            }
        }
        protected void GetTodo()
        {
            using (TodoConnection db = new TodoConnection())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                var Todos = (from allTodos in db.Todos
                            select new
                            {
                                allTodos.TodoID,
                                allTodos.TodoName,
                                allTodos.TodoNotes,
                                allTodos.Completed
                            });
                TodoGridView.DataSource = Todos.AsQueryable().OrderBy(SortString).ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;

            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            using (TodoConnection db = new TodoConnection())
            {
                Todo deleteTodo = (from todoRecords in db.Todos
                                   where todoRecords.TodoID == TodoID
                                   select todoRecords).FirstOrDefault();

                db.Todos.Remove(deleteTodo);

                db.SaveChanges();

                this.GetTodo();
            }
        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TodoGridView.PageIndex = e.NewPageIndex;

            this.GetTodo();
        }

        protected void TodoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TodoGridView.PageSize = Convert.ToInt32(TodoDropDownList.SelectedValue);

            this.GetTodo();
        }

        protected void TodoGirdView_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;

            this.GetTodo();

            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(IsPostBack)
            {
                if(e.Row.RowType == DataControlRowType.Header)
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < TodoGridView.Columns.Count; index++)
                    {
                        if (TodoGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkButton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkButton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkButton);
                        }
                    }
                }
            }
        }
    }
}