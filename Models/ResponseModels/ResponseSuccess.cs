namespace latihan.api;

public class ResponseSuccess<T> : BaseResponseModel
{
    public required T data {set; get;}
}
