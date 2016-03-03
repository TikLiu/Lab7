using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QUIZLANG_Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
              
                var userlist =StaticInfo.Entities.UserInfo.ToList();
                StaticInfo.CurrentUserInfo = userlist.Where(a => a.username == txtUserName.Text.Trim()).FirstOrDefault();
                //如果可以查询到当前用户，那么跳转到主页去
                if (StaticInfo.CurrentUserInfo != null)
                {
                    Server.Transfer("~/Views/MainPage.aspx");
                }
            }
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('username can not be empty！');</script>");
                return false;
            }
            return true;
        }
    }
}