using System;

namespace FinalProject
{
    class Program
    {
        // declare a structure
        struct student
        {
            public string stdNumb;
            public string stdNam;
            public string stdGen;
            public float stats;
            public float ise;
            public float dlc;
            public float webProg;
            public float comProg;
            public float total;
        };

        //main method.
        static void Main(string[] args)
        {
            //declaring array with 20 maximum components
            const int Max = 20;
            try
            {
                student[] st = new student[Max]; //array
                int itemcount = 0;
                int choice;
                string confirm;

                do
                {
                    //main menu
                    dispMenu(); //call the display menu method
                    Console.WriteLine("Enter your choice(1-5)");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1: addStd(st, ref itemcount); break; //if the user choose no 1, it will call and run the addstu method
                        case 2: delStu(st, ref itemcount); break; //if the user choose no 2, it will call and run the delstu method
                        case 3: updStu(st, itemcount); break; //if the user choose no 3, it will call and run the updstu method
                        case 4: viewAll(st, itemcount); break; //if the user choose no 4, it will call and run the viewall method
                        case 5: findStd(st, itemcount); break; //if the user choose no 5, it will call and run the findstd method
                        default: Console.WriteLine("Invalid"); break; //error info
                    }
                    Console.Write("Press y or Y to continue:");
                    confirm = Console.ReadLine().ToString();
                    Console.Clear();
                } while (confirm == "y" || confirm == "Y");
            } 
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
            } 
        }

        // display menu method.
        static void dispMenu()
        {
            // just a simple menu.
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++\n                         MENU                         \n++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(" 1.Add student data");
            Console.WriteLine(" 2.Delete student data");
            Console.WriteLine(" 3.Update student data");
            Console.WriteLine(" 4.View all student data");
            Console.WriteLine(" 5.Find a student by ID");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
        }

        //adding information/student data method.
        static void addStd(student[] st, ref int itemcount)
        {
        Here: //label
            Console.WriteLine("======================================================\n            ADDING STUDENTS DATA/INFORMATION                         \n======================================================");
            Console.Write("Enter student's ID:");
            st[itemcount].stdNumb = Console.ReadLine().ToString();
            //cheking if the student data already registered or not
            if (search(st, st[itemcount].stdNumb, itemcount) != -1) //call search method, to search for id number.
            {
                Console.Clear();
                Console.WriteLine("The ID Number you Enter already exists.");
                goto Here; // if the number already exists, it will go back to input.

            }
            // all the inputed data will be an array and stored in the structure
            Console.Write("Enter student's Name:");
            st[itemcount].stdNam = Console.ReadLine().ToString();
            Console.Write("Enter student's Gender (F or M):");
            st[itemcount].stdGen = Console.ReadLine().ToString();
            Console.Write("Enter student's Statistics Grade:");
            st[itemcount].stats = float.Parse(Console.ReadLine());
            Console.Write("Enter student's Integrative Survival Experience Grade:");
            st[itemcount].ise = float.Parse(Console.ReadLine());
            Console.Write("Enter student's Digital Literacy and Communication Grade:");
            st[itemcount].dlc = float.Parse(Console.ReadLine());
            Console.Write("Enter student's  Web Programming Grade:");
            st[itemcount].webProg = float.Parse(Console.ReadLine());
            Console.Write("Enter student's Computing Career and Programming Grade:");
            st[itemcount].comProg = float.Parse(Console.ReadLine());
            st[itemcount].total = st[itemcount].stats + st[itemcount].ise + st[itemcount].dlc + st[itemcount].webProg + st[itemcount].comProg; //totaling the grades
            ++itemcount;

        }

        //deleting information/student data method.
        static void delStu(student[] st, ref int itemcount)
        {
            string id;
            int idx;
            if (itemcount > 0)
            {
                Console.WriteLine("======================================================\n         DELETING STUDENTS DATA/INFORMATION                         \n======================================================");
                Console.Write("Enter student's ID:");
                id = Console.ReadLine();
                idx = search(st, id.ToString(), itemcount);

                if ((idx != -1) && (itemcount != 0))
                {
                    if (idx == (itemcount - 1))
                    {
                        cleanData(st, idx); // calling cleanData method to delete the data that have been choose.
                        --itemcount;

                        Console.WriteLine("The Data is Successfully Deleted.");
                    }
                    else
                    {
                        for (int i = idx; i < itemcount - 1; i++)
                        {
                            st[i] = st[i + 1];
                            cleanData(st, itemcount);
                            --itemcount;
                        }
                    }
                }
                else Console.WriteLine("The data doesn't exist. please re check the ID and try again.");
            }
            else Console.WriteLine("No data to delete");
        }

        //method for updating students information or data.
        static void updStu(student[] st, int itemcount)
        {
            string id;
            int column_idx;
            Console.WriteLine("======================================================\n           UPDATE STUDENTS DATA/INFORMATION                         \n======================================================");
            Console.Write("Enter student's ID:");
            id = Console.ReadLine();
            Console.WriteLine("Which field you want to update(1-7)?:");
            Console.WriteLine("1: Student's Name");
            Console.WriteLine("2: Student's Gender");
            Console.WriteLine("3: Student's Statistics Grade");
            Console.WriteLine("4: Student's Integrative Survival Experience Grade");
            Console.WriteLine("5: Student's Digital Literacy and Communication");
            Console.WriteLine("6: Student's Web Programming Grade");
            Console.WriteLine("7: Student's Computing Career and Programming Grade");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            column_idx = Convert.ToInt32(Console.ReadLine());
            int idx = search(st, id.ToString(), itemcount); // call search method
            if ((idx != -1) && (itemcount != 0))
            {
                if (column_idx == 1)
                {
                    Console.Write("Enter student's Name:");
                    st[idx].stdNam = Console.ReadLine().ToString();
                }
                else if (column_idx == 2)
                {
                    Console.Write("Enter student's Gender (F or M):");
                    st[idx].stdGen = Console.ReadLine().ToString();
                }
                else if (column_idx == 3)
                {
                    Console.Write("Enter student's Statistics Grade:");
                    st[idx].stats = float.Parse(Console.ReadLine());
                }
                else if (column_idx == 4)
                {
                    Console.Write("Enter student's Integrative Survival Experience Grade:");
                    st[idx].ise = float.Parse(Console.ReadLine());
                }
                else if (column_idx == 5)
                {
                    Console.Write("Enter student's Digital Literacy and Communication Grade:");
                    st[idx].dlc = float.Parse(Console.ReadLine());
                }
                else if (column_idx == 6)
                {
                    Console.Write("Enter student's  Web Programming Grade:");
                    st[idx].webProg = float.Parse(Console.ReadLine());
                }
                else if (column_idx == 7)
                {
                    Console.Write("Enter student's Computing Career and Programming Grade:");
                    st[idx].comProg = float.Parse(Console.ReadLine());
                }
                else Console.WriteLine("Invalid column index");
                st[idx].total = st[idx].stats + st[idx].ise + st[idx].dlc + st[idx].webProg + st[idx].comProg;
            }
            else Console.WriteLine("The data doesn't exist. please re check the ID and try again.");
        } 

        //method for view the students information/data that have been input by user.
        static void viewAll(student[] st, int itemcount)
        {
            int i = 0;
            Console.WriteLine("====================================================================================================================\n                                                STUDENTS DATA/INFORMATION          \n====================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("{0,-5}\t{1,-19}{2,-15}{3,-8}{4,-8}{5,-8}{6,-11}{7,-12}{8,-10}(column index)", "0", "1", "2", "3", "4", "5", "6", "7", "8"); //layouting
            Console.WriteLine("____________________________________________________________________________________________________________________"); //layouting
            Console.WriteLine("{0,-5}\t{1,-11}\t{2,-8}\t{3,-10}{4,-8}{5,-5}\t{6,-7}\t{7,-2}\t{8,-4}", "ID", "NAME", "GENDER", "STATS", "ISE", "DLC", "WEBPROG", "COMPPROG", "AVG"); //layouting
            Console.WriteLine("====================================================================================================================");
            while (i < itemcount){
                if (st[i].stdNumb != null)
                {
                    Console.Write("{0,-5}\t{1,-18}{2,-15}", st[i].stdNumb, st[i].stdNam, st[i].stdGen); //layout
                    Console.Write("{0,-9}{1,-9}{2,-8}", st[i].stats, st[i].ise, st[i].dlc);
                    Console.Write("{0,-9}{1,-13}{2,-10}", st[i].webProg, st[i].comProg, st[i].total / 5); // layout + grades average.
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------\n");
                }
                i = i + 1;
            }
        }

        //method for finding students by their id.
        static void findStd(student[] st, int itemcount)
        {
            Console.WriteLine("======================================================\n                     SEARCH STUDENTS                         \n======================================================");
            string id;
            Console.Write("Enter student's ID:");
            id = Console.ReadLine();

            int idx = search(st, id.ToString(), itemcount); //calling search method to find the data by id that user inputed.
            if (idx != -1)
            {
                Console.Write("{0,-5}\t{1,-20}{2,-5}", st[idx].stdNumb, st[idx].stdNam, st[idx].stdGen);
                Console.Write("{0,-5}{1,-5}{2,-5}", st[idx].stats, st[idx].ise, st[idx].dlc);
                Console.Write("{0,-5}{1,-5}{2,-5}", st[idx].webProg, st[idx].comProg, st[idx].total / 5);
                Console.WriteLine();

            }
            else Console.WriteLine("The data doesn't exits.");
        
        }

        //this method is to clean the deleted data.
        static void cleanData(student[] st, int idx)
        {
            st[idx].stdNumb = null;
            st[idx].stdNam = null;
            st[idx].stdGen = null;
            st[idx].stats = 0;
            st[idx].ise = 0;
            st[idx].dlc = 0;
            st[idx].webProg = 0;
            st[idx].comProg = 0;
            st[idx].total = 0;
        }

        //method for search the students data and used in adding, deleting, and finding.
        static int search(student[] st, string id, int itemcount)
        {
            int found = -1;
            for (int i = 0; i < itemcount && found == -1; i++)
            {
                if (st[i].stdNumb == id) found = i;
                else found = -1;
            }
            return found;

        }
    }

}
