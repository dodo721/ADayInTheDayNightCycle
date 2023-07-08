using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{

    public GameObject[] adventurers;
    private int currentIdx = 0;

    private GameObject currentAdventurer;

    public bool test;
    public int testIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (!test) reshuffle();
        CycleNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if (test) Debug.LogError("TEST IS ON TURN IT THE FUCK OFFFFFF!!!!!");
    }

    public void CycleNPC () {
        if (test) currentIdx = testIndex;
        if (currentIdx >= adventurers.Length) return;
        if (currentAdventurer) Destroy(currentAdventurer);
        GameObject adventurer = adventurers[currentIdx];
        currentIdx++;
        currentAdventurer = Instantiate(adventurer, transform.position, adventurer.transform.rotation, transform);
        currentAdventurer.GetComponent<Adventurer>().spawner = this;
    }

    void reshuffle()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < adventurers.Length; t++ )
        {
            GameObject tmp = adventurers[t];
            int r = Random.Range(t, adventurers.Length);
            adventurers[t] = adventurers[r];
            adventurers[r] = tmp;
        }
    }
}
