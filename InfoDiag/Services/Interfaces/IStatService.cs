using Entity.DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IStatService
    {
        public IEnumerable<StatDto> Get();
    }
}
