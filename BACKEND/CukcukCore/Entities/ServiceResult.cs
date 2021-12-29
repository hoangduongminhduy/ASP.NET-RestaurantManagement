using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukcukCore.Entities
{
	public class ServiceResult
	{
		public ServiceResult()
		{
		}
		public bool success { get; set; } = true;
		public string devMsg { get; set; } = "";
		public string userMsg { get; set; } = "";
		public string errorCode { get; set; } = "";
		public string moreInfo { get; set; } = "google.com";
		public object data { get; set; } = null;

		public void setField(bool _success, string _devMsg, object _data)
		{
			success = _success;
			if (success)
			{
				userMsg = "Success proccessing";
				errorCode = "000";
			} else
			{
				userMsg = "Error occured. Please contact MISA.";
				errorCode = "MF965";
			}
			devMsg = _devMsg;
			data = _data;
		}
	}
}
