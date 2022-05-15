using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    class TableService
    {
        TableDao tabledb;

        public TableService()
        {
            tabledb = new TableDao();
        }

        public List<Table> GetBills()
        {
            List<Table> tables = tabledb.GetAllTables();
            return tables;
        }
    }
}
