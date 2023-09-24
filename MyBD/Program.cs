using Microsoft.Data.SqlClient;
using MyBD;
using MyBD.DBConfigLib;
using System.Linq.Expressions;

var connectionString = "Server=.\\SQLEXPRESS;Database=academy01;Trusted_Connection=True;Trust Server Certificate=true;";

var db = new SqlConnection(connectionString);
List<Teacher> teacher = new List<Teacher>();

db.Open();

SqlCommand choise = new SqlCommand("SELECT t.id, t.Name ,t.Surname FROM Teachers t", db);
var reader = choise.ExecuteReader();

if (reader.HasRows)
{
    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1),reader.GetName(2));

    while (reader.Read()) // построчно считываем данные
    {
        object Id = reader.GetValue(0);
        object FirstName = reader.GetValue(1);
        object LastName = reader.GetValue(2);

        teacher.Add(new Teacher()
        {
            ID = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2)
        });

        Console.WriteLine("{0}\t{1}\t{2}", Id, FirstName, LastName);
    }
    reader.Close();
}
    db.Close();


foreach (var a in teacher)
{
    Console.WriteLine($"{a.ID} , {a.FirstName}, {a.LastName}");
}

teacher[0].ShowInfo();
teacher[1].ShowInfo();

