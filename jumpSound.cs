using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpSound : MonoBehaviour
{
    private AudioSource theAudio;
    [SerializeField] private AudioClip[] clip;

    int temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            temp = Random.Range(0, 4);
            theAudio.clip = clip[temp];
            theAudio.Play();
        }
    }
}
