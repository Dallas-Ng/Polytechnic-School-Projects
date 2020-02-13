using NYP.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NYP.BLL
{
    public class StudentsBLL
    {
        public DataSet getStudents(int OSEP_ID)
        {
            StudentsModel datastud;
            datastud = new StudentsModel();
            return datastud.getStudents(OSEP_ID);
        }

        public int InsertStudent(string Name, string Admin_No, string Course, string Contact_No, string PEM_Group, string Emergency_Person, string Emergency_Contact, string OSEP_ID)
        {
            StudentsModel datastud = new StudentsModel();
            return datastud.InsertStudent(Name, Admin_No, Course, Contact_No, PEM_Group, Emergency_Person, Emergency_Contact, OSEP_ID);
        }
    }
}