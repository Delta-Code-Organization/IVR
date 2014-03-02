using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
    public partial class SystemUser
    {
        IVRDBEntities2 db = new IVRDBEntities2();
        public Returner CreateUser()
        {
            var exist = db.SystemUser.Any(p=>p.UserName==this.UserName);
            if (exist == true)
            {
                return new Returner
                {
                    message= Msgs.إسم_المستخدم_موجود_بالفعل
                };
            }
            db.SystemUser.Add(this);
            db.SaveChanges();
            var lastUser = db.SystemUser.OrderByDescending(p => p.ID).FirstOrDefault();
            return new Returner
            {
                Data = lastUser,
                message = Msgs.تم_إضافة_المستخدم_بنجاح
            };
        }
        public Returner UpdatePassword()
        {
            var updateduser = db.SystemUser.Where(p => p.ID == this.ID).SingleOrDefault();
            updateduser.Password = this.Password;
            db.SaveChanges();
            return new Returner
            {
                message = Msgs.نم_تعديل_الرقم_السري_بنجاح
            };
        }
        public Returner Login()
        {
            var exist = db.SystemUser.Any(p => p.Password == this.Password && p.UserName == this.UserName);
            if (exist == true)
            {
                return new Returner
                {
                    message = Msgs.دخول_ناجح
                };
            }
            return new Returner
            {
                message = Msgs.يوجد_خطأ_بالبريد_الالكتروني_أو_الرقم_السري
            };
        }
        public Returner GetSystemUser()
        {
            var user = db.SystemUser.Where(p => p.UserName == this.UserName).SingleOrDefault();
            return new Returner
            {
                Data = user
            };
        }
        public Returner DeleteSystemUser()
        {
            var user = db.SystemUser.Where(p => p.ID == this.ID).SingleOrDefault();
            db.SystemUser.Remove(user);
            db.SaveChanges();
            return new Returner
            {
                message = Msgs.تم_حذف_المستخدم_بنجاح
            };
        }
        public List<SystemUser> GetAllUsers()
        {
            var all = db.SystemUser.OrderBy(p => p.ID).ToList();
            return all;
        }
    }
}
