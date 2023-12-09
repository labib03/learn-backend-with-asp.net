using System.ComponentModel.DataAnnotations;

namespace latihan.api;

public class Users
{

[Key]
public int id {set; get;}
public string FirstName {set; get;} = string.Empty;
public string LastName {set; get;} = string.Empty;
public int Age {set; get;}


}
