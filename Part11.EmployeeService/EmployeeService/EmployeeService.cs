﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EmployeeService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "EmployeeService"을 변경할 수 있습니다.
    public class EmployeeService : IEmployeeService
    {

        public Employee GetEmployee(int Id)
        {
 
            Employee employee = null;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = Id;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((EmployeeType)reader["EmployeeType"] == EmployeeType.FullTimeEmployee)
                    {
                        employee = new FullTimeEmployee 
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime( reader["DateOfBirth"]),
                            Type = EmployeeType.FullTimeEmployee,
                            AnnualSalary = Convert.ToInt32(reader["AnnualSalary"]),
                            City = reader["City"].ToString()
                        };
                    }
                    else
                    {
                        employee = new PartTimeEmployee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Type = EmployeeType.PartTimeEmployee,
                            HourlyPay = Convert.ToInt32(reader["HourlyPay"]),
                            HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                             City = reader["City"].ToString()
                        };
                    }
                }
            }


            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(parameterGender);

                SqlParameter parameterCity = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = employee.City
                };
                cmd.Parameters.Add(parameterCity);

                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterEmployeeType = new SqlParameter
                {
                    ParameterName = "@EmployeeType",
                    Value = employee.Type
                };
                cmd.Parameters.Add(parameterEmployeeType);

                if (employee.GetType() ==  typeof(FullTimeEmployee))
                {
                    SqlParameter parameterAnnualSalary = new SqlParameter
                    {
                        ParameterName = "@AnnualSalary",
                        Value = ((FullTimeEmployee)employee).AnnualSalary
                    };
                    cmd.Parameters.Add(parameterAnnualSalary);
                }
                else
                {
                    SqlParameter parameterHourlyPay = new SqlParameter
                    {
                        ParameterName = "@HourlyPay",
                        Value = ((PartTimeEmployee)employee).HourlyPay
                    };
                    cmd.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter
                    {
                        ParameterName = "@HoursWorked",
                        Value = ((PartTimeEmployee)employee).HoursWorked
                    };
                    cmd.Parameters.Add(parameterHoursWorked);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
 
    }
}
