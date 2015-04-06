using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using MVCProject.Common;

namespace MVCProject.Data
{ 
	public static class MVCProjectRepositoryFactory  
	{   
				
		public static ILogRepository LogRepository = UnityHelper.Resolve<ILogRepository, LogRepository>();

	}
}