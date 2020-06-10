using FPSControllerLPFP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] enemyScript enemy = null;
    [SerializeField] enemyScript subEnemy = null;
    [SerializeField] FpsControllerLPFP player = null;
    [SerializeField] sunscript sun = null;
    [SerializeField] Transform[] _destinations = null;
    [SerializeField] GameObject prefab = null;

    public int nightCount = 0;
    bool countOnce = false;
    bool lastDialogue = false;
   
    // Start is called before the first frame update
    void Start()
    {
        enemy.setPlayer(player);
        for (int i = 0; i < _destinations.Length; i++)
        {
            enemy.setDestinations(i, _destinations[i]);
        }
        subEnemy.setPlayer(player);
        for (int i = 0; i < _destinations.Length; i++)
        {
            subEnemy.setDestinations(i, _destinations[i]);
        }
        subEnemy.transform.position = this.transform.position;
        enemy.isActing = true;
        subEnemy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < 5.0f)       //일정 거리 이내일때 공격애니메이션 실행과 플레이거 hp감소
        {

            enemy.AttackTarget(player.transform);
            enemy.damage(ref player.Hp);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) >= 3.0f && Vector3.Distance(player.transform.position, enemy.transform.position) < 10.0f)
            enemy.StopAttack();
        if (sun.isNight)
        {
            if (!countOnce)
            {
                nightCount++;
                countOnce = true;
               
            }
            if (nightCount == 2)
            {
                
                subEnemy.gameObject.SetActive(true);
                subEnemy.isActing = true;
                if (Vector3.Distance(player.transform.position, subEnemy.transform.position) < 5.0f)
                {
                    subEnemy.AttackTarget(player.transform);
                    subEnemy.damage(ref player.Hp);
                }
                else if (Vector3.Distance(player.transform.position, subEnemy.transform.position) >= 3.0f && Vector3.Distance(player.transform.position, subEnemy.transform.position) < 10.0f)
                    subEnemy.StopAttack();
            }
            if (nightCount == 3&&player._isChecked==false)
                player._ShowDialogue();

        }
        else
            countOnce = false;
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if(enemy.alive)
                enemy.SetTarget(other.transform);           
        }
        if(sun.isNight)
        {
            if (other.name == "Player")
            {
                if (subEnemy.alive)
                    subEnemy.SetTarget(other.transform);
            }
        }
    

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            enemy.RemoveTarget();
        if(sun.isNight)
        {
            if (other.name == "Player")
                subEnemy.RemoveTarget();

        }
    }
}
