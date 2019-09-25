using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HCServices.Models;

namespace HCServices.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            var AddressList = new List<Address> {
                new Address {
                    AddressID=1,Address1="123 test drive", Address2="", City="Atlanta", State="GA", Zip="30303",Country="USA"
                },
                 new Address {
                    AddressID=2,Address1="100 cumming drive", Address2="", City="Cumming", State="GA", Zip="30000",Country="USA"
                },
                 new Address {
                    AddressID=3,Address1="627 bend Drive", Address2="", City="Tampa", State="FL", Zip="20005",Country="USA"
                },
                 new Address {
                    AddressID=4,Address1="500 pike drive", Address2="", City="Nashville", State="TN", Zip="50300",Country="USA"
                },
                 new Address {
                    AddressID=5,Address1="1000 olympic way", Address2="", City="SAlt Lake City", State="UT", Zip="70408",Country="USA"
                }
            };

            var UserList = new List<User> {
                new User {
                    UserID=1, AddressID=1, FirstName="John", LastName="Doe", Age=20, Email="test@test.com", Phone="1231231234", IsActive=true, Hobbies="Tennis, reading, running"
                },
                new User {
                    UserID=2, AddressID=3, FirstName="james", LastName="Brown", Age=30, Email="jbrown@test.com", Phone="4047552345", IsActive=true, Hobbies="FootBall, reading, Piano"
                },
                new User {
                    UserID=3, AddressID=2, FirstName="Chris", LastName="Hill", Age=53, Email="chill@test.com", Phone="4706778765", IsActive=true, Hobbies="soccer, traveling, chess"
                },
                new User {
                    UserID=4, AddressID=4, FirstName="Brian", LastName="Thomas", Age=45, Email="bthomas@test.com", Phone="7701235432", IsActive=true, Hobbies="music, reading, running"
                },
                new User {
                    UserID=5, AddressID=5, FirstName="Jacob", LastName="bentley", Age=38, Email="jbentley@test.com", Phone="5560987654", IsActive=true, Hobbies="music, baseball, running"
                },
            };

            context.Addresses.AddRange(AddressList);
            context.Users.AddRange(UserList);
            context.SaveChanges();
        }
    }
}