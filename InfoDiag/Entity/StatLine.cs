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

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? ErrorCodeId { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public virtual ErrorCode ErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }
    }
}
