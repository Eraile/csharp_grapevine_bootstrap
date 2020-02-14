using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapWindowsFormsApp
{
    public class GrapevineBootstrapSampleData
    {
        // Variables
        public string Name
        {
            get
            {
                return "Star Wars - Character List";
            }
        }
        //
        public List<string> Headers
        {
            get
            {
                return new List<string>()
                {
                    "Name",
                    "Height",
                    "Mass",
                    "Hair Color",
                    "Skin Color",
                    "Eye Color",
                    "Birth Year",
                    "Gender",
                };
            }
        }
        //
        public List<List<string>> __data = new List<List<string>>();
        public List<List<string>> Data
        {
            get
            {
                return this.__data;
            }
        }

        // Constructor / Init
        public GrapevineBootstrapSampleData()
        {
            this.InitSampleData();
        }

        public void InitSampleData()
        {
            List<string> dataA = new List<string>()
            {
                "Luke Skywalker",
                "172",
                "77",
                "Blond",
                "Fair",
                "Blue",
                "19",
                "Male",
            };
            List<string> dataB = new List<string>()
            {
                "Z-6PO",
                "167",
                "75",
                "N/A",
                "Gold",
                "Yellow",
                "112",
                "N/A",
            };
            List<string> dataC = new List<string>()
            {
                "R2-D2",
                "96",
                "32",
                "N/A",
                "White, Blue",
                "Red",
                "33",
                "N/A",
            };
            //
            List<List<string>> datas = new List<List<string>>();
            datas.Add(dataA);
            datas.Add(dataB);
            datas.Add(dataC);
            //
            this.__data = datas;
        }

        // parse
        public string ParseLine(string line)
        {
            string lineContent = line;
            if (lineContent.Contains("{DATASET") == true)
            {
                // TABLE : Values
                if (lineContent.Contains("{DATASET_SAMPLE_VALUES}") == true)
                {
                    // content 
                    string tableContent = "";

                    // Go through the data
                    List<List<string>> sampleData = this.Data;
                    for (int j = 0; j < sampleData.Count; j++)
                    {
                        tableContent += "<tr>" + "\n";
                        for (int k = 0; k < sampleData[j].Count; k++)
                        {
                            tableContent += "<td>" + sampleData[j][k] + "</td>" + "\n";
                        }
                        tableContent += "</tr>" + "\n";
                    }

                    // Replace
                    lineContent = lineContent.Replace("{DATASET_SAMPLE_VALUES}", tableContent);
                }

                // TABLE : Header / Footer
                if (lineContent.Contains("{DATASET_SAMPLE_HEADER}") == true || lineContent.Contains("{DATASET_SAMPLE_FOOTER}") == true)
                {
                    // content 
                    string headersContent = "";

                    // Go through each header
                    List<string> headers = this.Headers;
                    for (int j = 0; j < headers.Count; j++)
                    {
                        headersContent += "<th>" + headers[j] + "</th>" + "\n";     // add break line at the end
                    }

                    // Replace
                    lineContent = lineContent.Replace("{DATASET_SAMPLE_HEADER}", headersContent);
                    lineContent = lineContent.Replace("{DATASET_SAMPLE_FOOTER}", headersContent);
                }

                // TABLE : Name
                if (lineContent.Contains("{DATASET_SAMPLE_NAME}") == true)
                {
                    // Replace
                    lineContent = lineContent.Replace("{DATASET_SAMPLE_NAME}", this.Name);
                }
            }

            return lineContent;
        }
    }
}
