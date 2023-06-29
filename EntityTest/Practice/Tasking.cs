using Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Practice
{


    public class Tasking
    {
         
        public async Task LongTask()
        {
            short counter = 0;
            while (counter < short.MaxValue)
            {
                await Task.Delay(1000);
                Console.WriteLine(counter.ToString());
                counter++;
            }
  
        }



   


    }

   

}



