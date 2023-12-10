namespace latihan.api;

public class ResponseService<T>
{
    public DataResponseModel<T>? Data {set; get;}
    public bool Success {set; get;}
    public string Message {set; get;} = string.Empty;
}
