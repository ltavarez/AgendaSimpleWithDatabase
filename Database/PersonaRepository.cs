using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Modelos;

namespace Database
{
    public class PersonaRepository : RepositoryBase , IRepository<Persona>
    {

        public PersonaRepository(SqlConnection connection) : base(connection) { }


        public bool Add(Persona item)
        {
            SqlCommand command = new SqlCommand("insert into Personas(Nombre,Apellido,Telefono)" +
                                                "values (@name,@lastname,@phone)", GetConnection());

            command.Parameters.AddWithValue("@name", item.Nombre);
            command.Parameters.AddWithValue("@lastname", item.Apellido);
            command.Parameters.AddWithValue("@phone", item.Telefono);

            return ExecuteDml(command);

        }

        public bool Edit(Persona item)
        {
            SqlCommand command = new SqlCommand("update Personas set Nombre=@name,Apellido=@lastname,Telefono=@phone where Id = @id",GetConnection());

            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@name", item.Nombre);
            command.Parameters.AddWithValue("@lastname", item.Apellido);
            command.Parameters.AddWithValue("@phone", item.Telefono);

            return ExecuteDml(command);


        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete Personas where Id = @id",GetConnection());


            command.Parameters.AddWithValue("@id", id);

            return ExecuteDml(command);
        }

        public DataTable List()
        {
            SqlDataAdapter query = new SqlDataAdapter("Select Id,Nombre,Apellido,Telefono from Personas",GetConnection());
            return LoadData(query);
        }

        public Persona GetById(int id)
        {
            GetConnection().Open();

            Persona persona = new Persona();

            SqlCommand command = new SqlCommand("Select Id,Nombre,Apellido,Telefono from Personas where Id=@id",GetConnection());
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                persona.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                persona.Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                persona.Apellido = reader.IsDBNull(2) ? "" : reader.GetString(2);
                persona.Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3);

            }

            reader.Close();
            reader.Dispose();
            GetConnection().Close();

            return persona;
        }
    }
}
