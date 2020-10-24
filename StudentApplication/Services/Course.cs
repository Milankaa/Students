using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentApplication.Services
{
    public class Course
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private string constr = "Data Source=DESKTOP-F7I4C5G;Initial Catalog=Test_db;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
           
        public List<Kurs> GetCourses()
        {
            string query = "select * from Kurs;";
            using (con = new SqlConnection(constr))
            using (cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                List<Kurs> coursesList = new List<Kurs>();
                Kurs course;
                while (dr.Read())
                {
                    course = new Kurs()
                    {
                        ID_kursa = int.Parse(dr["ID_kursa"].ToString()),
                        NazivKursa = dr["NazivKursa"].ToString()
                    };
                    coursesList.Add(course);
                }
                return coursesList;
            }
           
        }
        public List<Student> GetStudents(int id)
        {
            using (con = new SqlConnection(constr))
            using (cmd = new SqlCommand("StudentiNaKursu", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Kurs_id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Student> studentList = new List<Student>();
                Student student;
                while (dr.Read())
                {
                    student = new Student()
                    {
                        Student_id = int.Parse(dr["Student_id"].ToString()),
                        Ime = dr["Ime"].ToString(),
                        Prezime = dr["Prezime"].ToString(),
                        Godina = dr["Godina"].ToString(),
                        BrojIndeksa = dr["BrojIndeksa"].ToString(),
                        StatusStudenta = int.Parse(dr["StatusStudenta"].ToString())
                    };
                    studentList.Add(student);
                }
                return studentList;
            }
        }
            
        public void AddCourse(string title)
        {
            using (con = new SqlConnection(constr))
            using (cmd = new SqlCommand("UnosKursa", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Naziv", title);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void AddStudentOnCourse(int idStudenta, int idKursa)
        {
            using (con = new SqlConnection(constr))
            using (cmd = new SqlCommand("UnosStudenataNaKurs", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_studenta", idStudenta);
                cmd.Parameters.AddWithValue("@ID_kursa", idKursa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
           

    }
}