using Cosmetics.Commands.Contracts;
using Cosmetics.Core.Contracts;
using Cosmetics.Exceptions;
using System;

namespace Cosmetics.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command cannot be empty.";

        private readonly ICommandFactory _commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputLine))
                    {
                        throw new InvalidInputException(EmptyCommandError);
                    }

                    inputLine = inputLine.Trim();

                    if (inputLine.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    ICommand command = _commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DuplicatedEntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType()}: {ex.Message}"); 
                }
            }
        }
    }
}
