using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.Shared
{
    [Table("Tbl_Data")]
   public class BurmaProjectModel
    {
          [Key]
            public int groupId { get; set; }
            public string title { get; set; }
            public List<GroupData> DataItems { get; set; } 

        }

        public class GroupData
        {
            [Key]
            public int id { get; set; }
            public int groupId { get; set; }
            public string title { get; set; }
            [Column("dataContent")]
            public string content { get; set; }
        }

    public class BurmaProjectResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public BurmaProjectModel Data { get; set; }
    }

    public class BurmaProjectListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<BurmaProjectModel> Data { get; set; }
    }

    //public class BurmaProjectRequestModel
    //{
    //    public List<BurmaProjectModel> burmaProjects { get; set; }
    //    public List<GroupData> groupDatas { get; set; }
    //}


}
