using System;
using System.Collections.Generic;
using System.Text;

namespace NVAService
{
    class MessageHelper
    {

        public static void SendMessage(string _HOSTNAME, string _Message, DateTime _date)
        {
            DataSet1TableAdapters.HostMessageTableAdapter adapter = new DataSet1TableAdapters.HostMessageTableAdapter();
            DataSet1.HostMessageDataTable hm = new DataSet1.HostMessageDataTable();
            adapter.InsertQuery(_HOSTNAME, _Message,_date);
        }
    }
}
