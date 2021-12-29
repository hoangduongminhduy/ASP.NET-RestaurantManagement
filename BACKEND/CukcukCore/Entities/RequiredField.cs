using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukcukCore.Entities
{
    /// <summary>
    /// Class attribute đánh dấu thông tin bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredField: Attribute
    {
        public string ErrorMsg { get; set; }
        public RequiredField(string errorMsg = "")
        {
            ErrorMsg = errorMsg;
        }
    }
}
