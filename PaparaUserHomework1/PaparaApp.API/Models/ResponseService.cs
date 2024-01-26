namespace PaparaApp.API.Models;

public class ResponseService<T>
{
    public T? Data { get; set; }


    public List<string>? Errors { get; set; }


    // static factory method design pattern
    public static ResponseService<T> Success(T data)
    {
        return new ResponseService<T>
        {
            Data = data
        };
    }

    public static ResponseService<T> Fail(List<string> errors)
    {
        return new ResponseService<T>
        {
            Errors = errors
        };
    }

    public static ResponseService<T> Fail(string error)
    {
        return new ResponseService<T>
        {
            Errors = new List<string> { error }
        };
    }
}