using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.CustomFilters
{
	//https://www.codeproject.com/Tips/1156485/How-to-Create-and-Download-File-with-Ajax-in-ASP-N
	public class DeleteFileAttribute : ActionFilterAttribute
	{
		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			filterContext.HttpContext.Response.Flush();

			//convert the current filter context to file and get the file path
			string filePath = (filterContext.Result as FilePathResult).FileName;

			//delete the file after download
			System.IO.File.Delete(filePath);
		}
	}
}