using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{

    public GameObject[] adventurers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNPC () {
        GameObject adventurer = adventurers[Random.Range(0, adventurers.Length)];
        Instantiate(adventurer, transform.position, adventurer.transform.rotation);
    }
}
