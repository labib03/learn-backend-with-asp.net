namespace latihan.api;

public class DataResponseModel<T>
{
    public int? Total {set;get;}
    public T? Data {set; get;}
}
