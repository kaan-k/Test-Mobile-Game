using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleScript : MonoBehaviour
{
    public Collider2D[] Colls;
    public GameObject Eplayer;
    public float movespeed;
    void Start()
    {
        Colls = gameObject.GetComponentsInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Eplayer == null)
        {
            Eplayer = GameObject.FindGameObjectWithTag("Player");
        }
        if(Eplayer.GetComponent<playerController>().gameOver != true)
        {
            transform.position = new Vector3(transform.position.x + movespeed,transform.position.y);
        }
        else
        {
            foreach(Collider2D c in Colls)
            {
                c.enabled = false;
            }
        }
        
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "test")
        {
            Debug.Log("destroy");
            Destroy(this.gameObject);
        }
    }

}
