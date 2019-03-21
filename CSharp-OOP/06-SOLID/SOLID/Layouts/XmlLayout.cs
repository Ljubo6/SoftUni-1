using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Layouts
{
    public class XmlLayout : ILayout
    {
        private string GenerateMessage()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine(" <date>{0}</date>");
            sb.AppendLine(" <level>{1}</level>");
            sb.AppendLine(" <message>{2}</message>");
            sb.Append("</log>");
            return sb.ToString();
        }

        public string Format => this.GenerateMessage();
    }
}
