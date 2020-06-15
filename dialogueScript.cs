using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueScript : MonoBehaviour
{
    [SerializeField] Image Panel;       //페이드인 효과
    float currentTime = 0;
    float fadeoutTime = 4;

    

    IEnumerator fadeIn()
    {
        Panel.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Color alpha = Panel.color;
        while (alpha.a >0)      //알파값 조정으로 주는 화면이 밝아지는 효과
        {
            currentTime += Time.deltaTime / fadeoutTime;
            alpha.a = Mathf.Lerp(1, 0, currentTime);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
    }

    [SerializeField] SpriteRenderer spriteStandingCG;
    [SerializeField] SpriteRenderer spriteDialogue;
    [SerializeField] Text txt;

    bool isTalking=false;       //대화 진행 여부를 알려주는 변수
    int dialogueCount=0;        //대화 진행 상황을 알려주는 변수

    [SerializeField] Dialogue[] dialogues;



    public void showDialogue()
    {
        //대화가 시작되면 이미지,대화창,대화 보이게 설정
        spriteDialogue.gameObject.SetActive(true);
        spriteStandingCG.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);

        //대화 시작 설정
        
        isTalking = true;
        NextDialogue();
    }

    void NextDialogue()
    {
        txt.text = dialogues[dialogueCount++].dialogue;
    }
    void HideDialogue()         //대화끝나면 이미지와 텍스트 숨겨줄 함수
    {
        spriteDialogue.gameObject.SetActive(false);
        spriteStandingCG.gameObject.SetActive(false);
        txt.gameObject.SetActive(false);
        isTalking = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn());
        showDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTalking)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if (dialogueCount < dialogues.Length)
                    NextDialogue();
                else
                    HideDialogue();
            }
        }
    }
}


[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;

}
