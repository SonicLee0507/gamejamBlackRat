using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] CsvReader csvReader;
    [SerializeField] public bool isbattle = false;
    [SerializeField] public bool isEng = true;
    [SerializeField] public bool isStory = true;

    [SerializeField] private GameObject DialoguePage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isbattle == false & isStory == true)
        {
            startStory();

        }

        //for testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            isStory = true;
            isbattle = false;
        }

    }
    void startStory()
    {
        DialoguePage.SetActive(true);
        if (dialogue.line == 8 || dialogue.line == 29 || dialogue.line == 37 ||
            dialogue.line == 42 || dialogue.line == 52 || dialogue.line == 58 || dialogue.line == 65
             || dialogue.line == 69 || dialogue.line == 75)
        {
            DialoguePage.SetActive(false);
            if (dialogue.line != 75)
            {
            dialogue.line += 1;
            }

            isStory = false;
            isbattle = true;
            return;
        }
        else
        {
            Debug.Log("wait");
        }
    }
}
