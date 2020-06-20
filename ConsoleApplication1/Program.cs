using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
namespace ConsoleApplication1
{
   public class program
    {    
        int iterateCounter = 0;
        int loopCounter = 0;
        int debug = 1;//set to 0 for no debug, for debug 1
        bool logdataactive = true;
        string globalError = string.Empty;
        public int[,] a = new int[9, 9];
        public int[,] b = new int[9, 9];
        bool tracesteps = true;
        List<string> markCellsToSolve = new List<string>(); //contains cells which needs to be filled
        List<string> cellsToSolve = new List<string>(); // get all values which needs to be completed
        List<string> cellsToSolvePrevious = new List<string>();//hold previous values to compare
        List<string> cellsSolved = new List<string>();  //once values assigned, for this list it will be added
        List<string> diagnostic = new List<string>(); //for checking value here it will be added
        int left = 0; int top = 6; int speed = 30000; //cursor position and speed
        Stack s9 = new Stack();
     
        public void printdata()
         {
             
         
           Console.SetCursorPosition(left, top); //print in one place recursively

            /*********************** display *********************/

            Console.WriteLine(" ");
            Console.WriteLine(" ");
             Console.WindowHeight = 50;

            Console.ForegroundColor = ConsoleColor.Green;
            for (int zz = 0; zz <= 18; zz++)   //for empty line
            {
                if (zz == 0)
                    Console.Write(" --");
                else if (zz == 18)
                    Console.Write("-");
                else
                    Console.Write("--");
            }
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
             {
                
                 for (int j = 0; j < 9; j++)
                 {

                     if (a[i, j] == 0)
                     {
                        

                        Console.ForegroundColor = ConsoleColor.Green;
                         Console.Write(" | ");
                         Console.ForegroundColor = ConsoleColor.White;
                         Console.Write(a[i, j]);

                       
                    }
                     else
                     {

                         if (markCellsToSolve.Count > 0)
                         {
                             string temp = i + "," + j;
                             if (markCellsToSolve.Contains(temp))
                             {
                                 Console.ForegroundColor = ConsoleColor.Green;
                                 Console.Write(" | ");
                                 Console.ForegroundColor = ConsoleColor.Yellow;
                                
                                 Console.Write(a[i, j]);
                             //   System.Threading.Thread.Sleep(speed);

                             }
                             else
                             {
                                 Console.ForegroundColor = ConsoleColor.Green;
                               

                                 Console.Write(" | " + a[i, j]);
                             }
                           

                         }
                         else
                         {
                             Console.ForegroundColor = ConsoleColor.Green;

                             Console.Write(" | " + a[i, j]);
                         }
                     }
                   
                   
                 }
                 Console.ForegroundColor = ConsoleColor.Green;
             
                    Console.Write(" |");           //this is for end mark
                 Console.WriteLine(" ");
            
                 for (int zz = 0; zz <= 8; zz++)   //for empty line
                 { Console.Write(" |  "); }

                 Console.WriteLine(" |");  //for new line

                 for (int zz = 0; zz <=18; zz++)   //for empty line
                 {
                    if(zz==0)
                    Console.Write(" --");
                    else if(zz==18)
                        Console.Write("-");
                    else
                        Console.Write("--");
                }

                 Console.WriteLine(" ");  //for new line              
             }
         }

         public void singleblocks()
         {
            block(0,2,0,2); //first block
            block(0, 2, 3, 5);///second block
            block(0,2, 6, 8);//third block
            block(3, 5, 0, 2); //fourth block
            block(3, 5, 3, 5);///fifth block
            block(3, 5, 6, 8);//sixxth block
            block(6, 8, 0, 2); //seventh block
            block(6, 8, 3, 5);///eight block
            block(6, 8, 6, 8);//ninth block
                              ///
         }

         public void horizontals()
         {
             horizontalblock(0, 0, 8);
             horizontalblock(1, 1, 8);
             horizontalblock(2, 2, 8);
             horizontalblock(3, 3, 8);
             horizontalblock(4, 4, 8);
             horizontalblock(5, 5, 8);
             horizontalblock(6, 6, 8);
             horizontalblock(7, 7, 8);
             horizontalblock(8, 8, 8);

         }

         public void verticals()
         {
             block(0,8,0,0);
             block(0,8, 1, 1);
             block(0,8, 2, 2);
             block(0,8, 3, 3);
             block(0,8,4, 4);
             block(0,8, 5, 5);
             block(0,8, 6, 6);
             block(0,8, 7, 7);
             block(0, 8,8, 8);
         }
         
         public void assignvalues(int xaxis, int yaxis, int value) //assign values to individual upon taken
         {
                diagnostic.Add("a[" + xaxis + "," + yaxis + "]=" + value);
                a[xaxis, yaxis] = value;
                string temp = xaxis + "," + yaxis;
                cellsSolved.Add(temp);                        //once value added, add to this list in order to mark that it has been done
         }

