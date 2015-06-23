using System.IO;
using System.Web.UI;

namespace RedCell.Web.SmsRepository
{
    /// <summary>
    /// SMS API page
    /// </summary>
    public partial class Default : Page
    {
        #region Methods
        /// <summary>
        /// Initializes the <see cref="T:System.Web.UI.HtmlTextWriter"/> object and calls on the child controls of the <see cref="T:System.Web.UI.Page"/> to render.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> that receives the page content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            var root = Context.Request.PhysicalApplicationPath;
            var appData = Path.Combine(root, @"App_Data\");
            var controller = new Controller(appData);

            // Malformed request.
            if(Request.Params["Body"] == null)
            {
                Response.ContentType = "text/plain";
                Response.StatusCode = 400;
                return;
            }

            string message = controller.ParseTwilioRequest(Request.Params["Body"]);
            var response = controller.WriteTwilioResponse(message);

            Response.ContentType = "text/xml";
            Response.CacheControl = "no-cache";
            Response.Expires = -1;
            writer.Write(response);

            base.Render(writer);
        }
        #endregion
    }
}