using Application.BusinessLogic;
using Evolantis.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Public
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["a"] == "out")
                    {
                        AuthenticationService.Signout();
                        Response.Redirect("~/login", true);
                    }
                }               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UsersProcessor controller = new UsersProcessor();

            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username != "" && password != "")
            {

                var user = controller.Login(username);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        UserIdentity identity = new UserIdentity()
                        {
                            ID = user.ID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Role = user.Role,
                        };

                        AuthenticationService.Signin(identity, true);

                        if (Request.QueryString.Count > 0)
                        {
                            string returlUrl = Request.QueryString["returnUrl"];
                            if (!string.IsNullOrWhiteSpace(returlUrl.Replace("/", "")))
                                Response.Redirect(returlUrl);
                        }

                        Response.Redirect("~/login", true);
                    }
                    else
                    {
                        Response.Write("Invalid Password!");
                    }
                }
                else
                {
                    Response.Write("Account not exist!");
                }
            }
            else
            {
                Response.Write("Please input username and password!");
            }

        }
    }
}