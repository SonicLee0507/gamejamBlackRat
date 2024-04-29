using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] CsvReader csvReader;
    [SerializeField] GameControl gameControl;

    [SerializeField] private List<string> Dielogues_eng;
    [SerializeField] private List<string> Dielogues_chi;

    [SerializeField] private TextMeshProUGUI dialogue;

    [SerializeField] public int line;




    // Start is called before the first frame update
    void Start()
    {
        //Dielogues_eng = csvReader.Dielogues_eng.ToList();
        //Dielogues_chi = csvReader.Dielogues_chi.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        ReadStory();
    }

    public void ReadStory()
    {
        if (gameControl.isEng == true)
        {
            dialogue.text = csvReader.Dielogues_eng[line];
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                line += 1;
                dialogue.text = csvReader.Dielogues_eng[line];
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                line += 3;
                dialogue.text = csvReader.Dielogues_eng[line];
                return;
            }

        }
            else
            {
                dialogue.text = csvReader.Dielogues_chi[line];
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
                {
                    line += 1;
                    dialogue.text = csvReader.Dielogues_chi[line];
                    return;
                }


            }

        


    }
}
