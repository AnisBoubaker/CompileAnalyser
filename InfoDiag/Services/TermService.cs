using System;
using System.Collections.Generic;
using Constants;
using Entity;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class TermService : BaseService, ITermService
    {
        public ServiceCallResult Create(string alias)
        {
            alias = alias.ToUpper();

            var term = new Term
            {
                Alias = alias,
                Id = alias,
                TermType = FindTermType(alias) ?? TermTypeEnum.Fall,
                Year = int.Parse(alias.Substring(1)),
            };

            return Success();
        }

        public ServiceCallResult CreateMultiple(string startAlias, int number)
        {
            var aliases = CreateAliases(startAlias, number);
            return Success();
        }

        private IEnumerable<string> CreateAliases(string startAlias, int number)
        {
            var year = int.Parse(startAlias.Substring(1));
            var type = FindTermType(startAlias);

            return null;
        }

        private TermTypeEnum? FindTermType(string alias)
        {
            TermTypeEnum? result = null;
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

        private char FindTermTypePrefix(TermTypeEnum tte)
        {
            char result = ' ';
            switch (tte)
            {
                case TermTypeEnum.Winter:
                    result = 'H';
                    break;
                case TermTypeEnum.Fall:
                    result = 'A';
                    break;
                case TermTypeEnum.Summer:
                    result = 'E';
                    break;
            }

            return result;
        }

        private TermTypeEnum NextTermType(TermTypeEnum tte)
        {
            return (TermTypeEnum)(((int)tte + 1) % 3);
        }
    }
}
