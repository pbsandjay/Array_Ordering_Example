using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyArrayNamespace
{
    public abstract class MyArray
    {
        StreamReader ezmoney;
        protected int[] intArray;          //saves integers
        protected int actualSize;         //indicates the actual number of integers saved
        protected const int MAXSIZE = 1000;


        public MyArray()


        {
            //initialization
            intArray = new int[MAXSIZE];
            actualSize = 0;
        }

        //add item to the end
        //f) throw a FullArrayListException if actualSize+1 is greater than MAXSIZE (DONE)
        public virtual void Insert(int item)
        {


            if (actualSize + 1 > MAXSIZE)
            {
                throw new FullArrayListException("The array is full");
            }
            intArray[actualSize] = item;
            actualSize++;
            /*

                for (int i = 1001; i > actualSize; i++)
                {
                    if (actualSize >= MAXSIZE)
                    {
                        intArray[i] = intArray[actualSize + 1];
                        actualSize++;
                        break;
                    }
                }
            */

        }





        //delete item, then use the last element to replace the deleted item 
        //g) throw an EmptyArrayListException if the intArray is empty (DONE)
        public virtual void Remove(int item)



        {

            if (actualSize == 0)
            {
                throw new EmptyArrayListException("Empty");
            }
            for (int i = 0; i < actualSize; i++)
            {
                if (item == intArray[i])
                {

                    intArray[i] = intArray[actualSize - 1];
                    actualSize--;
                    break;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < actualSize; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }



        virtual public void FillArrayfromFile(string fLocation)
        {
            ezmoney = new StreamReader(fLocation);
            string eachline = "";
            while ((eachline = ezmoney.ReadLine()) != null)
            {
                eachline = eachline.Replace(";", "");
                int inteachline = int.Parse(eachline);
                Insert(inteachline);
            }
            ezmoney.Close();
        }

    
        //c) Add a virtual method FillArrayfromFile(string fileLocation) (DONE)





        //e) Add an abstract method RemoveAll() 
        public abstract void RemoveAll();

    }//end of class

    public class FullArrayListException : ApplicationException
    {
        public FullArrayListException(string message) : base(message)
            {}
    }
    public class EmptyArrayListException: ApplicationException
    {
        public EmptyArrayListException(string message) : base(message)
            {}
    }
}

