using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStateDisplay : MonoBehaviour
{

    public Text titleText;
    public Text subTitleText;

    [Header("Titles")]
    public string winTitle;
    public string midTitle;
    public string loseTitle;

    [Header("Descriptions")]
    public string winDesc;
    public string midDesc;
    public string loseDesc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayEndState (string endState) {
        if (endState == "win") {
            titleText.text = winTitle;
            subTitleText.text = winDesc;
        } else if (endState == "mid") {
            titleText.text = midTitle;
            subTitleText.text = midDesc;
        } else if (endState == "lose") {
            titleText.text = loseTitle;
            subTitleText.text = loseDesc;
        } else {
            Debug.LogError("Unknown end state?? " + endState);
        }
    }

}
