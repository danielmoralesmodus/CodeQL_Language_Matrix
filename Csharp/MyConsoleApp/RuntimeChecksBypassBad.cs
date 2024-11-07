using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

[Serializable]
[ExcludeFromCodeCoverage]
public class PersonBad : ISerializable
{
    public int Age;

    public PersonBad(int age)
    {
        if (age < 0)
            throw new ArgumentException(nameof(age));
        Age = age;
    }

    [OnDeserializing]
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        Age = info.GetInt32("age");  // BAD - write is unsafe
        string fileName = GetUserInput(); // Assume GetUserInput() retrieves a file name from the user
        FileStream fileStream = new FileStream(fileName, FileMode.Open);

    }

    private string GetUserInput()
    {
        throw new NotImplementedException();
    }
}
