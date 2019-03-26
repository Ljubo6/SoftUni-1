using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.InfernoInfinity.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassAttribute : Attribute
    {
        public ClassAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers.ToList();
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public List<string> Reviewers { get; set; }
    }
}
