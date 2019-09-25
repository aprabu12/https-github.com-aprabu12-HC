using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HCServices.Context;
using HCServices.Models;
using log4net;

namespace HCServices.Controllers
{
    public class UsersController : ApiController
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Creating a method to return Json data  
        /// <summary>   Gets the Users. </summary>  
        ///  
        /// <remarks> List of all Users with their address</remarks>  
        ///  
        /// <returns>   The Users. </returns>  
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var dbContext = new DatabaseContext())
            {
                try
                {
                    //Prepare data to be returned using Linq as follows
                    var userList = (from user in dbContext.Users
                                    select user).ToList();

                    if (userList == null)
                    {
                        return NotFound();
                    }
                    List<User> resultList = new List<User>();
                    foreach (var user in userList)
                    {
                        var addrDb = (from address in dbContext.Addresses
                                      where address.AddressID == user.AddressID
                                      select address).FirstOrDefault();

                        var usr = new User()
                        {
                            UserID = user.UserID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Age = user.Age,
                            Phone = user.Phone,
                            Email = user.Email,
                            Hobbies = user.Hobbies,
                            IsActive = user.IsActive,
                            AddressID = user.AddressID,
                        };
                        if (addrDb != null)
                        {
                            var addr = new Address()
                            {
                                Address1 = addrDb.Address1,
                                Address2 = addrDb.Address2,
                                City = addrDb.City,
                                State = addrDb.State,
                                Zip = addrDb.Zip,
                                Country = addrDb.Country
                            };
                            usr.Address = addr;
                        }
                        resultList.Add(usr);
                    }
                    
                    return Ok(resultList);
                }
                catch (Exception ex)
                {                     
                    logger.Error(ex.Message);
                    //If any exception occurs Internal Server Error, status Code 500 will be returned 
                    return InternalServerError(ex);
                }
            }
        }

        /// <summary>   Saves the User. </summary>  
        ///  
        /// <remarks> Saves the user with their address</remarks>  
        ///  
        /// <returns>   HttpActionResult </returns>  
        [HttpPost]
        public IHttpActionResult Post([FromBody] User usr)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var db = new DatabaseContext())
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                }

                return CreatedAtRoute("DefaultApi", new { id = usr.UserID }, usr);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                //If any exception occurs Internal Server Error, status Code 500 will be returned  
                return InternalServerError(ex);
            }
        }
    }
}
