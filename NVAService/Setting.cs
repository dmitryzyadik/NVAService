using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NVAService
{
    class Setting
    {
        private DataSet1 ds1 = new DataSet1();

        public string HOSTNAME { get; set; }
        public string FIO { get; set; }
        public string TITLE { get; set; }
        public string ORG { get; set; }
        public string PHONE { get; set; }

    }

    class SettingHelper
    { 
        public  static void SaveSetting(string _HOSTNAME, string _FIO, string _TITLE, string _ORG, string _PHONE)
        {
            DataSet1TableAdapters.NVAServiceTableAdapter adapter = new DataSet1TableAdapters.NVAServiceTableAdapter();
            DataSet1.NVAServiceDataTable ns = new DataSet1.NVAServiceDataTable();
            adapter.UpdateQuery(_HOSTNAME,_FIO,_TITLE,_ORG,_PHONE, _HOSTNAME);            
        }

        public  static Setting LoadSetting(string _HOSTNAME)
        {
            DataSet1TableAdapters.NVAServiceTableAdapter adapter = new DataSet1TableAdapters.NVAServiceTableAdapter();
            DataSet1.NVAServiceDataTable ns = new DataSet1.NVAServiceDataTable();
            ns = adapter.GetDataBy4(_HOSTNAME);
            if (ns.Count > 0)
            {
                return new Setting() { HOSTNAME = ns[0].HOST, FIO = ns[0].FIO, TITLE = ns[0].TITLE, ORG = ns[0].ORG, PHONE = ns[0].PHONE };
            }
            else
            {
                adapter.InsertQuery(_HOSTNAME, "", "", "", "");
                ns = adapter.GetDataBy4(_HOSTNAME);
                return new Setting() { HOSTNAME = ns[0].HOST, FIO = ns[0].FIO, TITLE = ns[0].TITLE, ORG = ns[0].ORG, PHONE = ns[0].PHONE };
            }
        }
    }


    


}
