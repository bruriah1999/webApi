using Dal1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Utility
{
    public static class TemplateGenerator
    {
        public static object DataStorage { get; private set; }

        public static string GetHTMLString()
        {
            //var user =Class1.Get(3);

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
<h1>hiiiiiiiii<h1>


                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
