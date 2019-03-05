using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Application.Models;
using Application.BusinessLogic;
using Evolantis.Lib;
using Evolantis.Lib.Extensions;

namespace WebApplication.Public
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int id = RouteParam.Value("id").EmptyToZero<int>();
                //var sid = RouteParam.Value("id").EmptyToZero<string>();

                //Response.Write(id);
                //Response.Write("<br/>");
                //Response.Write(sid.ToEmpty("zero"));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UsersProcessor controller = new UsersProcessor();
            UsersModel model = new UsersModel()
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Username = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            int id = controller.Add(model);

            if (id > 0)
            {
                Response.Redirect("~/login/");
            }
        }
    }
}