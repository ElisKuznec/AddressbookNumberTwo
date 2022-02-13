using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    
    {
    public static string CONTACTWINTITLE = "Contact editor";
    public ContactHelper(AppManager manager) : base(manager) { }

    public List<ContactData> GetContactList()
        
        {
            List<ContactData> list = new List<ContactData>();

            return list;
        }

    }
}