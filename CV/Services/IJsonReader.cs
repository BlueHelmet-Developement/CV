using CV.Models;
using System;

namespace CV.Services
{
    public interface IJsonReader
    {
        Experience ReadJsonFile(string filePath);
    }
}
