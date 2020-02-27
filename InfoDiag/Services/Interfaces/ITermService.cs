using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface ITermService
    {
        ServiceCallResult Create(string alias);

        ServiceCallResult CreateMultiple(string startAlias, int number);

        ServiceCallResult CreateCurrentTerm();

        ServiceCallResult<IEnumerable<string>> GetAll();
    }
}
