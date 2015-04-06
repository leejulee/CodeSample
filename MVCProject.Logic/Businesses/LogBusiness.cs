using MVCProject.Common;
using MVCProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCProject.Logic
{
    public class LogBusiness : ILogBusiness
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Common.Log entity)
        {
            throw new NotImplementedException();
        }

        public Common.Log GetData(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Common.Log entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Log> GetAllData()
        {

            try
            {
                return MVCProjectRepositoryFactory.LogRepository.GetAllData<Log>();
            }
            catch (Exception ex)
            {
                //TODO LOG
            }
            return null;
        }
    }
}
