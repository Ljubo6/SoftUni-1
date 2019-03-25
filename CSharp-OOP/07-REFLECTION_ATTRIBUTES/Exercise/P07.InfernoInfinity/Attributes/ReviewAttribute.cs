﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.InfernoInfinity.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReviewAttribute : Attribute
    {
        public ReviewAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviwers = reviewers.ToList();
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public List<string> Reviwers { get; set; }
    }
}
