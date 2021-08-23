using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BondGadgetCollection.Data
{
    internal class GadgetDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgetDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // performs all operation on the database
        public List<GadgetModel> FechAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new Gadget object. add it to the list to return
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
                return returnList;

            }
        }

        //bring One
        public GadgetModel FechOne(int Id)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //associate @id with parameter Id
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE Id=@id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                GadgetModel gadget = new GadgetModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new Gadget object. add it to the list to return
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                    }
                }
                connection.Close();
                return gadget;
            }
        }

        internal int Delete(int id)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery =  "DELETE FROM dbo.Gadgets Where Id = @Id";



                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();
                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }


        //Create New
        public int CreateOrUpdate(GadgetModel gadgetModel)
        {

            //if gadgetModel.Id <= 1 then create

            //if gadgetModel.Id > 1 ,then update

            //access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";


                if (gadgetModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Gadget SET Name = @Name, Description = @Description, ApperasIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                }



                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;

                connection.Open();
                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }

        internal List<GadgetModel> SearchForName(string searchPrase)
        {

            List<GadgetModel> returnList = new List<GadgetModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE NAME LIKE @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.VarChar, 1000).Value = "%" + searchPrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new Gadget object. add it to the list to return
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
                return returnList;
            }
        }

        internal List<GadgetModel> SearchForDescription(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE DESCRIPTION LIKE @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.VarChar, 1000).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new Gadget object. add it to the list to return
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
                return returnList;
            }

        }

    }
}