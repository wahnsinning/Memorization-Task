using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // to write to files
using System;

public class WriteCSV : MonoBehaviour
{
	string filename = ""; // filename of the csv
	public int cnt = 0;
	
    // Start is called before the first frame update
    void Start()
    {
		// generate filename: datapath, the Data folder + a uid that we generate here
        filename = Application.dataPath + "/Data/" + Guid.NewGuid() + ".csv";
    }

	public void MakeCSV(List<string> data, string[] words, string header)
	{
		Debug.Log("saving...");
		TextWriter csvFile = new StreamWriter(filename, false);
		csvFile.WriteLine(header);

		for (int i = 0; i < data.Count; i++)
		{
			// Split the data row by comma
			string[] rowData = data[i].Split(',');

			// Write the first column of the row
			csvFile.Write(rowData[0]);
			
			// Write a comma separator
			csvFile.Write(",");

			// Write the word from the array for this row
			if (i < words.Length)
			{
				csvFile.WriteLine(words[i]);
			}
			else
			{
				csvFile.WriteLine(""); // Write empty string if no word available
			}

			Debug.Log("csv ready!");
		}

    	csvFile.Close();
	}

}

