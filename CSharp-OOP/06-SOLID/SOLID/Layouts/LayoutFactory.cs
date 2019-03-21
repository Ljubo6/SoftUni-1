using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Layouts
{
    /// <summary>
    /// Represents a standard factory-pattern utility for generating new layouts.
    /// </summary>
    public static class LayoutFactory
    {
        /// <summary>
        /// Creates a new layout based on type provided. Throws ArgumentException when type is invalid in current context.
        /// </summary>
        /// <param name="layoutType"></param>
        /// <returns></returns>
        public static ILayout Create(string layoutType)
        {
            switch (layoutType.ToLower())
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type provided!");
            }
        }
    }
}
