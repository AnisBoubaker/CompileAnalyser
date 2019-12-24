using System;
using Services.Models;

namespace Services
{
    public class BaseService
    {
        protected ServiceCallResult<T> Success<T>(T value)
        {
            return new ServiceCallResult<T>()
            {
                Type = ResultType.Success,
                Value = value,
            };
        }

        protected ServiceCallResult Error(string error)
        {
            return new ServiceCallResult
            {
                Type = ResultType.Error,
                Error = error,
            };
        }

        protected ServiceCallResult<T> Error<T>(string error)
        {
            return new ServiceCallResult<T>
            {
                Type = ResultType.Error,
                Error = error,
                Value = default,
            };
        }

        protected ServiceCallResult<T> Exception<T>(Exception exception)
        {
            return new ServiceCallResult<T>()
            {
                Error = exception.Message,
                Type = ResultType.Error,
                Value = default,
            };
        }

        protected ServiceCallResult Exception(Exception exception)
        {
            return new ServiceCallResult()
            {
                Error = exception.Message,
                Type = ResultType.Error,
            };
        }

        protected ServiceCallResult Success()
        {
            return new ServiceCallResult
            {
                Type = ResultType.Success,
            };
        }
    }
}
