namespace latihan.api;

public class ResponseSuccess<T> : BaseResponseModel
{
    public T? data {set; get;}
}
