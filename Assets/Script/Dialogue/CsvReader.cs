using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class CsvReader : MonoBehaviour
{
    [SerializeField] private TextAsset dialogueFile;
    [SerializeField] public List<string> Dielogues_eng;
    [SerializeField] public List<string> Dielogues_chi;
    [SerializeField] private List<DialogueData> Dielogues_datalist = new();
    public class DialogueData
    {
        public string ID;
        public string chinese;
        public string english;
    }
    public class DialogueDataChi
    {
        public string ID;
        public string chinese;
    }
    public class DialogueDataEng
    {
        public string ID;
        public string english;
    }


    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ReadCSV()
    {
        Debug.Log("ReadCSV!!!!");

        string[] dialogues = dialogueFile.text.Split('\n');
        foreach (string line in dialogues.Skip(1))
        {
            string[] values = SplitCsvLine(line);
            if (values.Length == 3)
            {
                DialogueData data = new DialogueData
                {
                    ID = values[0].Trim(),
                    chinese = values[1].Trim(),
                    english = values[2].Trim()
                };
                Dielogues_datalist.Add(data);
                Debug.Log("read line : " + line);
            }
            else
            {
                Debug.LogWarning("Skipping line with incorrect format: " + line);
            }
        }

        Dielogues_eng = Dielogues_datalist.Select(data => $"{data.english}").ToList();
        Dielogues_chi = Dielogues_datalist.Select(data => $"{data.chinese}").ToList();
    }
    private string[] SplitCsvLine(string line)
    {
        List<string> values = new List<string>();
        bool inQuotes = false;
        string currentValue = "";
        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                values.Add(currentValue);
                currentValue = "";
            }
            else
            {
                currentValue += c;
            }
        }
        values.Add(currentValue);
        return values.ToArray();
    }
}
