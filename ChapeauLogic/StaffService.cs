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
    }
}

