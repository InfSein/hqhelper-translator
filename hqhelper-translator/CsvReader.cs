using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hqhelper_translator;

public static class CsvReader
{
    public static List<string[]> ReadCsv(string filePath, Encoding? encoding = null, char delimiter = ',')
    {
        List<string[]> lines = new();
        encoding ??= Encoding.UTF8;

        using (StreamReader sr = new StreamReader(filePath, encoding))
        using (TextFieldParser parser = new TextFieldParser(sr))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(delimiter.ToString());

            while (!parser.EndOfData)
            {
                string[]? fields = parser.ReadFields();

                if (fields != null)
                {
                    lines.Add(fields);
                }
            }
        }


        return lines;
    }
}
