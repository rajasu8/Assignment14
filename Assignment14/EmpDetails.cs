using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Assignment14
{
    class EmpDetails
    {
        string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        long mobile;

        public long Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        int empId;


        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

           public int  getDetails(int id,string name, int age, string gender,string location,long mobile , string mail,string address)
        {

            SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

            SqlCommand command = new SqlCommand("Emp_AddDetails", connect);

            command.CommandType=CommandType.StoredProcedure;

          
            connect.Open();
            command.Parameters.Add("@EmpID",SqlDbType.Int).Value=Convert.ToInt32(id);

            command.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@Age", SqlDbType.Int).Value = Convert.ToInt32(age);

            command.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@Location", SqlDbType.VarChar).Value = location;

            command.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = Convert.ToInt64(mobile);
           
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = mail;
            command.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;


 
            int result=command.ExecuteNonQuery();

            return result ;
        }



           public ArrayList GetEmpID()
           {
               ArrayList list = new ArrayList();

               SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

               SqlCommand command = new SqlCommand("select EmpID from Emp ", connect);

               connect.Open();

               SqlDataReader readers = command.ExecuteReader();

               while (readers.Read())
               {
                   list.Add(readers["EmpID"]);
               }

               return list;

           }


           public void updateDetails(int ID,string name, int age, string gender, string location, long mobile, string mail, string address)
           {
               int ageemp =age;
               long number =mobile;


               SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

               SqlCommand command = new SqlCommand("update Emp set EmpName ='" + name + "',Age='" + ageemp + "',Gender='" + gender + "' ,Mobile ='" + number + "',Email='" + mail + "',Address='" + address + "' where EmpID ='" +ID+"'" , connect);

               connect.Open();
               SqlDataReader readers = command.ExecuteReader();

           }
           public void deleteDetails(int ID)

           {
               SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

               SqlCommand command = new SqlCommand(" delete from Emp where EmpID ='" + ID + "'", connect);

               connect.Open();
               SqlDataReader readers = command.ExecuteReader();

           }

           public List<EmpDetails> viewBang()
           {
               List<EmpDetails> old = new List<EmpDetails>();
               string name = "bangalore";

               SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

               SqlCommand command = new SqlCommand("select * from Emp where Location='" + name + "'", connect);

               connect.Open();

               SqlDataReader readers = command.ExecuteReader();
               
               while (readers.Read())
               {
                   EmpDetails obj = new EmpDetails();

                   obj.EmpId = Convert.ToInt32(readers["EmpID"]);
                   obj.EmpName=Convert.ToString(readers["EmpName"]);
                   obj.Age = Convert.ToInt32(readers["Age"]);
                   obj.Gender=Convert.ToString(readers["Gender"]);
                   obj.Location = Convert.ToString(readers["Location"]);
                   obj.Mobile = Convert.ToInt64(readers["Mobile"]);
                   obj.Email = Convert.ToString(readers["Email"]);
                   obj.Address = Convert.ToString(readers["Address"]);
                   old.Add(obj);

               }
               //old.Add(obj);
               return old;
           }






           

     public List<EmpDetails> viewage()
           {
               List<EmpDetails> old = new List<EmpDetails>();
               //string name = "bangalore";

               SqlConnection connect = new SqlConnection("server=D11-PC\\SQLEXPRESS; database=employee; Integrated Security=true");

               SqlCommand command = new SqlCommand("select * from Emp where Age>15 ", connect);

               connect.Open();

               SqlDataReader readers = command.ExecuteReader();
               EmpDetails obj = new EmpDetails();

               while (readers.Read())
               {
                   EmpDetails obj = new EmpDetails();
                   obj.EmpId = Convert.ToInt32(readers["EmpID"]);
                   obj.EmpName=Convert.ToString(readers["EmpName"]);
                   obj.Age = Convert.ToInt32(readers["Age"]);
                   obj.Gender=Convert.ToString(readers["Gender"]);
                   obj.Location = Convert.ToString(readers["Location"]);
                   obj.Mobile = Convert.ToInt64(readers["Mobile"]);
                   obj.Email = Convert.ToString(readers["Email"]);
                   obj.Address = Convert.ToString(readers["Address"]);
                   old.Add(obj);
                  
               }
              
               return old;
           }




    }

            
}
