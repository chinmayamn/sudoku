using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class revamped
    {
        //testdata
        //  xsetdata(0,2,0, 2);
          //   xsetdata(0,2, 6, 8);
         //    xsetdata(0, 2, 3, 5);

         //    ysetdata(0, 8, 0, 0);
        int[,] a = new int[0,8];
               public void xsetdata(int xindex,int xend, int ystarting, int yindex)
         {
             int v = 1;
             for (int i = xindex; i <= xend; i++)
             {
                 for (int j = ystarting; j <= yindex; j++)
                 {
                     a[i, j] = v;
                     v++;
                 }

             }
         }
         public void ysetdata(int xindex, int xend, int ystarting, int yindex)
         {
             int v = 1;
             for (int i = xindex; i <= xend; i++)
             {
                 for (int j = ystarting; j <= yindex; j++)
                 {
                     a[i, j] = v;
                     v++;
                 }

             }
         }
    }
}
