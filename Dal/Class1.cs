using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class Class1
    {
        static DialogflowDataEntities db = new DialogflowDataEntities();

        public static users Get(int id)
        {
            {
                try
                {
                    return db.users.FirstOrDefault(e => e.id == id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static void Post(users user)
        {

              try
                {
                using (DialogflowDataEntities db = new DialogflowDataEntities())

                {
             
                    db.users.Add(user);
                    db.SaveChanges();
               }
            }
                catch (Exception)
                {

                    throw;
                }
        }

    }
}
