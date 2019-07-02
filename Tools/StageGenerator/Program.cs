using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageGenerator
{
    /// <summary>
    /// This command line tool is to help generate the data file for the poem stage.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.Generate("sample_input.json", "sample_output.json");
        }
        

    }
}
