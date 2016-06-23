/* File name: TodoList.aspx.cs
 * Author's name: Pui In Kwok
 * Web site name: Todo List App
 * File description: here will get all the todo from db,
                     allow user to sort the list
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }
        protected void GetTodo()
        {
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            using (TodoConnection db = new TodoConnection())
            {
                Todo updateTodo = (from todoRecords in db.Todos
                                   where todoRecords.TodoID == TodoID
                                   select todoRecords).FirstOrDefault();

                if (updateTodo != null)
                {
                    TodoNameTextBox.Text = updateTodo.TodoName;
                    TodoNotesTextBox.Text = updateTodo.TodoNotes;
                    if (updateTodo.Completed == true)
                    {
                        CompleteCheckBox.Checked = true;
                    }
                    else
                    {
                        CompleteCheckBox.Checked = false;
                    }
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {
                Todo newTodo = new Todo();

                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                newTodo.Completed = CompleteCheckBox.Checked;

                db.Todos.Add(newTodo);

                db.SaveChanges();

                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}