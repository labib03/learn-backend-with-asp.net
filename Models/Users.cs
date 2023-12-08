using System.ComponentModel.DataAnnotations;

namespace latihan.api;

public class Users
{

[Key]
public int id {set; get;}
public string FirstName {set; get;} = "Jhon";
public string LastName {set; get;} = "Cordoba";
public required Int64 Age {set; get;}


}
