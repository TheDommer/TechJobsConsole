using System;
using System.Collections.Generic;

namespace TechJobsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Dictionary vars to hold info for menu and data

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>(); //declairs dictionary 'actionChoices' with two strings
            actionChoices.Add("search", "Search"); //adds 'actionChoices' dictionary entry for 'search'
            actionChoices.Add("list", "List"); //adds 'actionChoices' dictionary enty for 'list'

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>(); //declairs dictionary for 'columnChoices' with two strings 
            columnChoices.Add("core competency", "Skill"); // adds 'columnChoices' dictionary entry for '...
            columnChoices.Add("employer", "Employer"); // adds 'columnChoices'  dictionary entry for '...
            columnChoices.Add("location", "Location"); // adds 'columnChoices' dictionary entry for '...
            columnChoices.Add("position type", "Position Type"); // adds 'columnChoices' dictionary entry for '...
            columnChoices.Add("all", "All"); // adds 'columnChoices' dictionary for '...


            Console.WriteLine("Welcome to LaunchCode's TechJobs App!"); //writes line "Welcome to LaunchCode's TechJobs App!"

            // Allow user to search/list until they manually quit with ctrl+c
            while (true)
            {
                // GetUserSelection displays a menu of choices and returns the user's selection.
                string actionChoice = GetUserSelection("View Jobs", actionChoices); //sets 'actionChoice' to 'Getuserselection' and ?views jobs via action choices?  

                if (actionChoice.Equals("list")) // conditional for if the action chosen if 'list' 
                {
                    string columnChoice = GetUserSelection("List", columnChoices); //sets 'columnChoice to 'GetUserSelection' ???"List", columnChoices???

                    if (columnChoice.Equals("all")) //lists item 'all' at end of other columnChoices 
                    {
                        PrintJobs(JobData.FindAll()); //prints all jobs if 'all' is chosen 
                    }
                    else //if line 38 condition not met 
                    {
                        List<string> results = JobData.FindAll(columnChoice); //creates string list of the results for 'jobdata.findall' via the choice column 

                        Console.WriteLine("\n*** All " + columnChoices[columnChoice] + " Values ***"); //writes the column choice from list of columns? 
                        foreach (string item in results) //iterates through each item in results and...
                        {
                            Console.WriteLine(item); //...writes item 
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine("\nSearch term: "); 
                    string searchTerm = Console.ReadLine(); 

                    List<Dictionary<string, string>> searchResults; //sets a list of dictionaries ....

                    // Fetch results
                    if (columnChoice.Equals("all")) 
                    {
                        searchResults = JobData.FindByValue(searchTerm);
                        PrintJobs(searchResults); 
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm); //sets 'searchResults' to search for 'columnChoice' and 'searchTerm' 
                        PrintJobs(searchResults);  //prints 'searchResults 
                    }
                }
            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        private static string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        {
            int choiceIdx; // declairs 'choiceIdx' variable as an integer 
            bool isValidChoice = false; //sets the 'isValdiChoice' variable to false
            string[] choiceKeys = new string[choices.Count]; //creates a list of strings ??choices and count???

            int i = 0;
            foreach (KeyValuePair<string, string> choice in choices)
            {
                choiceKeys[i] = choice.Key;
                i++;
            }
            do
            {
                Console.WriteLine("\n" + choiceHeader + " by:");

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]);
                }

                string input = Console.ReadLine();
                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        {
            if (someJobs.Count == 0)
            {
                Console.WriteLine("Sorry! There are no jobs matching that search term.  Please try again.");
            }

            foreach (Dictionary<string, string> job in someJobs)
            {
                Console.WriteLine("\n*********");
                        { 
                foreach (string value in job.Values) {

                    Console.WriteLine(value);

                }
                    Console.WriteLine("*********\n");
                }
        }
    }
            //looks through and print info
            //double check demo app, print writeline 
            ///Console.WriteLine("printJobs is not implemented yet");
        }
    }
