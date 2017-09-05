using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace BinaryFileWriteRead
{
    public class BinaryFileConvert
    {
        public string strCSVFile { get; set; }
        public string strBinaryFile { get; set; }


        public BinaryFileConvert(string csvfile, string binaryfile)
        {
            strCSVFile = csvfile;
            strBinaryFile = binaryfile;
        }

        public void ConvertCSVtoBinary()
        {
            if(File.Exists(strBinaryFile)) {
                File.Delete(strBinaryFile);
            }
            using (BinaryWriter bw = new BinaryWriter(new FileStream(strBinaryFile,FileMode.Create))) {
                using (TextFieldParser parser = new TextFieldParser(strCSVFile))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        int intTime = Convert.ToInt32(fields[0]);
                        double p1 = Convert.ToDouble(fields[1]);
                        double p2 = Convert.ToDouble(fields[2]);

                        bw.Write(intTime);
                        bw.Write(p1);
                        bw.Write(p2);
                    }
                }
            
            }

        }

        public void ConvertBinarytoCSV()
        {
            using (BinaryReader br = new BinaryReader(new FileStream(strBinaryFile, FileMode.Open)))
            {
                
                using (StreamWriter sw = new StreamWriter(strCSVFile,false))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        int inTime = br.ReadInt32();
                        double p1 = br.ReadDouble();
                        double p2 = br.ReadDouble();
                        sw.WriteLine("{0},{1},{2}", inTime, p1, p2);
                    }
                }

            }

        }

    }
}
