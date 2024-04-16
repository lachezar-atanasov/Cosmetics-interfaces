using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Commands.Enums;
using Cosmetics.Core.Contracts;
using System;
using System.Collections.Generic;
using Cosmetics.Exceptions;

namespace Cosmetics.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository _repository;

        public CommandFactory(IRepository repository)
        {
            _repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            // RemoveEmptyEntries makes sure no empty strings are added to the result of the split operation.
            string[] arguments = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandType = arguments[0];
            List<string> commandParameters = ExtractCommandParameters(arguments);

            switch (commandType)
            {
                case nameof(CommandType.CreateCategory):
                    return new CreateCategoryCommand(commandParameters, _repository); 
                case nameof(CommandType.CreateProduct):
                    return new CreateProduct(commandParameters, _repository);
                case nameof(CommandType.CreateShampoo):
                    return new CreateShampooCommand(commandParameters, _repository);
                case nameof(CommandType.CreateCream):
                    return new CreateCreamCommand(commandParameters, _repository);
                case nameof(CommandType.CreateToothpaste):
                    return new CreateToothpasteCommand(commandParameters, _repository);
                case nameof(CommandType.AddProductToCategory):
                    return new AddToCategoryCommand(commandParameters, _repository);
                case nameof(CommandType.RemoveFromCategory):
                    return new RemoveFromCategoryCommand(commandParameters, _repository);
                case nameof(CommandType.AddToShoppingCart):
                    return new AddToShoppingCartCommand(commandParameters, _repository);
                case nameof(CommandType.RemoveFromShoppingCart):
                    return new RemoveFromShoppingCartCommand(commandParameters, _repository);
                case nameof(CommandType.ShowCategory):
                    return new ShowCategoryCommand(commandParameters, _repository);
                case nameof(CommandType.TotalPrice):
                    return new TotalPriceCommand(_repository);
                default:
                    throw new InvalidInputException($"Command with name: {commandType} is not supported!");
            }
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}
