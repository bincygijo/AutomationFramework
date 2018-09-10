using Framework.Config;
using Framework.Global;
using Framework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    public class Class1
    {
        [TestFixture]
        [Category("Sprint_1")]
        class Sprint_1 : Base
        {

            [Test]
            public void TestCase_001_User_login_with_correct_username()
            {
                test = extent.StartTest("Verify Application");
                if (Resource.IsLogin == "true")
                {
                    Login loginobj = new Login();
                    loginobj.LoginSuccessfull();
                }
                else
                {
                    Register obj = new Register();
                    obj.UserRegistration();
                }
          
            }


        }

    }
}
