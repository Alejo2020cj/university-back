using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using University.BL.Data;



namespace University.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(UniversityContext.Create);   
        }
    }
}
