using FPSControllerLPFP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  //네비게이션 컴퍼넌트를 사용하기위한 네임스페이스
public class enemyScript : MonoBehaviour
{
    NavMeshAgent agent=null;
    [SerializeField] Transform[] destinations=null;
    int m_count = 0;
    Transform m_target = null;
    Animator anim;
    [SerializeField] FpsControllerLPFP player = null;
    public float _mosterHp = 100;
    public bool alive = true;
    public bool isActing = false;       //hp와 별개로 setactive true일때만 실행가능하도록 만든 변수. 안쓰면 navmesh 오류남 ㅠㅠ
    float deathCount = 0;       //죽으면 일정 시간 카운트 후 사라지게함
    private AudioSource theAudio;
    [SerializeField] private AudioClip clip;
    


    public void setDestinations(int i, Transform dst)
    {
        destinations[i] = dst;
    }
    public void setPlayer(FpsControllerLPFP _plyer)
    {
        player = _plyer;
    }
    //[SerializeField] float m_angle = 0f;
    //[SerializeField] float m_distance = 0f;
    //[SerializeField] LayerMask m_layer = 0;

    //void sight()
    //{
    //    Collider[] t_cols = Physics.OverlapSphere(this.transform.position, m_distance, m_layer);

    //    if(t_cols.Length>0)
    //    {
    //        Transform t_tfPlayer = t_cols[0].transform;
    //        Vector3 t_direction = (t_tfPlayer.position - this.transform.position).normalized;
    //        float t_angle = Vector3.Angle(t_direction, transform.forward);
    //        if(t_angle<m_angle*0.5f)
    //        {
    //            if(Physics.Raycast(transform.forward,t_direction,out RaycastHit t_hit,m_distance))
    //            {
    //                if (t_hit.transform.name == "Player")
    //                {
    //                    Debug.Log("tt");
    //                    SetTarget(t_hit.transform);
    //                }
    //            }
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "bullet")
            _mosterHp -= 30;
    }
    public void AttackTarget(Transform p_target)
    {
        anim.SetBool("is_inattackRange", true);
       
    }
    public void StopAttack()
    {
        anim.SetBool("is_inattackRange", false);
    }
    public void SetTarget(Transform p_target)
    {        
        CancelInvoke();
        anim.SetBool("has_detected", true);
        agent.speed = 10.0f;
        m_target = p_target;
        if(alive)
            theAudio.Play();
    }
    public void damage(ref float hp)
    {
        if(alive) 
            hp -= 0.3f;          
    }
    public void SetDestination(Transform p,int i)
    {
        destinations[i] = p;
    }

    public void remove()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void RemoveTarget()
    {
        m_target = null;
        anim.SetBool("has_detected", false);
        agent.speed = 3.5f;
        InvokeRepeating("MoveToNextPoint", 0f, 0.1f);
    }
    void MoveToNextPoint()
    {
        if (alive&&isActing)
        {
            if (m_target == null)
            {
                if (agent.velocity == Vector3.zero)
                {
                    agent.SetDestination(destinations[m_count++].position);
                    if (m_count >= destinations.Length)
                        m_count = 0;
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        InvokeRepeating("MoveToNextPoint", 0f, 0.1f);
        theAudio = GetComponent<AudioSource>();
        theAudio.clip = clip;
    }
    void death()
    {
        CancelInvoke();
        alive = false;
        deathCount += Time.deltaTime/15;
        if (deathCount > 1)
            this.gameObject.SetActive(false);
        anim.SetBool("getAttacked",true);
        agent.SetDestination(this.transform.position);      //죽으면 그자리에서 사망 애니메이션 실행
    }
    // Update is called once per frame
    void Update()
    {
        if (_mosterHp < 0)
        {
            death();         
        }
        if (alive)
        {
            if (m_target != null)            
                agent.SetDestination(m_target.position);           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (alive)
        {
            if (other.name == "Player")
            {
                SetTarget(other.transform);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (alive)
        {
            if (other.name == "Player")
                RemoveTarget();
        }
    }

}
