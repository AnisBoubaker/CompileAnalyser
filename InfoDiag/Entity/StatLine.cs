using Constants.Enums;

namespace Entity
{
    public class StatLine : IBaseEntity<long>
    {
        public long Id { get; set; }

        public int StatsId { get; set; }

        public int NbOccurence { get; set; }

        public virtual Stats Stats { get; set; }

        public bool IsErrorCode { get; set; }

        public string? ErrorCodeId { get; set; }

        public virtual ErrorCode ErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }
    }
}
