using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public List<UserHouse> GetAllAlbums()
        {
            List<UserHouse> list = new List<UserHouse>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user_house", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserHouse()
                        {
                            house_id = Convert.ToInt32(reader["house_id"]),
                            house_type = reader["house_type"].ToString(),
                            house_area = reader["house_area"].ToString(),
                            heating_system = reader["heating_system"].ToString()
                        });
                    }
                }
            }
            return list;
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

    }
}
