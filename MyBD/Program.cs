using Microsoft.Data.SqlClient;
using MyBD;
using MyBD.DBConfigLib;
using System.Linq.Expressions;

var connectionString = "Server=.\\SQLEXPRESS;Database=academy01;Trusted_Connection=True;Trust Server Certificate=true;";

var db = new SqlConnection(connectionString);
List<Teacher> teacher = new List<Teacher>();

db.Open();

SqlCommand choise = new SqlCommand("SELECT t.id, t.Name ,t.Salary ,t.Surname FROM Teachers t", db);
var reader = choise.ExecuteReader();

if (reader.HasRows)
{
    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0),reader.GetName(1), reader.GetName(2),reader.GetName(3));

    while (reader.Read()) // построчно считываем данные
    {
        object Id = reader.GetValue(0);
        object FirstName = reader.GetValue(1);
        object Salary = reader.GetValue(2);
        object LastName = reader.GetValue(3);

        teacher.Add(new Teacher()
        {
            ID = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            Salary = reader.GetDecimal(2),
            LastName = reader.GetString(3)
        });

        Console.WriteLine("{0}\t{1}\t{2}\t{3}", Id, FirstName, Salary, LastName);
    }
    reader.Close();
}
    db.Close();


foreach (var a in teacher)
{
    Console.WriteLine($"{a.ID} , {a.FirstName}, {a.Salary}, {a.LastName}");
}

teacher[0].ShowInfo();
teacher[1].ShowInfo();
teacher[8].ShowInfo();

Console.WriteLine("Вывести учителей у кого зарплата =5000");

for (int i= 0; i < teacher.Count; i++)
{
    if(teacher[i].Salary<=5000)
    {
        teacher[i].ShowInfo();
    }
}