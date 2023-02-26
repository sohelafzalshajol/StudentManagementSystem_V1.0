using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectEveningB2
{
    public partial class ResponseMessages : System.Web.UI.UserControl
    {
        public string SuccessMessage
        {
            set
            {
                pnlSuccess.Visible = true;
                pnlFailure.Visible = false;
                lblSuccess.Text = value;
            }
            get
            {
                return lblSuccess.Text;
            }
        }
        public string FailureMessage
        {
            set
            {
                pnlFailure.Visible = true;
                pnlSuccess.Visible = false;
                lblFailure.Text = value;
            }
            get
            {
                return lblFailure.Text;
            }
        }

        public void SetResponseMessageVisibleFalse()
        {
            pnlSuccess.Visible = false;
            pnlFailure.Visible = false;
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
    }
}