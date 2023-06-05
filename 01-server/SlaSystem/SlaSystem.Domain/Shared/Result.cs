﻿namespace SlaSystem.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        Error = error;
        IsSuccess = isSuccess switch
        {
            true when error != Error.None => throw new InvalidOperationException(),
            false when error == Error.None => throw new InvalidOperationException(),
            _ => isSuccess
        };
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }


    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

