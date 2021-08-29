namespace API.Model
{
    public class ConnectionString
    {
        public string Cs{get;set;}
        public ConnectionString(){
            string username = "ro6qlrll4ao1q6bo";
            string password = "rxg6eqeehg2kzice";
            string host = "u6354r3es4optspf.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string port = "3306";
            string database = "k4kkq7m0kg73pdia";

            Cs = $@"host={host};username={username};database={database};port={port};password={password}";
        }
    }
}