using System;
using System.Linq;
using AutoMapper;
using Entity;
using Services.Models;

namespace Services.Profiles
{
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
            switch (value)
            {
                case "warning":
                    return CompilationErrorType.CompilerWarning;
                case "error":
                    return CompilationErrorType.CompilerError;
                case "fatal":
                    return CompilationErrorType.CompilerFatal;
                case "note":
                    return CompilationErrorType.Note;
                default:
                    return CompilationErrorType.Other;
            }
        }

        public static CompilationErrorLine MapCompilationErrorLine(string text)
        {
            return new CompilationErrorLine { Text = text };
        }
    }
}
