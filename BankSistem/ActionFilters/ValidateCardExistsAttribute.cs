using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace BankSistem.ActionFilters
{
    public class ValidateCardExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateCardExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = method.Equals("PATCH") ? true : false;
            var idAccount = (Guid)context.ActionArguments["idAccount"];
            var account = await _repository.Account.GetAccountAsync(idAccount, false);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} doesn't exist in the database.");
               
                context.Result = new NotFoundResult();
                return;
            }
            var idCard = (Guid)context.ActionArguments["idCard"];
            var card = await _repository.Card.GetCardAsync(idAccount, idCard, trackChanges);
            if (card == null)
            {
                _logger.LogInfo($"Employee with id: {idCard} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("card", card);
                await next();
            }
        }
    }
}

