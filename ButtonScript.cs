using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

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
   
}
