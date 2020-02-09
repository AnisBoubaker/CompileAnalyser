namespace Services.Interfaces
{
    using Services.Models;

    public interface ITermService
    {
        ServiceCallResult Create(string alias);

        ServiceCallResult CreateMultiple(string startAlias, int number);

        ServiceCallResult CreateCurrentTerm();
    }
}
