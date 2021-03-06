﻿// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;

namespace ElasticLinq.Retry
{
    /// <summary>
    /// The exception that is thrown when an operation does not succeed within a specified number of attempts.
    /// </summary>
    public class RetryFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryFailedException"/> specifying the number of attempts.
        /// </summary>
        /// <param name="maxAttempts">Number of attempts tried.</param>
        public RetryFailedException(int maxAttempts)
            : base(string.Format("The operation did not succeed after the maximum number of retries ({0}).", maxAttempts)) { }
    }
}