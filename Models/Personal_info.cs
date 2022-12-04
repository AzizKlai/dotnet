using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace tp3sqlite.Models
{
public class personal_info
{ public List<Person> GetAllPerson(){
    SqliteConnection sqlite_conn;
     List<Person> l=new List<Person>();
using(sqlite_conn=new SqliteConnection("Data Source=C:/Users/user/Documents/vscode proj/charpproj/tp2sqlite/src/database/TP3.db")){
    try{  sqlite_conn.Open();
  Debug.WriteLine("connection opened!");}
        
catch (Exception ex) {  }   
   
           
SqliteCommand sqlite_cmd;
sqlite_cmd=sqlite_conn.CreateCommand();
sqlite_cmd.CommandText="SELECT * FROM personal_info ";
//sqlite_cmd.ExecuteNonQuery();

SqliteDataReader sqlite_datareader;
sqlite_datareader =sqlite_cmd.ExecuteReader();
using(sqlite_datareader)
{  
    while(sqlite_datareader.Read())
  {  Person p=new Person();
    p.id=(Int64)sqlite_datareader["id"];
    p.firstName=(string)sqlite_datareader["first_name"];
    p.lastname=(string)sqlite_datareader["last_name"];
    p.email=(string)sqlite_datareader["email"];
    p.datebirth=(string)sqlite_datareader["date_birth"];
    p.image=(string)sqlite_datareader["image"];
    p.country=(string)sqlite_datareader["country"];
    l.Add(p);
}
} sqlite_conn.Close();
}

    return l;
}
    public Person GetPerson(int id){ 
SqliteConnection sqlite_conn;
Person p=null;
using(sqlite_conn=new SqliteConnection("Data Source=C:/Users/user/Documents/vscode proj/charpproj/tp2sqlite/src/database/TP3.db")){
    try{  sqlite_conn.Open();}
        
catch (Exception ex) {  }       
SqliteCommand sqlite_cmd;
sqlite_cmd=sqlite_conn.CreateCommand();
sqlite_cmd.CommandText="SELECT * FROM personal_info WHERE id="+id;
//sqlite_cmd.ExecuteNonQuery();

SqliteDataReader sqlite_datareader;
sqlite_datareader =sqlite_cmd.ExecuteReader();
using(sqlite_datareader)
{   
    while(sqlite_datareader.Read())
{  p=new Person();
    p.id=(Int64)sqlite_datareader["id"];
    p.firstName=(string)sqlite_datareader["first_name"];
    p.lastname=(string)sqlite_datareader["last_name"];
    p.email=(string)sqlite_datareader["email"];
    p.datebirth=(string)sqlite_datareader["date_birth"];
    p.image=(string)sqlite_datareader["image"];
    p.country=(string)sqlite_datareader["country"];
   
}
}

}  

        return p;
    }

    public List<Person> GetPersonBy(String firstname,String country){ 
SqliteConnection sqlite_conn;
  List<Person> l=new List<Person>();
using(sqlite_conn=new SqliteConnection("Data Source=C:/Users/user/Documents/vscode proj/charpproj/tp2sqlite/src/database/TP3.db")){
    try{  sqlite_conn.Open();}
        
catch (Exception ex) {  }       
SqliteCommand sqlite_cmd;
sqlite_cmd=sqlite_conn.CreateCommand();
if(firstname==null)firstname="";
if(country==null)country="";
sqlite_cmd.CommandText="SELECT * FROM personal_info WHERE UPPER(first_name) LIKE '%"
                    + firstname.ToUpper()
                    + "%' and UPPER(country) LIKE '%"
                    + country.ToUpper()
                    + "%' ";
//sqlite_cmd.ExecuteNonQuery();

SqliteDataReader sqlite_datareader;
sqlite_datareader =sqlite_cmd.ExecuteReader();
using(sqlite_datareader)
{   
    while(sqlite_datareader.Read())
{  Person p=new Person();
    p.id=(Int64)sqlite_datareader["id"];
    p.firstName=(string)sqlite_datareader["first_name"];
    p.lastname=(string)sqlite_datareader["last_name"];
    p.email=(string)sqlite_datareader["email"];
    p.datebirth=(string)sqlite_datareader["date_birth"];
    p.image=(string)sqlite_datareader["image"];
    p.country=(string)sqlite_datareader["country"];
   l.Add(p);
}
}

}  

        return l;
    }  

}}