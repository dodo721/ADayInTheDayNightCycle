using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ResponseRandomizer : MonoBehaviour
{
    void OnConversationResponseMenu(Response[] responses)
    {
        int n = responses.Length; // Standard Fisher-Yates shuffle algorithm.
        for (int i = 0; i < n; i++)
        {
            int r = i + Random.Range(0, n - i);
            Response temp = responses[r];
            responses[r] = responses[i];
            responses[i] = temp;
        }
    }
}
