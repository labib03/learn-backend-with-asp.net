namespace latihan.api;

public class AddUserDTO
{
    public string FirstName {set; get;} = string.Empty;
    public string LastName {set; get;} = string.Empty;
    public int Age {set; get;}
    public Gender? Gender {set; get;}
}
