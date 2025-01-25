using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.PhayarSar
{
    public class PhayarSarTitle
    {
        public int groupId { get; set; }
        public string title { get; set; }
        public List<PhayarSarDetail> Data { get; set; }

    }

    public class PhayarSarDetail
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }



}

