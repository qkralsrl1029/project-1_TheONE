using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Image Panel;     //페이드 아웃용 검은 화면
    float currentTime = 0;
    float fadeoutTime = 2;


    public void gotostart()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void gotoplay()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void gotoexplain()
    {
        SceneManager.LoadScene("ExplainScene");
    }

    public void gotoexplain_2()
    {
        SceneManager.LoadScene("ExplainScene_2");
    }

    public void gotostory()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void FadeOut()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a<1)
        {
            currentTime += Time.deltaTime / fadeoutTime;
            alpha.a = Mathf.Lerp(0, 1, currentTime);
            Panel.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("PlayScene");
    }
   
}
