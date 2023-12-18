﻿using FluentValidation.Results;

namespace AH.Metadata.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Failures = new Dictionary<string, string[]>();
    }

    public ValidationException(ValidationFailure failure) : this(new List<ValidationFailure> { failure }) { }

    public ValidationException(IList<ValidationFailure> failures) : this()
    {
        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Failures.Add(propertyName, propertyFailures);
        }
    }

    public IDictionary<string, string[]> Failures { get; }
}
