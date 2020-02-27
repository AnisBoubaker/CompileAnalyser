namespace Entity
{
    using Constants.Enums;

    public class StatLine : IBaseEntity<long>
    {
        public long Id { get; set; }

        public long StatsId { get; set; }

        public int NbOccurence { get; set; }

        public virtual Stats Stats { get; set; }

        public bool IsErrorCode { get; set; }

        public string? ErrorCodeId { get; set; }

        public virtual ErrorCode ErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }
    }
}
