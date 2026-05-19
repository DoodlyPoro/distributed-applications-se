using Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace api.Services;

public class ServiceResultExtension<T> where T : class, new()
{
    public static ServiceResult<T> Failure(T data, ModelStateDictionary errors)
    {
        var errorList = new List<Error>();
        foreach (var kvp in errors)
        {
            if (kvp.Value.Errors.Count > 0)
            {
                errorList.Add(new Error
                {
                    Key = kvp.Key,
                    Messages = kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                });
            }
        }
        
        return new ServiceResult<T>
        {
            IsSuccess = false,
            Data = data,
            Errors = errorList
        };
    }
}