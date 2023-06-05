﻿using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class UserName : ValueObject
{
    private UserName(string value) => Value = value;
    private string Value { get;  }

    public static UserName Create(string username) => new UserName(username);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}