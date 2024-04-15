using Cosmetics.Exceptions;
using System;
using System.Collections.Generic;

namespace Cosmetics.Helpers
{
    public class ValidationHelper
    {
        private const string InvalidNumberOfArguments = "{0} command expects {1} parameters.";
        private const string InvalidLengthErrorMessage = "{0} should be between {1} and {2} symbols.";
        private const string NegativeNumberErrorMessage = "{0} cannot be negative.";

        public static void ValidateIntRange(int minLength, int maxLength, int actualLength, string type)
        {
            if (actualLength < minLength || actualLength > maxLength)
            {
                throw new InvalidInputException(string.Format(InvalidLengthErrorMessage, type, minLength, maxLength));
            }
        }

        public static void ValidateStringLength(string stringToValidate, int minLength, int maxLength, string type)
        {
            ValidateIntRange(minLength, maxLength, stringToValidate.Length, type);
        }

        public static void ValidateArgumentsCount(int numberOfParameters, int expectedNumberOfParameters, string commandName)
        {
            if (numberOfParameters != expectedNumberOfParameters)
            {
                throw new InvalidInputException(string.Format(InvalidNumberOfArguments, commandName,
                    expectedNumberOfParameters));
            }

        }

        public static void ValidateNonNegative(decimal value, string field)
        {
            if (value < 0)
            {
                throw new InvalidInputException(string.Format(NegativeNumberErrorMessage, field));
            }
        }
    }
}
