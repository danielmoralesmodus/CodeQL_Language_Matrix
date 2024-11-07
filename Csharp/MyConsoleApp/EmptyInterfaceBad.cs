using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
class Bad
{
    interface IsPrintable { }
    class Form1 : IsPrintable { }
}
