using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Gamming_Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {

            Controller c = new Controller();
            Game cr = new Game("cricket", 2000, true);
            c.addGame(cr);

            c.addSlot(new Slot("Ali",cr,4));
            Admin a = new Admin("adas","adasd","adasd",43243243);
            

            c.createSlotData();
            c.createAdminData();
            c.createGameData();
            c.fetchGameData();
            c.fetchSlotData();
            c.fetchAdminData();
            

        }
    }

   

        public class Controller
        {
            private  List<Game> game_list = new List<Game>();
            private  List<Slot> slot_list = new List<Slot>();
            private  List<Admin> admin_list = new List<Admin>();
            private  List<Customer> customer_list = new List<Customer>();
            private  List<string> password_list = new List<string>();
            private  List<string> id_list = new List<string>();
            private  List<string> all_admins_list = new List<string>();
            private  List<string> all_slots_list = new List<string>();
            private List<string> all_games_list = new List<string>();
            private string io_address = @"C:\Users\Asfar\Documents\Dynamic Gaming - IO Files\";
            
           public string getIOAddress()    
        {
            return this.io_address;
        }

        public void setIOAddress(string address)
        {
            address= this.io_address;
        }
            

        //game objects control
        public void addGame(Game g)
            {
                game_list.Add(g);
            }

            public void removGame(Game g)
            {
                game_list.Remove(g);
            }


            public List<Game> getGameList()
            {
                return game_list;
            }


        public void createGameData()
        {
            string file = io_address + "Games\\";
            Directory.CreateDirectory(file);
            StreamWriter sw = new StreamWriter(file + "Games.txt");

            try {
               
                 if (game_list.Count == 0)
                    {
                        throw new Exception("The Game list is emplty. No new game added.");
                    }
                 else
                    {


                        foreach (Game x in game_list)
                        {
                            sw.WriteLine(x);
                        }
                    }

                   }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArithmeticException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sw.Close();
                    }
        }
        


        public void fetchGameData()
        {

            try
            {

                string file = io_address + "Games\\";
                all_games_list = File.ReadAllLines(file + "Games.txt").ToList<string>();
                

            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (all_games_list.Count != 0)
                {
                    foreach (var x in all_games_list)
                    {
                        Console.WriteLine(x);
                    }
                }
            }

        }



        //slot objects control
        public void addSlot(Slot s)
            {
                slot_list.Add(s);
            }

            public  List<Slot> getSlotList()
            {
                return slot_list;

            }

            public void removeSlot(Slot s)
            {
                slot_list.Remove(s);
            }


        public void createSlotData()
        {
            string file = io_address + "Slots\\";
            Directory.CreateDirectory(file);
            StreamWriter sw = new StreamWriter(file + "Slots.txt");
            try
            {
               
                foreach (Slot x in slot_list)
                {
                    sw.WriteLine(x);
                }

            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }


        public void fetchSlotData()
        {
            try
            {
                string file = io_address + "Slots\\";
                all_slots_list = File.ReadAllLines(file + "Slots.txt").ToList<string>();
                
             
            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (all_slots_list.Count!= 0)
                {
                    foreach (var x in all_slots_list)
                    {
                        Console.WriteLine(x);
                    }
                }
            }

        }



        //admin object control

        public void addAdmin(Admin _admin)
            {
                admin_list.Add(_admin);

            }

            public void removeAdmin(Admin _admin)
            {

            }

            public  List<Admin> getAdminList()
            {
                return admin_list;

            }


        public  void createAdminData()
        {
            string file = io_address + "Admin\\";
            Directory.CreateDirectory(file);

            StreamWriter sa = new StreamWriter(file + "All Data.txt");
            StreamWriter si = new StreamWriter(file + "Ids.txt");
            StreamWriter sp = new StreamWriter(file + "Passwords.txt");
            try
            {
                if (admin_list.Count != 0)
                {

                    foreach (Admin x in getAdminList())
                    {
                        sa.WriteLine(x);
                        si.WriteLine(x.getId());
                        sp.WriteLine(x.getPassword());
                    }


                }
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("File address is invalid!");
            }
            
            catch (InvalidDataException ex)
            {
                Console.WriteLine("Data is not valid");
            }

            catch (PathTooLongException ex)
            {
                Console.WriteLine("Path is too long");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception occurs");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception occurs: " + ex);

            }
            finally
            {
                sa.Close();
                sp.Close();
                si.Close();

            }
        }   









            public void fetchAdminData()
            {
            try
            {
                string file = io_address + "Admin\\";
                 all_admins_list = password_list = File.ReadAllLines(file + "All Data.txt").ToList<string>();
                 id_list = File.ReadAllLines(file+"Ids.txt").ToList<string>();
                 password_list = File.ReadAllLines(file+ "Passwords.txt").ToList<string>();
               

                foreach (var x in id_list)
                {
                    Console.WriteLine(x);
                }
                foreach (var x in password_list)
                {
                    Console.WriteLine(x);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally 
            {
            }

            }




            public  List<string> getIdList()
            {
                return id_list;
            }

            public  List<string> getPasswordList()
            {
                return password_list;
            }



            //customer object controll


            public void addCustomer(Customer _customer)
            {
                customer_list.Add(_customer);

            }

            public void removeCustomer(Admin _admin)
            {

            }

            public List<Customer> getCustomerList()
            {
                return customer_list;

            }
        }





        public class Slot
        {
            private string customer_name;
            private Game game;
            private double hours;
            private string slot_id;
            DateTime dateAndTime = DateTime.Now;
            public Random a = new Random();
            public List<string> randomList = new List<string>();

            public Slot(string _customer_name, Game _game, double _hours)
            {

                this.slot_id = createID();
                this.customer_name = _customer_name;
                this.game = _game;
                this.hours = _hours;
                
            }

            //Constructor to create slots for customers have an account
            public Slot(string _id, double _hours)
            {
                try
                {
                    Controller c = new Controller();
                    List<Customer> ar = c.getCustomerList();

                    foreach (Customer x in ar)
                    {
                        if (_id == x.getId())
                        {
                            x.setHours(_hours);
                        }
                        else
                        { Console.WriteLine($"The input ID:{_id} is incorrect"); }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        

            private string createID()
            {
                this.slot_id = Convert.ToString("slot" + a.Next(0, 3));
                while (randomList.Contains(slot_id))
                {
                    this.slot_id = Convert.ToString("slot" + a.Next(0, 3));
                }
                return this.slot_id;
            }


            public string getCustomerName()
            {
                return this.customer_name;
            }

            public void setCustomerName(string _customer_name)
            {
                this.customer_name = _customer_name;
            }

            public string getSlotId()
            {
                return this.slot_id;
            }

            public void setSlotId(string _slot_id)
            {
                this.slot_id = _slot_id;
            }

            public Game getGame()
            {
                return this.game;
            }

            public void setGame(Game _game)
            {
                this.game = _game;
            }

            public double getHours()
            {
                return this.hours;
            }

            public void setHours(double _hours)
            {
                this.hours = _hours;
            }



            override
            public string ToString()
            {
                return "Date: " + this.dateAndTime.ToShortDateString() + " |  Customer name: " + this.customer_name + " |  Game selected: " + this.game + " |  Time: " + this.hours + "hrs\n";
            }

        }




        public class Admin
        {


            private string name;
            private string email;
            private string password;
            private double mobile_number;
            private string id;
            public Random a = new Random();






            public Admin(string _name, string _email, string _password, double mobile_number)
            {
                this.name = _name;
                this.email = _email;
                this.password = _password;
                this.mobile_number = mobile_number;
                // creating id number
                createAdminId();
            }





            public void setPassword(string old_password, string new_password)
            {
                try
                {
                    if (this.getPassword().Equals(old_password))
                    {
                        this.password = new_password;
                    }
                    else if (old_password != this.getPassword())
                    {
                        Console.WriteLine("Old password you entered is wrong");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }



            public string getName()
            {
                return this.name;
            }

            void setName(string n)
            {
                n = this.name;
            }




            public string getEmail()
            {
                return this.email;
            }

            void setEmail(string un)
            {
                un = this.email;
            }




            public string getPassword()
            {
                return this.password;
            }

            void setPassword(string p)
            {
                p = this.password;
            }




            public double getMobileNumber()
            {
                return this.mobile_number;
            }

            void setMobileNumber(double mn)
            {
                mn = this.mobile_number;
            }





            public void setId(string _id)
            {
                this.id = _id;

            }
            public string getId()
            {
                return this.id;
            }


            private string createAdminId()
            {
            Controller c = new Controller();

                this.id = Convert.ToString("Adm" + a.Next(100, 999));
                while (c.getIdList().Contains(this.id))
                {
                    this.id = Convert.ToString("Adm" + a.Next(0, 999));
                }
                c.getIdList().Add(this.id);
                return this.id;

            }





            override
                 public string ToString()
            {
                return "ID: " + this.getId() + " |   Username: " + this.getEmail() + "|   Name: " + this.getName() + "|   Mobile Number: " + this.getMobileNumber();

            }
        }




        //customers will have access to all games
        public class Customer
        {
            double hours;
            string name;
            string id;
            double mobile_number;
            int i = 000;

            public Customer(string _name, double _mobile_number, double _hours)
            {
                _name = this.name;
                _mobile_number = this.mobile_number;
                _hours = this.hours;

                //creating id
                this.id = "Adm" + Convert.ToString(i);
                i++;

            }


            void setId(string _id)
            {
                this.id = _id;

            }
            public string getId()
            {
                return this.id;
            }

            public string getName()
            {
                return this.name;
            }

            void setName(string n)
            {
                n = this.name;
            }


            public double getMobileNumber()
            {
                return this.mobile_number;
            }

            void setMobileNumber(double mn)
            {
                mn = this.mobile_number;
            }


            public void setHours(double _hours)
            {
                this.hours += _hours;
            }

            override
            public string ToString()
            {
                return "ID: " + this.id + " Name: " + this.name + " Mobile Number: " + this.mobile_number + " Hours: " + this.hours;
            }
        }




        public class Game
        {

            private string game_name;
            private double release_year;
            private bool is_multiplayer;


            public Game(string _game_name, double _relese_year, bool _is_multiplayer)
            {
                this.game_name = _game_name;
                this.release_year = _relese_year;
                this.is_multiplayer = _is_multiplayer;

            }

            public string getName()
            {
                return this.game_name;
            }

            public void setName(string n)
            {
                n = this.game_name;
            }


            override
            public string ToString()
            {
                return "Name: " + this.game_name + " | Release year: " + this.release_year + " | Multiplayer: " + this.is_multiplayer;
            }


        }

        public class Sports : Game
        {
            public Sports(string game_name, double _relese_year, bool _is_multiplayer) : base(game_name, _relese_year, _is_multiplayer)
            {

            }

        }

        public class Action : Game
        {
            public Action(string game_name, double _relese_year, bool _is_multiplayer) : base(game_name, _relese_year, _is_multiplayer)
            {

            }

        }

        public class Adventure : Game
        {
            public Adventure(string game_name, double _relese_year, bool _is_multiplayer) : base(game_name, _relese_year, _is_multiplayer)
            {

            }

        }

        public class Simulation : Game
        {
            public Simulation(string game_name, double _relese_year, bool _is_multiplayer) : base(game_name, _relese_year, _is_multiplayer)
            {

            }
        }

        public class Strategy : Game
        {
            public Strategy(string game_name, double _relese_year, bool _is_multiplayer) : base(game_name, _relese_year, _is_multiplayer)
            {

            }

        }



    }














