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
                    message= Msgs.User_Name_Already_Exist
                };
            }
            db.SystemUser.Add(this);
            db.SaveChanges();
            var lastUser = db.SystemUser.OrderByDescending(p => p.ID).FirstOrDefault();
            return new Returner
            {
                Data = lastUser,
                message = Msgs.User_Created_Successfull
            };
        }
        public Returner UpdatePassword()
        {
            var updateduser = db.SystemUser.Where(p => p.ID == this.ID).SingleOrDefault();
            updateduser.Password = this.Password;
            db.SaveChanges();
            return new Returner
            {
                message = Msgs.Password_Updated_Successfully
            };
        }
        public Returner Login()
        {
            var exist = db.SystemUser.Any(p => p.Password == this.Password && p.UserName == this.UserName);
            if (exist == true)
            {
                return new Returner
                {
                    message = Msgs.Successful_Login
                };
            }
            return new Returner
            {
                message = Msgs.Wrong_Name_Or_Password
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
            return new Returner
            {
                message = Msgs.System_User_Deleted_Successfully
            };
        }
    }
}
