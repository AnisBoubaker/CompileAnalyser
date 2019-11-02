namespace Services.Profiles
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Constants;
    using Entity;
    using Services.Models;

    public class CompilationLineProfile : Profile
    {
        public CompilationLineProfile()
        {
            _ = CreateMap<LogLine, CompilationError>()
                .ForMember(to => to.ErrorCodeId, opt => opt.MapFrom(from => from.Code))
                .ForMember(to => to.Type, opt => opt.MapFrom(from => MapCompilationError(from.Criticity)))
                .ForMember(to => to.Lines, opt => opt.MapFrom(from => from.Lines.Select(l => MapCompilationErrorLine(l))));
        }

        public static CompilationErrorType MapCompilationError(string value)
        {
            return value switch
            {
                "warning" => CompilationErrorType.CompilerWarning,
                "error" => CompilationErrorType.CompilerError,
                "fatal" => CompilationErrorType.CompilerFatal,
                "note" => CompilationErrorType.Note,
                _ => CompilationErrorType.Other,
            };
        }

        public static CompilationErrorLine MapCompilationErrorLine(string text)
        {
            return new CompilationErrorLine { Text = text };
        }
    }
}
