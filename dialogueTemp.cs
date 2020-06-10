using FPSControllerLPFP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTemp : MonoBehaviour
{
    [SerializeField]
    FpsControllerLPFP player;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (player._isChecked)
            this.gameObject.SetActive(false);
    }
}
