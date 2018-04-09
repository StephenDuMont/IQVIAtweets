using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IQVATestCL
{
    class Options
    {
        [Option('s', "startDate", Required = true, HelpText = "Start Date of Tweets")]
        public DateTime startDate { get; set; }

        [Option('e', "endDate", Required = true, HelpText = "End Date of Tweets")]
        public DateTime endDate { get; set; }



    }
}
