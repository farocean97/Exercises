using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryFileWriteRead
{
    class Program
    {
        static void Main(string[] args)
        {
            string strcsvfile = "D:\\Archive\\Pressure.csv";
            string strbinfile = "D:\\Archive\\Pressure.dat";
            string strcsv_converted = "D:\\Archive\\PressureConverted.csv";
            bool BintoCsv = true;

            if (!BintoCsv)
            {
                BinaryFileConvert bc = new BinaryFileConvert(strcsvfile, strbinfile);
                bc.ConvertCSVtoBinary();
            }
            else
            {
                BinaryFileConvert bc2 = new BinaryFileConvert(strcsv_converted, strbinfile);
                bc2.ConvertBinarytoCSV();
            }



            Console.WriteLine("Conversion is completed!");

            Console.ReadLine();

        }
    }
}