         public void horizontalblock(int xstart, int xend, int yend)
         {
             #region
             List<string> emptyblock = new List<string>();
             List<int> cellvalue = new List<int>();
             bool notPresentHorizontally = false;
             bool notPresentVertically = false;
             bool notPresentInBlock = false;

             //get empty blocks
             for (int xindex = xstart; xindex <= xend; xindex++)
             {
                 for (int yindex = 0; yindex <= yend; yindex++)
                 {
                     if (a[xindex, yindex] == 0)
                     {
                         emptyblock.Add(xindex + "," + yindex);          //take only with empty cells

                     }
                     cellvalue.Add(a[xindex, yindex]);                  //take all cell values into list
                 }
             }
             string temp = string.Empty;
             #endregion

             //put values in horizontal block   solve if and only one value is missing
             if (emptyblock.Count == 1)
             {

                 foreach (var i in cellvalue) //get all the value of row
                 {
                     temp = temp + "," + i;
                 }

                 for (int i = 1; i <= 9; i++)   //check wether no. is present or not
                 {
                     if (temp.Contains(i.ToString()))
                     {
                     }
                     else
                     {
                         foreach (var s in emptyblock)                                 //assign that single value
                         {

                             string[] coordinates = s.Split(',');


                             for (int kk1 = 0; kk1 <= 8; kk1++)
                             {
                                 if (a[Convert.ToInt32(coordinates[0]), kk1] == i)
                                 {
                                     notPresentHorizontally = true; break;
                                 }


                             }
                             for (int kk2 = 0; kk2 <= 8; kk2++)
                             {
                                 if (a[kk2, Convert.ToInt32(coordinates[1])] == i)
                                 {
                                     notPresentVertically = true; break;
                                 }
                             }
                            int ystartingaxis = 999, yendingaxis = 999, xstartingaxis = 999, xendingaxis = 999;
                             if ((Convert.ToInt32(coordinates[0]) >= 0 && Convert.ToInt32(coordinates[0]) <= 2) && (Convert.ToInt32(coordinates[1]) >= 0 && Convert.ToInt32(coordinates[1]) <= 2)) //1st block
                             {
                                xstartingaxis = 0; xendingaxis = 2; ystartingaxis = 0; yendingaxis = 2; //continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 0 && Convert.ToInt32(coordinates[0]) <= 2) && (Convert.ToInt32(coordinates[1]) >= 3 && Convert.ToInt32(coordinates[1]) <= 5))//2nd block
                             {
                                xstartingaxis = 0; xendingaxis = 2; ystartingaxis = 3; yendingaxis = 5;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 0 && Convert.ToInt32(coordinates[0]) <= 2) && (Convert.ToInt32(coordinates[1]) >= 6 && Convert.ToInt32(coordinates[1]) <= 8)) //3rd block
                             {
                                xstartingaxis = 0; xendingaxis = 2; ystartingaxis = 6; yendingaxis = 8;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 3 && Convert.ToInt32(coordinates[0]) <= 5) && (Convert.ToInt32(coordinates[1]) >= 0 && Convert.ToInt32(coordinates[1]) <= 2)) //4th block
                             {
                                xstartingaxis = 3; xendingaxis = 5; ystartingaxis = 0; yendingaxis = 2;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 3 && Convert.ToInt32(coordinates[0]) <= 5) && (Convert.ToInt32(coordinates[1]) >= 3 && Convert.ToInt32(coordinates[1]) <= 5)) //5th block
                             {
                                xstartingaxis = 3; xendingaxis = 5; ystartingaxis = 3; yendingaxis = 5; //continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 3 && Convert.ToInt32(coordinates[0]) <= 5) && (Convert.ToInt32(coordinates[1]) >= 6 && Convert.ToInt32(coordinates[1]) <= 8)) //6th block
                             {
                                xstartingaxis = 3; xendingaxis = 5; ystartingaxis = 6; yendingaxis = 8;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 6 && Convert.ToInt32(coordinates[0]) <= 8) && (Convert.ToInt32(coordinates[1]) >= 0 && Convert.ToInt32(coordinates[1]) <= 2)) //7th block
                             {
                                xstartingaxis = 6; xendingaxis = 8; ystartingaxis = 0; yendingaxis = 2;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 6 && Convert.ToInt32(coordinates[0]) <= 8) && (Convert.ToInt32(coordinates[1]) >= 3 && Convert.ToInt32(coordinates[1]) <= 5)) //8th block
                             {

                                xstartingaxis = 6; xendingaxis = 8; ystartingaxis = 3; yendingaxis = 5;// continue;
                             }
                             if ((Convert.ToInt32(coordinates[0]) >= 6 && Convert.ToInt32(coordinates[0]) <= 8) && (Convert.ToInt32(coordinates[1]) >= 6 && Convert.ToInt32(coordinates[1]) <= 8)) //9th block
                             {
                                xstartingaxis = 6; xendingaxis = 8; ystartingaxis = 6; yendingaxis = 8; //continue;

                             }
                             notPresentInBlock = checkblock(xstartingaxis, xendingaxis, ystartingaxis, yendingaxis, i);
                             if (notPresentHorizontally == false && notPresentVertically == false && notPresentInBlock == true)
                             {

                                 assignvalues(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]), i);
                             }
                             else  //add global error in order to find out easily and debug
                            {
                                if(iterateCounter>0)  //only if second or more iterates takes place
                                {
                                    if (notPresentVertically == true) // for given co-ordinates in y axis same value present
                                    {
                                        globalError = globalError + "For a["+ coordinates[0]+","+ coordinates[1]+"] "+i+" present vertically\n";
                                    }
                                    if (notPresentHorizontally == true) // for given co-ordinates in y axis same value present
                                    {
                                        globalError = globalError + "For a[" + coordinates[0] + "," + coordinates[1] + "] " + i + " present horizontally\n";
                                    }
                                }
                            }
                         }
                     }
                 }
             }
         }

         public void block(int xstart, int xend, int ystarting,int yend)
         {
             #region
             //for single indivudual block
           
             List<string> emptyblock = new List<string>();
            List<int> cellvalue = new List<int>();
  
            for (int xindex = xstart; xindex <= xend; xindex++) //get values of block
            {
                for (int yindex = ystarting; yindex <= yend; yindex++)
                {
                    if (a[xindex, yindex] == 0)
                    {
                        emptyblock.Add(xindex+","+yindex);
                        
                    }
                    cellvalue.Add(a[xindex, yindex]);
                }
            }
            
             string temp=string.Empty;
            #endregion
             if (emptyblock.Count == 1)
             {
                
                 foreach (var i in cellvalue)
                 {
                     temp = temp + "," + i;
                 }
                 
                 for (int i = 1; i <= 9; i++)
                 {
                     if (temp.Contains(i.ToString()))
                     {
                     }
                     else
                     {
                         foreach(var s in emptyblock)
                         {
                            bool notPresentHorizontally = false;
                            bool notPresentVertically = false;
                            bool notPresentInBlock = false;
                            string[] coordinates = s.Split(',');
                            int x_coordinate =Convert.ToInt32(coordinates[0]);
                            int y_coordinate =Convert.ToInt32(coordinates[1]);
                            for (int kk1 = 0; kk1 <= 8; kk1++)              //check whether solvenumber is present in that particular row
                            {
                                if (a[x_coordinate, kk1] == i)
                                {
                                    notPresentHorizontally = true; break;
                                }


                            }
                            for (int kk2 = 0; kk2 <= 8; kk2++)            ///check whether solvenumber is present in particular column wise
                            {
                                if (a[kk2, y_coordinate] == i)
                                {
                                    int zz = kk2;
                                    notPresentVertically = true; break;
                                }
                            }
                            if (notPresentHorizontally == false && notPresentVertically == false && notPresentInBlock == true)   //if in horizontal and in vertical no. is not present means that number will be put in that block.
                            {
                                assignvalues(x_coordinate, y_coordinate, i);
                            }
                            else  //add global error in order to find out easily and debug
                            {
                                if (iterateCounter > 0)  //only if second or more iterates takes place
                                {
                                    if (notPresentVertically == true) // for given co-ordinates in y axis same value present
                                    {
                                        globalError = globalError + "For a[" + x_coordinate + "," + y_coordinate + "] " + i + " present vertically\n";
                                    }
                                    if (notPresentHorizontally == true) // for given co-ordinates in y axis same value present
                                    {
                                        globalError = globalError + "For a[" + x_coordinate + "," + y_coordinate + "] " + i + " present horizontally\n";
                                    }
                                }
                            }
                        }
                     }
                 }
               








            }

         }

         //in order to check whether number is already present or not
         public bool  checkblock(int xstartingaxis, int xendingaxis, int ystartingaxis, int yendingaxis ,int checknumber)
         {
             bool status = true ;
             for (int i = xstartingaxis; i <= xendingaxis; i++)
             {
                 for (int j = ystartingaxis; j <= yendingaxis; j++)
                 {
                     if (a[i, j] == checknumber)
                     {
                         status = false;
                     }
                 }
             }
             return status;
         }

        //empty cells will be filled
        public void blockcalculate(int xstartingaxis, int xendingaxis, int ystartingaxis, int yendingaxis, int x_coordinate, int y_coordinate)
        {


            for (int i = 1; i <= 9; i++)
            {
                string innertemp = string.Empty;
                for (int ji = 0; ji <= 8; ji++)                    //get all the numbers in the row for selected coordinate
                {
                    innertemp = innertemp + "," + a[x_coordinate, ji].ToString();
                }

                s9.Clear(); //added on 10/10/2016 previous values will be cleared
                if (innertemp.Contains(i.ToString()) == false)    //find the number which is not in the row
                {
                    s9.Push(i);                                    // that number will be pushed into s9
                    int solvenumber = Convert.ToInt32(s9.Peek());  //look whether solvenumber is present in stack
                    bool notPresentHorizontally = false;
                    bool notPresentVertically = false;
                    bool notPresentInBlock = false;
                    for (int kk1 = 0; kk1 <= 8; kk1++)              //check whether solvenumber is present in that particular row
                    {
                        if (a[x_coordinate, kk1] == solvenumber)
                        {
                            notPresentHorizontally = true; break;
                        }


                    }
                    for (int kk2 = 0; kk2 <= 8; kk2++)            ///check whether solvenumber is present in particular column wise
                    {
                        if (a[kk2, y_coordinate] == solvenumber)
                        {
                            int zz = kk2;
                            notPresentVertically = true; break;
                        }
                    }
                    notPresentInBlock = checkblock(xstartingaxis, xendingaxis, ystartingaxis, yendingaxis, solvenumber);  //block where empty cell is present will be find out and there it will be checked whether no. is already present or not
                    if (notPresentHorizontally == false && notPresentVertically == false && notPresentInBlock == true)   //if in horizontal and in vertical no. is not present means that number will be put in that block.
                    {

                        assignvalues(Convert.ToInt32(x_coordinate), Convert.ToInt32(y_coordinate), solvenumber);
                        s9.Pop();
                        //once done that no. will be removed from stack
                    }
                    else  //add global error in order to find out easily and debug
                    {
                        if (iterateCounter > 0)  //only if second or more iterates takes place
                        {
                            if (notPresentVertically == true) // for given co-ordinates in y axis same value present
                            {
                                globalError = globalError + "For a[" + x_coordinate + "," + y_coordinate + "] " + i + " present vertically\n";
                            }
                            if (notPresentHorizontally == true) // for given co-ordinates in y axis same value present
                            {
                                globalError = globalError + "For a[" + x_coordinate + "," + y_coordinate + "] " + i + " present horizontally\n";
                            }
                        }
                    }

                }
            }

        }

        public int checkoriginalempty()
         {
             int completed = 0;
             for (int i = 0; i <= 8; i++)
             {
                 for (int j = 0; j <= 8; j++)
                 {
                     if (a[i, j] == 0)
                     {
                         completed = 999;
                         markCellsToSolve.Add(i + "," + j); // cells in order to change the color denotes original marking
                     }
                 }
             }
             return completed;

         }

         public int checkforempty()  //here only with zeros will be taken
         {
             int completed = 0;

             foreach (string s in cellsSolved)
             {
                 cellsToSolve.Remove(s);
             }
         
             for (int i = 0; i <= 8; i++)
             {
                 for (int j = 0; j <= 8; j++)
                 {

                     if (a[i, j] == 0)
                     {
                         completed = 999;
                         cellsToSolve.Add(i + "," + j); //taking all the cells which need to be done
                     }
                 }
             }
             return completed;
         }

         public void RunDiagnostic()
         {
            string s1 = string.Empty;
             foreach (string s in diagnostic)
             {
                s1 =s1+ s + "\n";
             }

            Console.WriteLine(s1);
            LogData(s1);
         }

        public void LogData(string input)           //logging data globally
        {
            if (logdataactive)
            {
                StreamWriter sw;

                if (!File.Exists(System.IO.Path.GetFullPath("test.txt")))
                {
                    sw = new StreamWriter(System.IO.Path.GetFullPath("test.txt"));
                }
                else
                {
                    sw = File.AppendText(System.IO.Path.GetFullPath("test.txt"));
                }
                // First, save the standard output.
                sw.WriteLine("Log at :" + System.DateTime.Now);
                sw.WriteLine(input);
                sw.Close();
            }
        }

        public void LogData(List<string> input) //used to see cellsToSolve values
        {
            if (logdataactive)
                {
                StreamWriter sw;
                string s1 = string.Empty;
                foreach (string s in input)
                {
                    s1 = s1 + s + "\n";
                }

                if (!File.Exists(System.IO.Path.GetFullPath("test.txt")))
                {
                    sw = new StreamWriter(System.IO.Path.GetFullPath("test.txt"));
                }
                else
                {
                    sw = File.AppendText(System.IO.Path.GetFullPath("test.txt"));
                }
                // First, save the standard output.
                sw.WriteLine("Loop - " + loopCounter + " Array Log at :" + System.DateTime.Now);
                sw.WriteLine(s1);
                sw.Close();
            }
        }

        public void CompareData()
         {
             int mismatchCounter = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nDiagnostic data:\n");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i <= 8; i++)
             {
                 for (int j = 0; j <= 8; j++)
                 {
                     if (a[i, j] != b[i,j])
                     {
                        
                         Console.WriteLine("mismatch with original data -- a["+i+","+j+"] => "+b[i,j]);
                         mismatchCounter++;
                     }
                 }
             }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Mismatch count : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mismatchCounter);
         }
         //check for repeat
         public int checkforrepeat(int xstartingaxis, int xendingaxis, int ystartingaxis, int yendingaxis, int checknumber)
         {
             int  numcount = 0;
             for (int i = xstartingaxis; i <= xendingaxis; i++)
             {
                 for (int j = ystartingaxis; j <= yendingaxis; j++)
                 {
                     if (a[i, j] == checknumber)
                     {
                         numcount++;
                     }
                 }
             }
             return numcount;
         }        

        public void RunProgram()
        {
            Console.WindowWidth = 100;
            Console.WriteLine(" ");
            Console.WriteLine("                             Sudoku Solver V1.1                          ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n***************    sudoku program starting.....   ****************");
            Console.WriteLine("\nInput Data");

            printdata();

            //before message

            if (checkoriginalempty() == 999)
            {


                Console.SetCursorPosition(50, 8);
                Console.ForegroundColor = ConsoleColor.White;
                string complexity = string.Empty;
                if (markCellsToSolve.Count < 45)
                    complexity = "EASY";
                else if (markCellsToSolve.Count > 45 && markCellsToSolve.Count <= 60)
                    complexity = "MEDIUM";
                else
                    complexity = "HARD";
                Console.Write(" Total empty cells: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(markCellsToSolve.Count);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("      Complexity: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(complexity);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n");

                Console.SetCursorPosition(60, 9);
                Console.Write(" Logging: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (logdataactive)
                    Console.Write("Enabled");
                else
                    Console.Write("Disabled");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Debugging: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (debug==1)
                    Console.Write("Enabled");
                else
                    Console.Write("Disabled");
                Console.WriteLine();

                Console.SetCursorPosition(56, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Trace Steps: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (tracesteps)
                    Console.Write("Enabled");
                else
                    Console.Write("Disabled");
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, 35);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine("***************    sudoku incomplete, solving now....   ****************");
                Console.WriteLine();

                left = Console.CursorLeft; top = Console.CursorTop; //get left and top positions and print in same place
                start:

                horizontals(); //check for individual(only one) horizontal line and fill up
                verticals();   //check for individual(only one) vertical line and fill up
                singleblocks(); //check for single(only one) empty cell according to block

                /*
                //solve x and y bucket
                for (int n=1;n<=9;n++)
                {
                    List<int> horizonatalList = new List<int>();
                    List<int> verticalList = new List<int>();
                    List<int> numberList = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (a[i, j] == n) //if number matches add as numbers
                            {

                                numberList.Add(Convert.ToInt32( Convert.ToString(i)+Convert.ToString(j)));
                            }
                        }
                    }

                    var hlist1 = numberList.Where(c => c >= 0 && c <= 28).ToList();
                    var hlist2 = numberList.Where(c => c >= 30 && c <= 58).ToList();
                    var hlist3= numberList.Where(c => c >= 60 &&  c<= 88 ).ToList();

                    var vlist1 = numberList.Where( c=> (c ==0 || c== 1 ||c== 2||c== 10||c== 11||c== 12||c== 20||c== 21||c== 22||c== 30||c== 31||c== 32||c== 40||c== 41||c== 42||c== 50||c== 51||c== 52||c== 60||c== 61||c== 62||c== 70||c== 71||c== 72||c== 80||c== 81||c== 82)).ToList();
                    var vlist2 = numberList.Where(c => (c==3||c==4||c==5||c==13||c==14||c==15||c==23||c==24||c==25||c==33||c==34||c==35||c==43||c==44||c==45||c==53||c==54||c==55||c==63||c==64||c==65||c==73||c==74||c==75||c==83||c==84||c==85)).ToList();
                    var vlist3 = numberList.Where(c => (c ==6||c==7||c==8||c==16||c==17||c==18||c==26||c==27||c==28||c==36||c==37||c==38||c==46||c==47||c==48||c==56||c==57||c==58||c==66||c==67||c==68||c==76||c==77||c==78||c==86||c==87||c==88)).ToList();

                    if(hlist1.Count==2)
                    {
                        int[] array = new int[2];
                        int[] originalArray = { 0, 1, 2 }; //get original co-ordinates block

                        string g = hlist1[0].ToString();
                        string h = hlist1[1].ToString();
                        if (g.Length == 1)
                        {
                            g = "0" + g;
                        }
                        if (h.Length == 1)
                        {
                            h = "0" + h;
                        }

                        array[0] = Convert.ToInt32(g.Substring(0, 1));  //get values
                        array[1] = Convert.ToInt32(h.Substring(0, 1));

                        var m = originalArray.Except(array); //get which is not in list
                        int p = 999;
                        foreach (var s in m)
                        {
                            p = s;
                        }

                        int[] array1 = new int[2];
                        array1[0] = Convert.ToInt32(g.Substring(1, 1));  //get values
                        array1[1] = Convert.ToInt32(h.Substring(1, 1));

                        List<int> originalArray1 = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

                        if ((array1[0] >= 0 && array1[0] <= 2) || (array1[1] >= 0 && array1[1] <= 2))
                        {
                            originalArray1.Remove(0); originalArray1.Remove(1); originalArray1.Remove(2);
                        }
                        if ((array1[0] >= 3 && array1[0] <= 5) || (array1[1] >= 3 && array1[1] <= 5))
                        {
                            originalArray1.Remove(3); originalArray1.Remove(4); originalArray1.Remove(5);
                        }
                        if ((array1[0] >= 6 && array1[0] <= 8) || (array1[1] >= 6 && array1[1] <= 8))
                        {
                            originalArray1.Remove(6); originalArray1.Remove(7); originalArray1.Remove(8);
                        }
                        foreach (int s in originalArray1)
                        {

                            if (a[p, s] == 0)
                            {
                                bool notPresentHorizontally = false;
                                bool notPresentVertically = false;

                                for (int kk1 = 0; kk1 <= 8; kk1++)              //check whether solvenumber is present in that particular row
                                {
                                    if (a[p, kk1] == n)
                                    {
                                        notPresentHorizontally = true; break;
                                    }


                                }
                                for (int kk2 = 0; kk2 <= 8; kk2++)            ///check whether solvenumber is present in particular column wise
                                {
                                    if (a[kk2, s] == n)
                                    {
                                        int zz = kk2;
                                        notPresentVertically = true; break;
                                    }
                                }
                                if (notPresentHorizontally == false && notPresentVertically == false)
                                {
                                    assignvalues(p, s, n);
                                }
                            }
                        }
                    }
                    if (hlist2.Count == 2)
                    {
                        int[] array = new int[2];
                        int[] originalArray = { 3, 4, 5 }; //get original co-ordinates block

                        string g = hlist2[0].ToString();
                        string h = hlist2[1].ToString();

                        if (g.Length == 1)
                        {
                            g = "0" + g;
                        }
                        if (h.Length == 1)
                        {
                            h = "0" + h;
                        }

                        array[0] = Convert.ToInt32(g.Substring(0, 1));  //get values
                        array[1] = Convert.ToInt32(h.Substring(0, 1));

                        var m = originalArray.Except(array); //get which is not in list
                        int p = 999;
                        foreach (var s in m)
                        {
                            p = s;
                        }

                        int[] array1 = new int[2];
                        array1[0] = Convert.ToInt32(g.Substring(1, 1));  //get values
                        array1[1] = Convert.ToInt32(h.Substring(1, 1));

                        List<int> originalArray1 = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

                        if ((array1[0] >= 0 && array1[0] <= 2) || (array1[1] >= 0 && array1[1] <= 2))
                        {
                            originalArray1.Remove(0); originalArray1.Remove(1); originalArray1.Remove(2);
                        }
                        if ((array1[0] >= 3 && array1[0] <= 5) || (array1[1] >= 3 && array1[1] <= 5))
                        {
                            originalArray1.Remove(3); originalArray1.Remove(4); originalArray1.Remove(5);
                        }
                        if ((array1[0] >= 6 && array1[0] <= 8) || (array1[1] >= 6 && array1[1] <= 8))
                        {
                            originalArray1.Remove(6); originalArray1.Remove(7); originalArray1.Remove(8);
                        }
                        foreach (int s in originalArray1)
                        {

                            if (a[p, s] == 0)
                            {
                                bool notPresentHorizontally = false;
                                bool notPresentVertically = false;

                                for (int kk1 = 0; kk1 <= 8; kk1++)              //check whether solvenumber is present in that particular row
                                {
                                    if (a[p, kk1] == n)
                                    {
                                        notPresentHorizontally = true; break;
                                    }


                                }
                                for (int kk2 = 0; kk2 <= 8; kk2++)            ///check whether solvenumber is present in particular column wise
                                {
                                    if (a[kk2, s] == n)
                                    {
                                        int zz = kk2;
                                        notPresentVertically = true; break;
                                    }
                                }
                                if (notPresentHorizontally == false && notPresentVertically == false)
                                {
                                    assignvalues(p, s, n);
                                }
                            }
                        }

                    }
                    if (hlist3.Count == 2)
                    {
                        int[] array = new int[2];
                        int[] originalArray = { 6, 7, 8 }; //get original co-ordinates block

                        string g = hlist3[0].ToString();
                        string h = hlist3[1].ToString();

                        if (g.Length == 1)
                        {
                            g = "0" + g;
                        }
                        if (h.Length == 1)
                        {
                            h = "0" + h;
                        }

                        array[0] = Convert.ToInt32(g.Substring(0, 1));  //get values
                        array[1] = Convert.ToInt32(h.Substring(0, 1));

                        var m = originalArray.Except(array); //get which is not in list
                        int p=999;
                        foreach (var s in m)
                        {
                            p = s;
                        }

                        int[] array1 = new int[2];
                        array1[0] = Convert.ToInt32(g.Substring(1, 1));  //get values
                        array1[1] = Convert.ToInt32(h.Substring(1, 1));

                        List<int> originalArray1 = new List<int>(new int[] { 0,1,2,3,4,5,6, 7, 8 });

                        if((array1[0]>=0 && array1[0]<=2) || (array1[1] >= 0 && array1[1] <= 2))
                        {
                            originalArray1.Remove(0); originalArray1.Remove(1); originalArray1.Remove(2);
                        }
                        if ((array1[0] >= 3 && array1[0] <= 5)|| (array1[1] >= 3 && array1[1] <= 5))
                        {
                            originalArray1.Remove(3); originalArray1.Remove(4); originalArray1.Remove(5);
                        }
                        if ((array1[0] >= 6 && array1[0] <= 8) || (array1[1] >= 6 && array1[1] <= 8))
                        {
                            originalArray1.Remove(6); originalArray1.Remove(7); originalArray1.Remove(8);
                        }

                        foreach(int s in originalArray1)
                        {
                            
                            if (a[p,s] == 0)
                            {
                                bool notPresentHorizontally = false;
                                bool notPresentVertically = false;
                                
                                for (int kk1 = 0; kk1 <= 8; kk1++)              //check whether solvenumber is present in that particular row
                                {
                                    if (a[p, kk1] == n)
                                    {
                                        notPresentHorizontally = true; break;
                                    }


                                }
                                for (int kk2 = 0; kk2 <= 8; kk2++)            ///check whether solvenumber is present in particular column wise
                                {
                                    if (a[kk2, s] == n)
                                    {
                                        int zz = kk2;
                                        notPresentVertically = true; break;
                                    }
                                }
                                if(notPresentHorizontally == false && notPresentVertically == false)
                                {
                                    assignvalues(p, s, n);
                                }
                            }
                        }

                    }
                    if (vlist1.Count == 2)
                    {

                    }
                    if (vlist2.Count == 2)
                    {

                    }
                    if (vlist3.Count == 2)
                    {

                    }

                }
                

                //x and y bucket ends here
                */
                printdata();
                //    cellsSolved = new List<string>();  //-- enable later
                
                

                int completecount = 0;

                if (cellsToSolve.Count > 0)      //take multiple count here
                {
                    foreach (string s in cellsToSolve)
                    {
                        string[] arr = s.Split(',');
                        int x_coordinate = Convert.ToInt32(arr[0]);
                        int y_coordinate = Convert.ToInt32(arr[1]);

                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 0 && y_coordinate <= 2)) //1st block
                        {
                            blockcalculate(0, 2, 0, 2, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 3 && y_coordinate <= 5))//2nd block
                        {
                            blockcalculate(0, 2, 3, 5, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 6 && y_coordinate <= 8)) //3rd block
                        {
                            blockcalculate(0, 2, 6, 8, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 0 && y_coordinate <= 2)) //4th block
                        {
                            blockcalculate(3, 5, 0, 2, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 3 && y_coordinate <= 5)) //5th block
                        {
                            blockcalculate(3, 5, 3, 5, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 6 && y_coordinate <= 8)) //6th block
                        {
                            blockcalculate(3, 5, 6, 8, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 0 && y_coordinate <= 2)) //7th block
                        {
                            blockcalculate(6, 8, 0, 2, x_coordinate, y_coordinate);// continue;

                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 3 && y_coordinate <= 5)) //8th block
                        {
                            blockcalculate(6, 8, 3, 5, x_coordinate, y_coordinate);// continue;
                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 6 && y_coordinate <= 8)) //9th block
                        {
                            blockcalculate(6, 8, 6, 8, x_coordinate, y_coordinate);// continue;
                        }
                    }
                }

                if (checkforempty() == 999)
                {
                    foreach (string s in cellsSolved)
                    {
                        cellsToSolve.Remove(s);
                    }
                    cellsSolved = new List<string>();
                    loopCounter++;

                    if (cellsToSolve.SequenceEqual(cellsToSolvePrevious) && loopCounter>4)
                        {
                        EndSudoku();
                    }
                    else {
                        LogData(cellsToSolve);
                        printdata();
                        cellsToSolvePrevious = cellsToSolve;
                        goto start;
                    }
                    //if zero go on again and recalculate
                }
                else
                {
                    printdata();
                    // check for errors and go for recalculate
                    // ***** write code removing duplicates -- from 1 to 9 will go and will search for every cell, if multiple will come then will delete
                    string mismatchdata = string.Empty;
                    foreach (string s in markCellsToSolve)
                    {
                        string[] arr = s.Split(',');
                        int x_coordinate = Convert.ToInt32(arr[0]);
                        int y_coordinate = Convert.ToInt32(arr[1]);
                        int bcount = 0;
                        int xcount = 0;
                        int ycount = 0;

                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 0 && y_coordinate <= 2)) //1st block
                        {
                            bcount = checkforrepeat(0, 2, 0, 2, a[x_coordinate, y_coordinate]);
                            // continue;
                        }
                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 3 && y_coordinate <= 5))//2nd block
                        {
                            bcount = checkforrepeat(0, 2, 3, 5, a[x_coordinate, y_coordinate]);
                            // continue;

                        }
                        if ((x_coordinate >= 0 && x_coordinate <= 2) && (y_coordinate >= 6 && y_coordinate <= 8)) //3rd block
                        {
                            bcount = checkforrepeat(0, 2, 6, 8, a[x_coordinate, y_coordinate]);
                            //  continue;

                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 0 && y_coordinate <= 2)) //4th block
                        {
                            bcount = checkforrepeat(3, 5, 0, 2, a[x_coordinate, y_coordinate]);
                            //  continue;

                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 3 && y_coordinate <= 5)) //5th block
                        {
                            bcount = checkforrepeat(3, 5, 3, 5, a[x_coordinate, y_coordinate]);
                            //  continue;

                        }
                        if ((x_coordinate >= 3 && x_coordinate <= 5) && (y_coordinate >= 6 && y_coordinate <= 8)) //6th block
                        {
                            bcount = checkforrepeat(3, 5, 6, 8, a[x_coordinate, y_coordinate]);
                            //   continue;

                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 0 && y_coordinate <= 2)) //7th block
                        {
                            bcount = checkforrepeat(6, 8, 0, 2, a[x_coordinate, y_coordinate]);
                            //  continue;


                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 3 && y_coordinate <= 5)) //8th block
                        {
                            bcount = checkforrepeat(6, 8, 3, 5, a[x_coordinate, y_coordinate]);
                            //   continue;



                        }
                        if ((x_coordinate >= 6 && x_coordinate <= 8) && (y_coordinate >= 6 && y_coordinate <= 8)) //9th block
                        {
                            bcount = checkforrepeat(6, 8, 6, 8, a[x_coordinate, y_coordinate]);
                            //  continue;


                        }

                        for (int i = 0; i < 9; i++)
                        {
                            if (a[x_coordinate, i] == a[x_coordinate, y_coordinate]) //xaxis
                            {
                                xcount++;
                            }
                        }
                        for (int i = 0; i < 9; i++)
                        {
                            if (a[i, y_coordinate] == a[x_coordinate, y_coordinate]) //yaxis
                            {
                                ycount++;
                            }
                        }




                        if (bcount > 1 || xcount > 1 || ycount > 1)  //if same values are coming then its resetting to 0
                        {

                            a[x_coordinate, y_coordinate] = 0;
                            completecount++;
                            mismatchdata = mismatchdata + "a[" + x_coordinate + "," + y_coordinate + "]" + ", ";

                        }

                    }

                    if (completecount > 0) // on erorr values will be set to 0, then again send once more to complete
                    {
                        iterateCounter++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n");
                        Console.Write("Mismatch count : ");
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(completecount + " ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(mismatchdata.Substring(0, mismatchdata.Length - 2));
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\n");
                        Console.WriteLine("Some values needs to be revisted, sending one more time...");
                        if (iterateCounter <= 2)
                        {
                            globalError = string.Empty;
                            goto start;
                        }
                        else  //halt solving sudoku
                        {
                            EndSudoku();
                        }

                    }



                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("***************    sudoku solving completed   ****************");
                    RunDiagnostic();   //check whether filled data is correct or not


                }//ends else part here

                
                

            } //ends main part
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine("***************    sudoku already complete, nothing to solve   ****************");
            }
            Console.ReadKey();
        }

        public void EndSudoku()
        {
            printdata();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nFollowing errors are present and solver will go in infinte loop Sudoku solving halted\n");
            Console.WriteLine(globalError);
            CompareData(); //Check whether original and filled data is correct matches
        }
        static void Main(string[] args)
        {
            program p = new program();
            testdata mytestdata = new testdata();
            if (p.debug == 1)
            {
                p.left = 0; p.top = 6; p.speed = 200;
            }
            else
            {
                p.left = Console.CursorLeft; p.top = Console.CursorTop; p.speed = 0;
            }

            //p.a = mytestdata.set1_test;
            //p.b = mytestdata.set1_original;

            //p.RunProgram();

            //p.a = mytestdata.set2_test;
            //p.b = mytestdata.set2_original;

            //p.RunProgram();

            p.a = mytestdata.set3_test;
            p.b = mytestdata.set3_original;

            p.RunProgram();

        }

    }

  
}

