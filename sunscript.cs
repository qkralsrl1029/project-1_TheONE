using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunscript : MonoBehaviour
{
    [SerializeField] float secondPerRealtime; //현실시간 대비 게임 내 시간 설정
    [SerializeField] float nightFog;        //밤ㅢ 안개량
    [SerializeField] float fogCalc;         //실시간 계산량
    private float dayFog;                   //낮의 안개량
    private float currentFog;               //현재 안개량
    public bool isNight = false;
    [SerializeField] Material[] _sky = new Material[15];
   

    // Start is called before the first frame update
    void Start()
    {
        
        dayFog = RenderSettings.fogDensity;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.right,0.1f*secondPerRealtime*Time.deltaTime);
        if (transform.eulerAngles.x >= 180)
            isNight = true;
        else if (transform.eulerAngles.x <= 5)
            isNight = false;

        //밤일때
        if (isNight)
        {
            RenderSettings.skybox = _sky[15];
            //기본 설정 안개량보다 작을때만
            if (currentFog<=nightFog)
            {
               //안개량 증가(시간대비)
                //currentFog += 0.1f * fogCalc * Time.deltaTime;
                //RenderSettings.fogDensity = currentFog;
            }
        }
        else
        {
            if (transform.eulerAngles.x >5&& transform.eulerAngles.x<=15)
                RenderSettings.skybox = _sky[0];
            else if (transform.eulerAngles.x > 16&& transform.eulerAngles.x<=26)
                RenderSettings.skybox = _sky[1];
            else if (transform.eulerAngles.x >27&& transform.eulerAngles.x<=37)
                RenderSettings.skybox = _sky[2];
            else if (transform.eulerAngles.x > 38 && transform.eulerAngles.x <= 48)
                RenderSettings.skybox = _sky[3];
            else if (transform.eulerAngles.x > 49 && transform.eulerAngles.x <= 59)
                RenderSettings.skybox = _sky[4];
            else if (transform.eulerAngles.x > 60 && transform.eulerAngles.x <= 70)
                RenderSettings.skybox = _sky[5];
            else if (transform.eulerAngles.x > 71 && transform.eulerAngles.x <= 81)
                RenderSettings.skybox = _sky[6];
            else if (transform.eulerAngles.x > 92 && transform.eulerAngles.x <= 102)
                RenderSettings.skybox = _sky[7];
            else if (transform.eulerAngles.x > 103 && transform.eulerAngles.x <= 113)
                RenderSettings.skybox = _sky[8];
            else if (transform.eulerAngles.x > 114 && transform.eulerAngles.x <= 124)
                RenderSettings.skybox = _sky[9];
            else if (transform.eulerAngles.x > 125 && transform.eulerAngles.x <= 135)
                RenderSettings.skybox = _sky[10];
            else if (transform.eulerAngles.x > 136 && transform.eulerAngles.x <= 146)
                RenderSettings.skybox = _sky[11];
            else if (transform.eulerAngles.x > 147 && transform.eulerAngles.x <= 157)
                RenderSettings.skybox = _sky[12];
            else if (transform.eulerAngles.x > 158 && transform.eulerAngles.x <= 168)
                RenderSettings.skybox = _sky[13];
            else if (transform.eulerAngles.x > 169 && transform.eulerAngles.x <= 179)
                RenderSettings.skybox = _sky[14];
            if (currentFog >= dayFog)
            {
            //    //안개 걷히게
            //    currentFog -= 0.1f * fogCalc * Time.deltaTime;
            //    RenderSettings.fogDensity = currentFog;
            }
        }
    }
}
