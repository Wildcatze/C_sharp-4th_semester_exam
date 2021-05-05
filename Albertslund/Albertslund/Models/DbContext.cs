using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Models
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //get user house information based on house id
        public UserHouse GetUserHouse(int house_id)
        {
            UserHouse userHouse = new UserHouse();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user_house where house_id = 1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userHouse.house_id = Convert.ToInt32(reader["house_id"]);
                        userHouse.house_type = reader["house_type"].ToString();
                        userHouse.house_area = reader["house_area"].ToString();
                        userHouse.heating_system = reader["heating_system"].ToString();
                    };
                }
            }
            return userHouse;
        }

        public bool UpdateHouse(UserHouse userHouse)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();


                MySqlCommand cmd = new MySqlCommand("UPDATE user_house SET house_type=@HouseType, house_area=@HouseArea, heating_system=@Heating WHERE house_id=@House_id", conn);
                cmd.Parameters.AddWithValue("@HouseType", userHouse.house_type);
                cmd.Parameters.AddWithValue("@HouseArea", userHouse.house_area);
                cmd.Parameters.AddWithValue("@Heating", userHouse.heating_system);
                cmd.Parameters.AddWithValue("@House_id", userHouse.house_id);
                using (var reader = cmd.ExecuteReader())
                { }

                UserHouse updatedHouse = GetUserHouse(userHouse.house_id);

                if (!string.Equals(updatedHouse.house_type, userHouse.house_type) || !string.Equals(updatedHouse.house_area, userHouse.house_area) || !string.Equals(updatedHouse.heating_system, userHouse.heating_system))
                {

                    return false;
                }
                return true;
            }

        }

        //get user contact information based on contact id
        public UserContact GetUserContact(int contact_id)
        {
            UserContact userContact = new UserContact();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user_contact where contact_id = 1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userContact.contact_id = Convert.ToInt32(reader["contact_id"]);
                        userContact.email = reader["email"].ToString();
                        userContact.phone = reader["phone"].ToString();
                        userContact.social_media = reader["social_media"].ToString();
                    };
                }
            }
            return userContact;
        }

        public bool UpdateContact(UserContact userContact)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();


                MySqlCommand cmd = new MySqlCommand("UPDATE user_contact SET email=@Email, phone=@Phone, social_media=@Social WHERE contact_id=@Contact_id", conn);
                cmd.Parameters.AddWithValue("@Email", userContact.email);
                cmd.Parameters.AddWithValue("@Phone", userContact.phone);
                cmd.Parameters.AddWithValue("@Social", userContact.social_media);
                cmd.Parameters.AddWithValue("@Contact_id", userContact.contact_id);
                using (var reader = cmd.ExecuteReader())
                { }

                UserContact updatedContact = GetUserContact(userContact.contact_id);

                if (!string.Equals(updatedContact.email, userContact.email) || !string.Equals(updatedContact.phone, userContact.phone) || !string.Equals(updatedContact.social_media, userContact.social_media))
                {

                    return false;
                }
                return true;
            }

        }


        //get user address information based on address id
        public UserAddress GetUserAddress(int address_id)
        {
            UserAddress userAddress = new UserAddress();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user_address where address_id = 1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userAddress.address_id = Convert.ToInt32(reader["address_id"]);
                        userAddress.street_name = reader["street_name"].ToString();
                        userAddress.street_no = Convert.ToInt32(reader["street_no"]);
                        userAddress.ZIP = Convert.ToInt32(reader["ZIP"]);
                        userAddress.region = reader["region"].ToString();
                    };
                }
            }
            return userAddress;
        }

        //get user  information based on user id
        public User GetUser(int user_id)
        {
            User user = new User();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user where user_id = 1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.user_id = Convert.ToInt32(reader["user_id"]);
                        user.first_name = reader["first_name"].ToString();
                        user.second_name = reader["second_name"].ToString();
                        user.username = reader["username"].ToString();
                        user.password = reader["password"].ToString();
                        user.reading_id = Convert.ToInt32(reader["reading_id"]);
                        user.contact_id = Convert.ToInt32(reader["contact_id"]);
                        user.address_id = Convert.ToInt32(reader["address_id"]);
                        user.house_id = Convert.ToInt32(reader["house_id"]);
                    };
                }
            }
            return user;
        }

        public bool UpdateUser(int user_id, string password)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
    
     
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET password=@Password WHERE user_id=@User_id", conn);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@User_id", user_id);
                using (var reader = cmd.ExecuteReader())
                { }

                User updatedUser = GetUser(user_id);
                
                if (!string.Equals(updatedUser.password, password))
                {
 
                    return false;
                }
                return true;
            }
            
        }

    }
}
