using System;

namespace test_task_lucky_ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string user_entered_ticket = "";

            Console.WriteLine("Welcome to the Lucky Ticket Program!");
            Console.WriteLine("Enter a number from 4 to 8 digits long and find out if it is lucky.");
            Console.WriteLine("To quit enter 'q'\n");

            do
            {

                Console.Write("Your number = ");
                user_entered_ticket = Console.ReadLine();

                if (check_input(user_entered_ticket) && check_ticket_digits(user_entered_ticket))
                {
                    correct_odd_ticket(ref user_entered_ticket);

                    if (check_luck(user_entered_ticket))
                    {
                        Console.WriteLine("Your ticket is lucky!\n");
                    }
                    else
                    {
                        Console.WriteLine("Your ticket is not lucky.\n");
                    }


                }
                else
                {
                    if (user_entered_ticket != "q") Console.WriteLine("Wrong input! Try again.\n");
                }

            } while (user_entered_ticket != "q");




        }
        public static bool check_input(string ticket)
        {
            int res;
            return Int32.TryParse(ticket, out res);
        }
        public static bool check_ticket_digits(string ticket)
        {
            if (ticket.Length >= 4 && ticket.Length <= 8 && ticket[0] != '-') return true;
            return false;
        }
        public static void correct_odd_ticket(ref string ticket)
        {
            if (ticket.Length % 2 != 0) ticket = "0" + ticket;
        }
        public static bool check_luck(string ticket)
        {
            int half_index = ticket.Length / 2;
            int half1 = 0, half2 = 0;
            for (int i = 0; i < half_index; i++)
            {
                half1 += int.Parse(ticket[i].ToString());
                half2 += int.Parse(ticket[i + half_index].ToString());
            }

            if (half1 == half2) return true;
            return false;
        }
    }
}
