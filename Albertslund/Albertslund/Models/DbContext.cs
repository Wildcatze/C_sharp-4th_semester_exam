using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;




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
                MySqlCommand cmd = new MySqlCommand("select * from user_house where house_id = @House_id", conn);
                cmd.Parameters.AddWithValue("@House_id", house_id);

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
                MySqlCommand cmd = new MySqlCommand("select * from user_contact where contact_id = @Contact_id", conn);
                cmd.Parameters.AddWithValue("@Contact_id", contact_id);

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
                MySqlCommand cmd = new MySqlCommand("select * from user_address where address_id = @Address_id", conn);
                cmd.Parameters.AddWithValue("@Address_id", address_id);

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
                MySqlCommand cmd = new MySqlCommand("select * from user where user_id = @User_id", conn);
                cmd.Parameters.AddWithValue("@User_id", user_id);

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
        //for login
        public User GetUserByUsernameAndPassword(string username,string password)
        {
            User user = new User();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user where username=@Username",conn);
                cmd.Parameters.AddWithValue("@Username", username);
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
            if (user.password == password)
            {
                Debug.WriteLine("Operation completed");
                return user;
            }
            return null;
        }
        public bool createDBEntries(String filePath)
        {
            /*bool finished = false;
            var csvTable = new DataTable();
            //test.csv is correct daily.csv is corrupt
            using ( var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead("@"+filePath)), true))
            {
              
                csvTable.Load(csvReader);
            }
            //Debug.WriteLine("ROW " + csvTable.Rows[0][1].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[1][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[2][2].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[2][3].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[3][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[4][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[5][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[6][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[7][0].ToString() + " COLUMN");
            //Debug.WriteLine("ROW " + csvTable.Rows[8][0].ToString() + " COLUMN");
            //READING Object 
            for (int i=0; i<csvTable.Rows.Count;i++)
            {
                string dateTime = csvTable.Rows[i][0].ToString();
                string energyUse = csvTable.Rows[i][2].ToString();
                string waterUse = csvTable.Rows[i][4].ToString();
                using (MySqlConnection conn = GetConnection())
                {
                    //246810
                    //13579
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO readings(`timestamp`,`energy_used`,`water_used`) VALUES(@DATETIME,@ENERGYUSE,@WATERUSE)", conn);
                    cmd.Parameters.AddWithValue("@DATETIME",dateTime);
                    cmd.Parameters.AddWithValue("@ENERGYUSE", energyUse);
                    cmd.Parameters.AddWithValue("@WATERUSE", waterUse);
                    using (var reader = cmd.ExecuteReader())
                    { finished = true; }
                }
            } */
            //return finished;
            return false;
            
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

        public List<CSVData> GetCSVData(int user_id)
        {
            List<CSVData> csvDataArray = new List<CSVData>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                //insted of readding id should be user id 
                MySqlCommand cmd = new MySqlCommand("select * from readings where readings.reading_id = @User_id", conn);
                cmd.Parameters.AddWithValue("@User_id", 1);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        csvDataArray.Add(new CSVData()
                        {
                            reading_id = Convert.ToInt32(reader["reading_id"]),
                            date = reader["timestamp"].ToString().Split(" ")[0],
                            time = reader["timestamp"].ToString().Split(" ")[1],
                            energy = reader["energy_used"].ToString(),
                            water = reader["water_used"].ToString()
                        });
 
                    };
                }
                conn.Close();
            }
            return csvDataArray;
        }

    }
}
