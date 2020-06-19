using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ConsoleApplication1
{

    public class testdata
    {
        public int[,] set1_original = new int[9, 9] ;
        public  int[,] set1_test = new int[9, 9];

        public int[,] set2_original = new int[9, 9];
        public int[,] set2_test = new int[9, 9];

        public int[,] set3_original = new int[9, 9];
        public int[,] set3_test = new int[9, 9];
        public testdata()
        {
            set1_original[0, 0] = 9;
            set1_original[0, 1] = 8;
            set1_original[0, 2] = 4;
            set1_original[0, 3] = 5;
            set1_original[0, 4] = 2;
            set1_original[0, 5] = 1;
            set1_original[0, 6] = 3;
            set1_original[0, 7] = 7;
            set1_original[0, 8] = 6;

            set1_original[1, 0] = 2;
            set1_original[1, 1] = 3;
            set1_original[1, 2] = 5;
            set1_original[1, 3] = 9;
            set1_original[1, 4] = 6;
            set1_original[1, 5] = 7;
            set1_original[1, 6] = 1;
            set1_original[1, 7] = 8;
            set1_original[1, 8] = 4;

            set1_original[2, 0] = 7;
            set1_original[2, 1] = 1;
            set1_original[2, 2] = 6;
            set1_original[2, 3] = 3;
            set1_original[2, 4] = 4;
            set1_original[2, 5] = 8;
            set1_original[2, 6] = 5;
            set1_original[2, 7] = 2;
            set1_original[2, 8] = 9;

            set1_original[3, 0] = 6;
            set1_original[3, 1] = 5;
            set1_original[3, 2] = 3;
            set1_original[3, 3] = 2;
            set1_original[3, 4] = 1;
            set1_original[3, 5] = 4;
            set1_original[3, 6] = 7;
            set1_original[3, 7] = 9;
            set1_original[3, 8] = 8;

            set1_original[4, 0] = 8;
            set1_original[4, 1] = 9;
            set1_original[4, 2] = 2;
            set1_original[4, 3] = 7;
            set1_original[4, 4] = 3;
            set1_original[4, 5] = 5;
            set1_original[4, 6] = 6;
            set1_original[4, 7] = 4;
            set1_original[4, 8] = 1;

            set1_original[5, 0] = 4;
            set1_original[5, 1] = 7;
            set1_original[5, 2] = 1;
            set1_original[5, 3] = 6;
            set1_original[5, 4] = 8;  // here its important now
            set1_original[5, 4] = 8;
            set1_original[5, 5] = 9;
            set1_original[5, 6] = 2;
            set1_original[5, 7] = 5;
            set1_original[5, 8] = 3;

            set1_original[6, 0] = 3;
            set1_original[6, 1] = 6;
            set1_original[6, 2] = 7;
            set1_original[6, 3] = 8;
            set1_original[6, 4] = 9;
            set1_original[6, 5] = 2;
            set1_original[6, 6] = 4;
            set1_original[6, 7] = 1;
            set1_original[6, 8] = 5;

            set1_original[7, 0] = 1;
            set1_original[7, 1] = 2;
            set1_original[7, 2] = 8;
            set1_original[7, 3] = 4;
            set1_original[7, 4] = 5;
            set1_original[7, 5] = 3;
            set1_original[7, 6] = 9;
            set1_original[7, 7] = 6;
            set1_original[7, 8] = 7;

            set1_original[8, 0] = 5;
            set1_original[8, 1] = 4;
            set1_original[8, 2] = 9;
            set1_original[8, 3] = 1;
            set1_original[8, 4] = 7;
            set1_original[8, 5] = 6;
            set1_original[8, 6] = 8;
            set1_original[8, 7] = 3;
            set1_original[8, 8] = 2;

            set1_test[0, 0] = 9;
            set1_test[0, 1] = 8;
            set1_test[0, 1] = 0;
            set1_test[0, 2] = 4;
            set1_test[0, 3] = 5;
            set1_test[0, 3] = 0;
            set1_test[0, 4] = 2;
            set1_test[0, 4] = 0;
            set1_test[0, 5] = 1;
            set1_test[0, 5] = 0;
            set1_test[0, 6] = 3;
            set1_test[0, 7] = 7;
            set1_test[0, 8] = 6;
            set1_test[0, 8] = 0;


            set1_test[1, 0] = 2;
            set1_test[1, 1] = 3;
            set1_test[1, 1] = 0;
            set1_test[1, 2] = 5;
            set1_test[1, 2] = 0;
            set1_test[1, 3] = 9;
            set1_test[1, 4] = 6;
            set1_test[1, 5] = 7;
            set1_test[1, 5] = 0;
            set1_test[1, 6] = 1;
            set1_test[1, 6] = 0;
            set1_test[1, 7] = 8;
            set1_test[1, 8] = 4;
            set1_test[1, 8] = 0;


            set1_test[2, 0] = 7;
            set1_test[2, 1] = 1;
            set1_test[2, 2] = 6;
            set1_test[2, 2] = 0;
            set1_test[2, 3] = 3;
            set1_test[2, 4] = 4;
            set1_test[2, 4] = 0;
            set1_test[2, 5] = 8;
            set1_test[2, 5] = 0;
            set1_test[2, 6] = 5;
            set1_test[2, 6] = 0;
            set1_test[2, 7] = 2;
            set1_test[2, 7] = 0;
            set1_test[2, 8] = 9;
            set1_test[2, 8] = 0;

            set1_test[3, 0] = 6;
            set1_test[3, 1] = 5;
            set1_test[3, 1] = 0;
            set1_test[3, 2] = 3;
            set1_test[3, 3] = 2;
            set1_test[3, 4] = 1;
            set1_test[3, 4] = 0;
            set1_test[3, 5] = 4;
            set1_test[3, 5] = 0;
            set1_test[3, 6] = 7;
            set1_test[3, 6] = 0;
            set1_test[3, 7] = 9;
            set1_test[3, 8] = 8;

            set1_test[4, 0] = 8;
            set1_test[4, 1] = 9;
            //  set1_test[4, 1] = 0;
            set1_test[4, 2] = 2;
            set1_test[4, 3] = 7;
            //      set1_test[4, 3] = 0;
            set1_test[4, 4] = 3;
            set1_test[4, 5] = 5;
            set1_test[4, 5] = 0;
            set1_test[4, 6] = 6;
            set1_test[4, 7] = 4;
            set1_test[4, 7] = 0;
            set1_test[4, 8] = 1;


            set1_test[5, 0] = 4;
            set1_test[5, 1] = 7;
            set1_test[5, 2] = 1;
            // set1_test[5, 2] = 0;
            set1_test[5, 3] = 6;
            set1_test[5, 3] = 0;
            set1_test[5, 4] = 8;  // here its important now
                          //set1_test[5, 4] = 0;
            set1_test[5, 5] = 9;
            set1_test[5, 6] = 2;
            set1_test[5, 7] = 5;
            set1_test[5, 7] = 0;
            set1_test[5, 8] = 3;

            set1_test[6, 0] = 3;
            set1_test[6, 0] = 0;
            set1_test[6, 1] = 6;
            set1_test[6, 1] = 0;
            set1_test[6, 2] = 7;
            set1_test[6, 2] = 0;
            set1_test[6, 3] = 8;
            set1_test[6, 3] = 0;//here checking today
            set1_test[6, 4] = 9;
            set1_test[6, 4] = 0;
            set1_test[6, 5] = 2;
            set1_test[6, 6] = 4;
            set1_test[6, 6] = 0;
            set1_test[6, 7] = 1;
            set1_test[6, 8] = 5;

            set1_test[7, 0] = 1;
            set1_test[7, 0] = 0;
            set1_test[7, 1] = 2;
            set1_test[7, 2] = 8;
            set1_test[7, 2] = 0;
            set1_test[7, 3] = 4;
            set1_test[7, 3] = 0;
            set1_test[7, 4] = 5;
            set1_test[7, 5] = 3;
            set1_test[7, 6] = 9;
            // set1_test[7, 6] = 0;
            set1_test[7, 7] = 6;
            set1_test[7, 7] = 0;
            set1_test[7, 8] = 7;

            set1_test[8, 0] = 5;
            set1_test[8, 0] = 0;
            set1_test[8, 1] = 4;
            set1_test[8, 2] = 9;
            set1_test[8, 3] = 1;
            set1_test[8, 3] = 0;
            set1_test[8, 4] = 7;
            set1_test[8, 4] = 0;
            set1_test[8, 5] = 6;
            set1_test[8, 5] = 0;
            set1_test[8, 6] = 8;
            set1_test[8, 7] = 3;
            set1_test[8, 7] = 0;
            set1_test[8, 8] = 2;

            set2_original[0, 0] = 4;
            set2_original[0, 1] = 3;
            set2_original[0, 2] = 5;
            set2_original[0, 3] = 2;
            set2_original[0, 4] = 6;
            set2_original[0, 5] = 9;
            set2_original[0, 6] = 7;
            set2_original[0, 7] = 8;
            set2_original[0, 8] = 1;

            set2_original[1, 0] = 6;
            set2_original[1, 1] = 8;
            set2_original[1, 2] = 2;
            set2_original[1, 3] = 5;
            set2_original[1, 4] = 7;
            set2_original[1, 5] = 1;
            set2_original[1, 6] = 4;
            set2_original[1, 7] = 9;
            set2_original[1, 8] = 3;

            set2_original[2, 0] = 1;
            set2_original[2, 1] = 9;
            set2_original[2, 2] = 7;
            set2_original[2, 3] = 8;
            set2_original[2, 4] = 3;
            set2_original[2, 5] = 4;
            set2_original[2, 6] = 5;
            set2_original[2, 7] = 6;
            set2_original[2, 8] = 2;

            set2_original[3, 0] = 8;
            set2_original[3, 1] = 2;
            set2_original[3, 2] = 6;
            set2_original[3, 3] = 1;
            set2_original[3, 4] = 9;
            set2_original[3, 5] = 5;
            set2_original[3, 6] = 3;
            set2_original[3, 7] = 4;
            set2_original[3, 8] = 7;

            set2_original[4, 0] = 3;
            set2_original[4, 1] = 7;
            set2_original[4, 2] = 4;
            set2_original[4, 3] = 6;
            set2_original[4, 4] = 8;
            set2_original[4, 5] = 2;
            set2_original[4, 6] = 9;
            set2_original[4, 7] = 1;
            set2_original[4, 8] = 5;

            set2_original[5, 0] = 9;
            set2_original[5, 1] = 5;
            set2_original[5, 2] = 1;
            set2_original[5, 3] = 7;
            set2_original[5, 4] = 4;  // here its important now
            set2_original[5, 5] = 3;
            set2_original[5, 6] = 6;
            set2_original[5, 7] = 2;
            set2_original[5, 8] = 8;


            set2_original[6, 0] = 5;
            set2_original[6, 1] = 1;
            set2_original[6, 2] = 9;
            set2_original[6, 3] = 3;
            set2_original[6, 4] = 2;
            set2_original[6, 5] = 6;
            set2_original[6, 6] = 8;
            set2_original[6, 7] = 7;
            set2_original[6, 8] = 4;

            set2_original[7, 0] = 2;
            set2_original[7, 1] = 4;
            set2_original[7, 2] = 8;
            set2_original[7, 3] = 9;
            set2_original[7, 4] = 5;
            set2_original[7, 5] = 7;
            set2_original[7, 6] = 1;
            set2_original[7, 7] = 3;
            set2_original[7, 8] = 6;

            set2_original[8, 0] = 7;
            set2_original[8, 1] = 6;
            set2_original[8, 2] = 3;
            set2_original[8, 3] = 4;
            set2_original[8, 4] = 1;
            set2_original[8, 5] = 8;
            set2_original[8, 6] = 2;
            set2_original[8, 7] = 5;
            set2_original[8, 8] = 9;

            set2_test[0, 0] = 0;
            set2_test[0, 1] = 0;
            set2_test[0, 2] = 0;
            set2_test[0, 3] = 2;
            set2_test[0, 4] = 6;
            set2_test[0, 5] = 0;
            set2_test[0, 6] = 7;
            set2_test[0, 7] = 0;
            set2_test[0, 8] = 1;

            set2_test[1, 0] = 6;
            set2_test[1, 1] = 8;
            set2_test[1, 2] = 0;
            set2_test[1, 3] = 0;
            set2_test[1, 4] = 7;
            set2_test[1, 5] = 0;
            set2_test[1, 6] = 0;
            set2_test[1, 7] = 9;
            set2_test[1, 8] = 0;

            set2_test[2, 0] = 1;
            set2_test[2, 1] = 9;
            set2_test[2, 2] = 0;
            set2_test[2, 3] = 0;
            set2_test[2, 4] = 0;
            set2_test[2, 5] = 4;
            set2_test[2, 6] = 5;
            set2_test[2, 7] = 0;
            set2_test[2, 8] = 0;

            set2_test[3, 0] = 8;
            set2_test[3, 1] = 2;
            set2_test[3, 2] = 0;
            set2_test[3, 3] = 1;
            set2_test[3, 4] = 0;
            set2_test[3, 5] = 0;
            set2_test[3, 6] = 0;
            set2_test[3, 7] = 4;
            set2_test[3, 8] = 0;

            set2_test[4, 0] = 0;
            set2_test[4, 1] = 0;
            set2_test[4, 2] = 4;
            set2_test[4, 3] = 6;
            set2_test[4, 4] = 0;
            set2_test[4, 5] = 2;
            set2_test[4, 6] = 9;
            set2_test[4, 7] = 0;
            set2_test[4, 8] = 0;

            set2_test[5, 0] = 0;
            set2_test[5, 1] = 5;
            set2_test[5, 2] = 0;
            set2_test[5, 3] = 0;
            set2_test[5, 4] = 0;  // here its importcnt now
            set2_test[5, 5] = 3;
            set2_test[5, 6] = 0;
            set2_test[5, 7] = 2;
            set2_test[5, 8] = 8;


            set2_test[6, 0] = 0;
            set2_test[6, 1] = 0;
            set2_test[6, 2] = 9;
            set2_test[6, 3] = 3;
            set2_test[6, 4] = 0;
            set2_test[6, 5] = 0;
            set2_test[6, 6] = 0;
            set2_test[6, 7] = 7;
            set2_test[6, 8] = 4;

            set2_test[7, 0] = 0;
            set2_test[7, 1] = 4;
            set2_test[7, 2] = 0;
            set2_test[7, 3] = 0;
            set2_test[7, 4] = 5;
            set2_test[7, 5] = 0;
            set2_test[7, 6] = 0;
            set2_test[7, 7] = 3;
            set2_test[7, 8] = 6;

            set2_test[8, 0] = 7;
            set2_test[8, 1] = 0;
            set2_test[8, 2] = 3;
            set2_test[8, 3] = 0;
            set2_test[8, 4] = 1;
            set2_test[8, 5] = 8;
            set2_test[8, 6] = 0;
            set2_test[8, 7] = 0;
            set2_test[8, 8] = 0;

            set3_original[0, 0] = 2;
            set3_original[0, 1] = 6;
            set3_original[0, 2] = 1;
            set3_original[0, 3] = 3;
            set3_original[0, 4] = 7;
            set3_original[0, 5] = 5;
            set3_original[0, 6] = 8;
            set3_original[0, 7] = 9;
            set3_original[0, 8] = 4;

            set3_original[1, 0] = 5;
            set3_original[1, 1] = 3;
            set3_original[1, 2] = 7;
            set3_original[1, 3] = 8;
            set3_original[1, 4] = 9;
            set3_original[1, 5] = 4;
            set3_original[1, 6] = 1;
            set3_original[1, 7] = 6;
            set3_original[1, 8] = 2;

            set3_original[2, 0] = 9;
            set3_original[2, 1] = 4;
            set3_original[2, 2] = 8;
            set3_original[2, 3] = 2;
            set3_original[2, 4] = 1;
            set3_original[2, 5] = 6;
            set3_original[2, 6] = 3;
            set3_original[2, 7] = 5;
            set3_original[2, 8] = 7;

            set3_original[3, 0] = 6;
            set3_original[3, 1] = 9;
            set3_original[3, 2] = 4;
            set3_original[3, 3] = 7;
            set3_original[3, 4] = 5;
            set3_original[3, 5] = 1;
            set3_original[3, 6] = 2;
            set3_original[3, 7] = 3;
            set3_original[3, 8] = 8;

            set3_original[4, 0] = 8;
            set3_original[4, 1] = 2;
            set3_original[4, 2] = 5;
            set3_original[4, 3] = 9;
            set3_original[4, 4] = 4;
            set3_original[4, 5] = 3;
            set3_original[4, 6] = 6;
            set3_original[4, 7] = 7;
            set3_original[4, 8] = 1;

            set3_original[5, 0] = 7;
            set3_original[5, 1] = 1;
            set3_original[5, 2] = 3;
            set3_original[5, 3] = 6;
            set3_original[5, 4] = 2;  // here its important now
            set3_original[5, 5] = 8;
            set3_original[5, 6] = 9;
            set3_original[5, 7] = 4;
            set3_original[5, 8] = 5;


            set3_original[6, 0] = 3;
            set3_original[6, 1] = 5;
            set3_original[6, 2] = 6;
            set3_original[6, 3] = 4;
            set3_original[6, 4] = 8;
            set3_original[6, 5] = 2;
            set3_original[6, 6] = 7;
            set3_original[6, 7] = 1;
            set3_original[6, 8] = 9;

            set3_original[7, 0] = 4;
            set3_original[7, 1] = 8;
            set3_original[7, 2] = 9;
            set3_original[7, 3] = 1;
            set3_original[7, 4] = 6;
            set3_original[7, 5] = 7;
            set3_original[7, 6] = 5;
            set3_original[7, 7] = 2;
            set3_original[7, 8] = 3;

            set3_original[8, 0] = 1;
            set3_original[8, 1] = 7;
            set3_original[8, 2] = 2;
            set3_original[8, 3] = 5;
            set3_original[8, 4] = 3;
            set3_original[8, 5] = 9;
            set3_original[8, 6] = 4;
            set3_original[8, 7] = 8;
            set3_original[8, 8] = 6;

            set3_test[0, 0] = 0;
            set3_test[0, 1] = 6;
            set3_test[0, 2] = 0;
            set3_test[0, 3] = 3;
            set3_test[0, 4] = 0;
            set3_test[0, 5] = 0;
            set3_test[0, 6] = 8;
            set3_test[0, 7] = 0;
            set3_test[0, 8] = 4;

            set3_test[1, 0] = 5;
            set3_test[1, 1] = 3;
            set3_test[1, 2] = 7;
            set3_test[1, 3] = 0;
            set3_test[1, 4] = 9;
            set3_test[1, 5] = 0;
            set3_test[1, 6] = 0;
            set3_test[1, 7] = 0;
            set3_test[1, 8] = 0;

            set3_test[2, 0] = 0;
            set3_test[2, 1] = 4;
            set3_test[2, 2] = 0;
            set3_test[2, 3] = 0;
            set3_test[2, 4] = 0;
            set3_test[2, 5] = 6;
            set3_test[2, 6] = 3;
            set3_test[2, 7] = 0;
            set3_test[2, 8] = 7;

            set3_test[3, 0] = 0;
            set3_test[3, 1] = 9;
            set3_test[3, 2] = 0;
            set3_test[3, 3] = 0;
            set3_test[3, 4] = 5;
            set3_test[3, 5] = 1;
            set3_test[3, 6] = 2;
            set3_test[3, 7] = 3;
            set3_test[3, 8] = 8;

            set3_test[4, 0] = 0;
            set3_test[4, 1] = 0;
            set3_test[4, 2] = 0;
            set3_test[4, 3] = 0;
            set3_test[4, 4] = 0;
            set3_test[4, 5] = 0;
            set3_test[4, 6] = 0;
            set3_test[4, 7] = 0;
            set3_test[4, 8] = 0;

            set3_test[5, 0] = 7;
            set3_test[5, 1] = 1;
            set3_test[5, 2] = 3;
            set3_test[5, 3] = 6;
            set3_test[5, 4] = 2;  // here its importcnt now
            set3_test[5, 5] = 0;
            set3_test[5, 6] = 0;
            set3_test[5, 7] = 4;
            set3_test[5, 8] = 0;


            set3_test[6, 0] = 3;
            set3_test[6, 1] = 0;
            set3_test[6, 2] = 6;
            set3_test[6, 3] = 4;
            set3_test[6, 4] = 0;
            set3_test[6, 5] = 0;
            set3_test[6, 6] = 0;
            set3_test[6, 7] = 1;
            set3_test[6, 8] = 0;

            set3_test[7, 0] = 0;
            set3_test[7, 1] = 0;
            set3_test[7, 2] = 0;
            set3_test[7, 3] = 0;
            set3_test[7, 4] = 6;
            set3_test[7, 5] = 0;
            set3_test[7, 6] = 5;
            set3_test[7, 7] = 2;
            set3_test[7, 8] = 3;

            set3_test[8, 0] = 1;
            set3_test[8, 1] = 0;
            set3_test[8, 2] = 2;
            set3_test[8, 3] = 0;
            set3_test[8, 4] = 0;
            set3_test[8, 5] = 9;
            set3_test[8, 6] = 0;
            set3_test[8, 7] = 8;
            set3_test[8, 8] = 0;
        }



    }
}
