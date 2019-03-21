using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ILayout
    {
        /// <summary>
        /// Provides the message format.
        /// </summary>
        string Format { get; }
    }
}
