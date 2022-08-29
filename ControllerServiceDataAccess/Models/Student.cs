using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ControllerServiceDataAccess.Models
{
    [Table("STUDENT")]
    public class Student
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("ID", TypeName = "NVARCHAR2(50)")]
        [Description("ID")]
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column("NAME", TypeName = "NVARCHAR2(50)")]
        [Description("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Column("AGE")]
        [Description("Age")]
        public int Age { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CREATE_TIME")]
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
