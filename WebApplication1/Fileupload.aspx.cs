using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fileupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/images/product/")+"1";
            System.IO.Directory.CreateDirectory(path);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}