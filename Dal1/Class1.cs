using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Dal1
{
    public  class Class1
    {

         DialogflowDataEntities db = new DialogflowDataEntities();

        public List<user> getAllName()
        {
            {
                try
                {
                    List<user> b = db.user.ToList();
                    b.GroupBy(x=>x.idUser);
                    List<user> u = db.user.ToList().GroupBy(x => x.idUser).Select(x => x.First()).OrderBy(x=>x.name).ToList();
                    Console.WriteLine(u);
                    return u;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<user> getpdfByname(int iduser)
        {
            {
                try
                {
                    List<user> u = db.user.ToList().Where(x=>x.idUser==iduser).ToList();
                    return u;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<user> getAllNotChecked()
        {
            {
                try
                {
                    List<user> u = db.user.ToList().Where(x=>x.@checked==false).OrderBy(x=>x.score).ToList();

                    return u;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool updateCheckedUser(int id)
        {
            try
            {

                using (DialogflowDataEntities db = new DialogflowDataEntities())
                {
                    user u = db.user.Where(x => x.id == id).FirstOrDefault();
                    u.@checked = true;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public  bool Post(users user)
        {
            
            try
            {

                using (DialogflowDataEntities db = new DialogflowDataEntities())
                {
                    db.users.Add(user);
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception)
            {
                throw;
                //return false;
            }
        }
        public static users Score(users user)
        {
            user.score = 0;
            if (user.systolic > 125&&user.systolic!=0)
                user.score += (user.systolic - 115) / 10 * 5;
            if (user.diastolic > 85 && user.diastolic != 0)
                user.score += (user.diastolic - 75) / 10 * 5;
            if (user.age > 40)
                user.score += (user.age - 30) / 10*5;
            if (user.isCholesterol)
                user.score += 10;
            if (user.isDiabetes)
                user.score += 10;
            if (user.isDrug)
                user.score += 10;
            if (user.isObesity)
                user.score += 10;
            if (user.isSmoking)
                user.score += 10;
            return user;
        }

    }
}
