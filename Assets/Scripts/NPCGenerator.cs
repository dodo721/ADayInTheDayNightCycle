using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCGenerator : MonoBehaviour
{

    [Header("Characters")]
    public GameObject[] adventurers;
    public int numAdventurersPerDay;
    public GameObject[] npcs;
    public int numNpcsPerDay;
    public GameObject[] oneLiners;
    public int numOneLinersPerDay;
    private int currentIdx = 0;

    [HideInInspector]
    public int numCharacters;
    [HideInInspector]
    public int cycles = 0;

    public float progress = 0;
    public float progressLerpSpeed = 1;
    private float lerpTime = 0;
    public bool lerping = false;

    private GameObject currentAdventurer;

    [Header("UI")]
    public EndStateDisplay endStateDisplay;
    public GameObject endStatePanel;

    [Header("Music")]
    public AudioSource musicPlayer;
    public AudioClip loseMusic;
    public AudioClip midMusic;
    public AudioClip winMusic;
    public AudioClip footsteps;

    // Start is called before the first frame update
    void Start()
    {
        reshuffle();
    }

    // Update is called once per frame
    void Update()
    {
        float currentProgress = (float)cycles / (float)numCharacters;
        float prevProgress = (float)(cycles - 1) / (float)numCharacters;
        progress = Mathf.Lerp(prevProgress, currentProgress, lerpTime);
        lerpTime += Time.deltaTime * progressLerpSpeed;
        if (lerpTime >= 1) lerping = false;
    }

    public void CycleNPC () {
        if (currentIdx >= adventurers.Length) {
            EndGame();
            return;
        }
        if (currentAdventurer) Destroy(currentAdventurer);
        GameObject adventurer = adventurers[currentIdx];
        currentIdx++;
        currentAdventurer = Instantiate(adventurer, transform.position, adventurer.transform.rotation, transform);
        currentAdventurer.GetComponent<Adventurer>().spawner = this;
        cycles++;
        lerpTime = 0;
        lerping = true;
        musicPlayer.PlayOneShot(footsteps);
    }

    void EndGame () {
        int score = DialogueLua.GetVariable("Score").asInt;
        int maxScore = numAdventurersPerDay * 3;
        int thresholdStep = (maxScore * 2) / 3;
        int loseThreshold = thresholdStep - maxScore;
        int midThreshold = (thresholdStep * 2) - maxScore;
        int winThreshold = (thresholdStep * 3) - maxScore;
        string endState = "none";
        AudioClip endMusic = null;
        if (score <= loseThreshold) {
            endState = "lose";
            endMusic = loseMusic;
        } else if (score <= midThreshold) {
            endState = "mid";
            endMusic = midMusic;
        } else {
            endState = "win";
            endMusic = winMusic;
        }
        endStateDisplay.DisplayEndState(endState);
        endStatePanel.SetActive(true);
        musicPlayer.clip = endMusic;
        musicPlayer.time = 0;
        musicPlayer.Play();
    }

    void reshuffle()
    {
        adventurers = shuffleArray(adventurers);
        npcs = shuffleArray(npcs);
        oneLiners = shuffleArray(oneLiners);

        int totalChars = numAdventurersPerDay + numNpcsPerDay + numOneLinersPerDay;
        GameObject[] newArr = new GameObject[totalChars];
        for (int i = 0; i < numAdventurersPerDay; i++) {
            newArr[i] = adventurers[i];
        }

        newArr = shuffleArray(newArr);

        int npcIdx = 0;
        for (int i = 0; i < totalChars; i++) {
            if (newArr[i] == null) {
                if (npcIdx >= numNpcsPerDay) break;
                newArr[i] = npcs[npcIdx];
                npcIdx++;
            }
        }

        newArr = shuffleArray(newArr);

        npcIdx = 0;
        for (int i = 0; i < totalChars; i++) {
            if (newArr[i] == null) {
                newArr[i] = oneLiners[npcIdx];
                npcIdx++;
            }
        }

        adventurers = newArr;
        numCharacters = totalChars;
    }

    GameObject[] shuffleArray (GameObject[] array) {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < array.Length; t++ )
        {
            GameObject tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
        return array;
    }
}
