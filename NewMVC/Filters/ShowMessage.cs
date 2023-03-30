using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Text;

namespace NewMVC.Filters
{
    public class ShowMessage : Attribute, IResultFilter
    {
        private readonly string Message;
        public ShowMessage(string message)
        {
            this.Message = message;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<h2>{Message}</h2>");
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }

        public  void OnResultExecuting(ResultExecutingContext context)
        {
            //byte[] bytes = Encoding.ASCII.GetBytes($"<h2>{Message}</h2>");
           
            ////context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
           
            
        }
    }
}
