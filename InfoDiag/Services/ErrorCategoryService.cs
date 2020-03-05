using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entity;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    internal class ErrorCategoryService : BaseService, IErrorCategoryService
    {
        private readonly IErrorCategoryRepository _errorCategoryRepository;
        private readonly IErrorCodeRepository _errorCodeRepository;
        private readonly IMapper _mapper;

        internal ErrorCategoryService(
            IErrorCategoryRepository errorCategoryRepository,
            IErrorCodeRepository errorCodeRepository,
            IMapper mapper)
        {
            _errorCategoryRepository = errorCategoryRepository;
            _errorCodeRepository = errorCodeRepository;
            _mapper = mapper;
        }

        public ServiceCallResult<ErrorCategoryDto> Add(string name)
        {
            var result = _errorCategoryRepository.Insert(new ErrorCategory { Name = name });

            return Success(_mapper.Map<ErrorCategoryDto>(result));
        }

        public ServiceCallResult Assign(int categoryId, params string[] errorCodeIds)
        {
            var ecs = _errorCodeRepository.Get(ec => errorCodeIds.Contains(ec.Id));

            foreach (var ec in ecs)
            {
                ec.ErrorCategoryId = categoryId;
            }

            _errorCodeRepository.Update(ecs);

            return Success();
        }

        public ServiceCallResult Unassign(params string[] errorCodeIds)
        {
            var ecs = _errorCodeRepository.Get(ec => errorCodeIds.Contains(ec.Id));

            foreach (var ec in ecs)
            {
                ec.ErrorCategoryId = null;
            }

            _errorCodeRepository.Update(ecs);

            return Success();
        }

        public ServiceCallResult Delete(int category)
        {
            _errorCategoryRepository.Delete(ec => ec.Id == category);

            return Success();
        }

        public ServiceCallResult<IEnumerable<ErrorCategoryDto>> GetAll()
        {
            return Success(_mapper.Map<IEnumerable<ErrorCategoryDto>>(_errorCategoryRepository.AllAsQueryable.Include(ec => ec.RelatedErrors)));
        }
    }
}
