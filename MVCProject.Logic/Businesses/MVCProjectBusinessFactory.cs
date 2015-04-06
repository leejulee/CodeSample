using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using MVCProject.Common;

namespace MVCProject.Logic
{ 
	public static class MVCProjectBusinessFactory  
	{   
				
		public static ILogBusiness LogBusiness = UnityHelper.Resolve<ILogBusiness, LogBusiness>();

	}
}