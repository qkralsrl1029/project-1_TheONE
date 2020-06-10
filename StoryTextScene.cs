using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextScene : MonoBehaviour
{
    [SerializeField]
    Text storytext;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        storytext.rectTransform.Translate(Vector3.up*Time.deltaTime*20);
    }
}
