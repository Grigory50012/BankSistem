using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace BankSistem.ActionFilters
{
    public class ValidateAccountExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateAccountExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var idAccount = (Guid)context.ActionArguments["idAccount"];
            var account = await _repository.Account.GetAccountAsync(idAccount, trackChanges);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("account", account);
                await next();
            }
        }
    }

}
