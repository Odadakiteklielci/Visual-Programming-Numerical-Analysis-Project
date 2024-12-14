namespace Sayısal_Analiz_Visual_Proje_
{
    public class UserSQL
    {
        // Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Hashlenmiş Şifre Saklanmalı
       

        // Constructor
        public UserSQL() { }

        public UserSQL(string username, string password)
        {
            
            Username = username;
            Password = password;
            
        }
    }
}
