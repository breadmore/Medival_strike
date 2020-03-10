using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameMgr GM;
    public Unit Target;
    public PhotonInit photonInit;
    public Animator anim;

    public float Dmg;
    public float Hp;

    #region Private Fields
    bool MasterPlayer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        MasterPlayer = GM.MasterPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2.0f * Time.deltaTime, 0, 0);
        if (!MasterPlayer)
        {
            transform.rotation=Quaternion.Euler(0, 180.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target = collision.GetComponent<Unit>();
        if(collision.transform.tag == "Enemy")
        {
            anim.SetBool("IsAttack", true);
        }
    }

    public void Attack()
    {
        Target.Hp -= Dmg;
        if(Target.Hp <= 0)
        {
            anim.SetBool("IsAttack", false);
            Destroy(Target.gameObject);
        }
    }
}
