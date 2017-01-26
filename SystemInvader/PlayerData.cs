using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace SystemInvader
{
    public class PlayerData
    {
        public string name { get; set; }
        public int score { get; set; }

        public override string ToString()
        {
            return string.Format("Name : {0} \nAge: {1}", name, score);
        }
    }
}
