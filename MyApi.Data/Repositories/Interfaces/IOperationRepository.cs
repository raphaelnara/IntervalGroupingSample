using System;
using System.Collections.Generic;
using MyApi.Data.Model;

namespace MyApi.Data.Repositories.Interfaces
{
    public interface IOperationRepository
    {
        IEnumerable<CountByDate> GetTotalByDate(DateTime initialDate, DateTime endDate);
    }
}
