﻿namespace ExplicitInterfaces.Models.Interfaces
{
    internal interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string GetName();
    }
}
