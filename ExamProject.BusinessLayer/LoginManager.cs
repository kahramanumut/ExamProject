using ExamProject.DAL;
using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.BusinessLayer
{
    public class LoginManager
    {
        ExamDbContext db = new ExamDbContext();

        public bool LoginCheck(User user)
        {
            if (db.User.Where(x => x.Username == user.Username && x.Password == user.Password).Count() > 0)
                return true;
            else
                return false;
        }

    }
}
