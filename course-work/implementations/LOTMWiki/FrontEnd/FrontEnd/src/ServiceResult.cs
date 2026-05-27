using System.Collections.Generic;

namespace FrontEnd;

public class Error
{
    public string Key { get; set; }
    public List<string> Messages { get; set; }
}

public class ServiceResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public List<Error> Errors { get; set; }
}   