namespace Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Entity.DTO;
    using Services.Models;

    public interface IStatService
    {
        ServiceCallResult<IEnumerable<StatDto>> Get(int clientId, DateTime? from = null, DateTime? to = null);

        ServiceCallResult<IEnumerable<StatDto>> Get(string groupId, DateTime? from = null, DateTime? to = null);

        void ProcessNewCompilation();
    }
}
