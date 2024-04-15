﻿using System;

namespace Cosmetics.Exceptions
{
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException(string message)
            : base(message)
        {

        }
    }
}
