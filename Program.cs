using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleArray2D
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare and initialize variables; Declare arrays
            String sResp = String.Empty;
            Double dSum = 0.0;
            Double dAvg = 0.0;
            Double[,] dGrades;
            //Int32 iStudentId = 0;
            Int32 iStudentCount = 0;
            Int32 iGradeCount = 0;

            //Determine the number of students and store it
            Console.Write("\nHow many students are in the class? ");
            sResp = Console.ReadLine();
            try
            {
                iStudentCount = Int32.Parse(sResp);
            }
            catch (Exception ex)
            {
                Pause("Error: " + ex.Message + "Program will close.");
                return;
            }

            //Determine the number of grades per student & store it
            Console.Write("\nHow many grades are being averaged? ");
            sResp = Console.ReadLine();
            try
            {
                iGradeCount = Int32.Parse(sResp);
            }
            catch (Exception ex)
            {
                Pause("Error: " + ex.Message + "Program will close.");
                return;
            }

            //Instantiate the array
            dGrades = new Double[iStudentCount, iGradeCount + 2];

            //For each row
            for (Int32 j = 0; j < iStudentCount; j++)
            {
                //Enter Student ID in the first element in the row
                Console.Write("Enter the Student ID: ");
                sResp = Console.ReadLine();

                sResp += ".0";

                try
                {
                    dGrades[j, 0] = Double.Parse(sResp);
                }
                catch (Exception ex)
                {
                    Pause(ex.Message + "\nProgram will close.");
                    return;
                }

                //For each element after the first, enter grades
                for (Int32 i = 1; i <= iGradeCount; i++)
                {
                    Console.Write("Enter grade #" + i.ToString() + ": ");
                    sResp = Console.ReadLine();
                    try
                    {
                        dGrades[j, i] = Double.Parse(sResp);
                    }
                    catch (Exception ex)
                    {
                        Pause(ex.Message + "\nProgram will close.");
                        return;
                    }
                    dSum += dGrades[j, i];
                }
                dAvg = dSum / (Double)iGradeCount;
                dSum = 0;

                //In last element on the row, insert the average grade
                dGrades[j, iGradeCount + 1] = dAvg;
            }

            //Output column headings
            Console.Write("Stdt Id");
            for (Int32 j = 1; j <= iGradeCount; j++)
            {
                Console.Write("\tGrade " + j.ToString());
            }

            Console.WriteLine("\tAverage");

            //Traverse the array, output the values
            for (Int32 j = 0; j < iStudentCount; j++)
            {
                Console.Write(Convert.ToInt32(dGrades[j, 0]).ToString());

                for (Int32 i = 1; i <= iGradeCount; i++)
                {
                    Console.Write("\t" + (dGrades[j, i]).ToString());
                }

                Console.WriteLine("\t" + (dGrades[j, iGradeCount + 1]).ToString());
            }

            Pause("And that's the way the cookie crumbles!\nPress <enter> to close.");
        }

        static void Pause(String s)
        {
            Console.WriteLine("\n" + s);
            Console.WriteLine("Press <enter> to continue.");
            Console.ReadLine();
        }
    }
}
