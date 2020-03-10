using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Barrack : MonoBehaviour
{
    public bool IsAwake;
    public float startTime = 0;
    public int Life { get; set; }

    public GameObject Unit;
    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
    }


    public void CreateUnit()
    {
        if (IsAwake)
        {
            Instantiate(Unit, transform.position, transform.rotation);
            --Life;
        }
    }

    public void SleepBarrack()
    {
        if (Life <= 0)
        {
            IsAwake = false;
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
