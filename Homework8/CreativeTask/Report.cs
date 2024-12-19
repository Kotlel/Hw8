using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativeTask;
using static System.Net.Mime.MediaTypeNames;

namespace CreativeTask
{
    class Report
    {
        public string Text { get; }
        public DateTime CompletionDate { get; }
        public string Executor { get; }

        public Report(string text, DateTime completionDate, string executor)
        {
            Text = text;
            CompletionDate = completionDate;
            Executor = executor;
        }
    }
}

