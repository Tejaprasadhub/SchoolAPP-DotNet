using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model
{
    public class SettingsModel
    {
        public int id { get; set; }
        public string tran_key { get; set; }
        public string prom_key { get; set; }
        public string sender_code { get; set; }
        public string from_mail { get; set; }
        public string from_mailpassword { get; set; }
        public string port { get; set; }
        public string vendor_type { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string razor_api { get; set; }
        public string razor_key { get; set; }
        public string paypal_api { get; set; }
        public string paypal_key { get; set; }
        public string querytype { get; set; }
    }
}
