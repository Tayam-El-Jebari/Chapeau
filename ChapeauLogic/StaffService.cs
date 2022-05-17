using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class StaffService
    {
        StaffDao staffDb;

        public StaffService()
        {
            staffDb = new StaffDao();
        }

        public List<Staff> GetStaffs()
        {
            List<Staff> staffs = staffDb.GetAllStaffs();
            return staffs;
        }

        public string GetSaltByStaffID(int staffID)
        {
            return staffDb.GetAllSaltByID(staffID);
        }

        public Staff CheckPassword(int staffID, string hashedPassword)
        {
            return staffDb.CheckPassword(staffID, hashedPassword);
        }

        public void AddNewStaffMember(string firstname, string lastname, int phonenumber, string email, HashWithSaltResult hashedPassword)
        {
            staffDb.AddNewStaffMember(firstname, lastname, phonenumber, email, hashedPassword);
        }
    }
}

