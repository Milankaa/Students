using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentApplication.Services
{
    public class StudentRepos
    {
        private SqlConnection con;
        private SqlCommand com;

        private readonly string constr = "Data Source=DESKTOP-F7I4C5G;Initial Catalog=Test_db;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";


        public List<Student> GetStudents()
        {
            using (con = new SqlConnection(constr))
            using (com = new SqlCommand("SviStudenti", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                List<Student> studentList = new List<Student>();
                Student student;
                while (reader.Read())
                {
                    student = new Student
                    {
                        Student_id = int.Parse(reader["Student_id"].ToString()),
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        Godina = reader["Godina"].ToString(),
                        BrojIndeksa = reader["BrojIndeksa"].ToString(),
                        StatusStudenta = int.Parse(reader["StatusStudenta"].ToString())
                    };
                    studentList.Add(student);
                }
                reader.Close();
                return studentList;

            }

        }
        public Student GetStudent(int id)
        {
            using (con = new SqlConnection(constr))
            using (com = new SqlCommand("PodaciOStudentima", con))
            {

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@StudentId", id);
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                reader.Read();
                Student student = new Student
                {
                    Student_id = int.Parse(reader["Student_id"].ToString()),
                    Ime = reader["Ime"].ToString(),
                    Prezime = reader["Prezime"].ToString(),
                    Godina = reader["Godina"].ToString(),
                    BrojIndeksa = reader["BrojIndeksa"].ToString(),
                    StatusStudenta = int.Parse(reader["StatusStudenta"].ToString())
                };
                reader.Close();
                com = new SqlCommand("StudentPohadjaKurseve", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Student_id", id);
                SqlDataReader dr = com.ExecuteReader();
                Kurs course;
                while (dr.Read())
                {
                    course = new Kurs
                    {
                        ID_kursa = int.Parse(dr["ID_kursa"].ToString()),
                        NazivKursa = dr["NazivKursa"].ToString()
                    };
                    student.Kurs.Add(course);
                }

                con.Close();
                return student;

            }

        }
        //public List<Kurs> GetCourses(int id)
        //{
        //    using (con = new SqlConnection(constr))
        //    using (com = new SqlCommand("StudentPohadjaKurseve", con))
        //            {
        //                com.CommandType = CommandType.StoredProcedure;
        //                com.Parameters.AddWithValue("@Student_id", id);
        //                con.Open();
        //                SqlDataReader dr = com.ExecuteReader();
        //                dr.Read();
        //                List<Kurs> coursesList = new List<Kurs>();
        //                Kurs course ;
        //                while (dr.Read())
        //                {
        //                    course = new Kurs
        //                    {
        //                        ID_kursa = int.Parse(dr["ID_kursa"].ToString()),
        //                        NazivKursa = dr["NazivKursa"].ToString()
        //                    };
        //                    coursesList.Add(course);
        //                }
        //                dr.Close();
        //                return coursesList;

        //        }
        //}
        public string AddStudent(Student st)
        {
            using (con = new SqlConnection(constr))
            using (com = new SqlCommand("UnosStudenta", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Ime", st.Ime);
                com.Parameters.AddWithValue("@Prezime", st.Prezime);
                com.Parameters.AddWithValue("@Godina", st.Godina);
                com.Parameters.AddWithValue("@BrojIndeksa", st.BrojIndeksa);
                com.Parameters.AddWithValue("@Status", st.StatusStudenta);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i == -1)
                    return "Uspješno ste dodali studenta";
                else
                    return "Greška prilikom unosa!";

            }
        }

        public string DeleteStudent(int id)
        {
            using (con = new SqlConnection(constr))
            using (com = new SqlCommand("BrisanjeStudenta", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdStudenta", id);
                if (con.State != ConnectionState.Open)
                    con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "Uspješno ste obrisali studenta";

                }
                else
                {
                    return "Greška prilikom unosa!";

                }
            }
        }


        public string UpdateStudent(Student st)
        {
            using (con = new SqlConnection(constr))
            using (com = new SqlCommand("IzmjenaStudenta", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdStudenta", st.Student_id);
                com.Parameters.AddWithValue("@Ime", st.Ime);
                com.Parameters.AddWithValue("@Prezime", st.Prezime);
                com.Parameters.AddWithValue("@Godina", st.Godina);
                com.Parameters.AddWithValue("@BrojIndeksa", st.BrojIndeksa);
                com.Parameters.AddWithValue("@StatusStudenta", st.StatusStudenta);
                con.Open();
                int i = com.ExecuteNonQuery();
                //con.Close();
                if (i >= 1)
                    return "Uspješno ste izmjenili podatke";
                else return "Greška prilikom unosa!";
            }
        }
    }

    }
