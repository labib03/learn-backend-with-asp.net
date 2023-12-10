namespace latihan.api;

public class GetUserDTO
    {
        public int id {set; get;}
        public string FirstName {set; get;} = string.Empty;
        public string LastName {set; get;} = string.Empty;
        public int Age {set; get;}
        public Gender? Gender {set; get;}
    }
