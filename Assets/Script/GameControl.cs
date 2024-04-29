using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    [SerializeField] CameraControl cameraControl;
    [SerializeField] PlayerControl playerControl;
    [SerializeField] Dialogue dialogue;
    [SerializeField] CsvReader csvReader;
    [SerializeField] public bool isbattle = false;
    [SerializeField] public bool isEng = true;
    [SerializeField] public bool isStory = true;


    [SerializeField] private AudioSource bgm;
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            cameraControl.PlayerShakeAnimation();
        }

    }
    void startStory()
    {
        DialoguePage.SetActive(true);
        if (dialogue.line == 7 || dialogue.line == 28 || dialogue.line == 36 ||
            dialogue.line == 41 || dialogue.line == 51 || dialogue.line == 57 || dialogue.line == 64
             || dialogue.line == 68 || dialogue.line == 75)
        {
            DialoguePage.SetActive(false);
            if (dialogue.line != 75)
            {
            dialogue.line += 1;
            }

            isStory = false;
            Debug.Log("isStory");
            playerControl.MoveToNextStage();
            //isbattle = true;
            return;
        }
        else
        {
            //Debug.Log("wait");
        }
    }



}
