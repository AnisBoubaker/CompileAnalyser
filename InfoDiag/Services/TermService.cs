namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Constants;
    using Entity;
    using Entity.DTO;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    internal class TermService : BaseService, ITermService
    {
        private readonly ITermRepository _termRepository;
        private readonly IMapper _mapper;

        public TermService(ITermRepository termRepository, IMapper mapper)
        {
            _termRepository = termRepository;
            _mapper = mapper;
        }

        public ServiceCallResult Create(string alias)
        {
            alias = alias.ToUpper();

            var term = new Term
            {
                Id = alias,
                TermType = FindTermType(alias),
                Year = int.Parse(alias.Substring(1)),
            };

            _termRepository.Insert(term);

            return Success(_mapper.Map<TermDto>(term));
        }

        public ServiceCallResult CreateCurrentTerm()
        {
            var currentYear = DateTime.Now.Year % 100;
            var currentMonth = DateTime.Now.Month;
            string currentAlias;

            if (currentMonth < 5)
            {
                currentAlias = "H" + currentYear;
            }
            else if (currentMonth < 8)
            {
                currentAlias = "E" + currentYear;
            }
            else
            {
                currentAlias = "A" + currentYear;
            }

            _termRepository.Insert(new Term
            {
                Id = currentAlias,
                Year = currentYear,
                TermType = FindTermType(currentAlias),
            });

            return Success();
        }

        public ServiceCallResult CreateMultiple(string startAlias, int number)
        {
            var aliases = CreateAliases(startAlias, number);
            var terms = new List<Term>();
            foreach (var alias in aliases)
            {
                terms.Add(new Term
                {
                    Id = alias,
                    TermType = FindTermType(alias),
                    Year = int.Parse(alias.Substring(1)),
                });
            }

            return Success();
        }

        public ServiceCallResult<IEnumerable<string>> GetAll()
        {
            return Success(_termRepository.AllAsQueryable.Select(t => t.Id).AsEnumerable());
        }

        private IEnumerable<string> CreateAliases(string startAlias, int number)
        {
            var aliases = new List<string>(number)
            {
                startAlias,
            };
            var i = 1;

            while (i != number)
            {
                startAlias = NextAlias(startAlias);
                aliases.Add(startAlias);
                i++;
            }

            return aliases;
        }

        private TermTypeEnum FindTermType(string alias)
        {
            TermTypeEnum result = TermTypeEnum.Winter;
            switch (alias.ToCharArray()[0])
            {
                case 'H':
                    result = TermTypeEnum.Winter;
                    break;
                case 'A':
                    result = TermTypeEnum.Fall;
                    break;
                case 'E':
                    result = TermTypeEnum.Summer;
                    break;
            }

            return result;
        }

        private string FindTermTypePrefix(TermTypeEnum tte)
        {
            string result = " ";
            switch (tte)
            {
                case TermTypeEnum.Winter:
                    result = "H";
                    break;
                case TermTypeEnum.Fall:
                    result = "A";
                    break;
                case TermTypeEnum.Summer:
                    result = "E";
                    break;
            }

            return result;
        }

        private TermTypeEnum NextTermType(TermTypeEnum tte)
        {
            return (TermTypeEnum)(((int)tte + 1) % 3);
        }

        private string NextAlias(string current)
        {
            var year = int.Parse(current.Substring(1));
            var type = NextTermType(FindTermType(current));

            if (type == TermTypeEnum.Winter)
            {
                year++;
            }

            return FindTermTypePrefix(type) + year;
        }
    }
}
