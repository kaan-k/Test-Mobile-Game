using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject[] activeObsticles;
    public GameObject[] activegroundDirts;
    public string active_Obsticles;
    public GameObject Obsticle;
    public GameObject groundDirt;
    Vector3 instantiate;
    Vector3 instantiateDirt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instantiate = new Vector3(35f,Random.RandomRange(-1.20f,1f),0f);
        activeObsticles = GameObject.FindGameObjectsWithTag("obsticle");

        activegroundDirts = GameObject.FindGameObjectsWithTag("dirt");
        instantiateDirt = new Vector3((activegroundDirts[0].transform.position.x+8f),-4.7f,0f);
        Debug.Log(activegroundDirts[0].transform.position.x);

        if(activeObsticles.Length < 8)
        {
            
            Instantiate(Obsticle,instantiate,Quaternion.identity);
        }
        if(activegroundDirts.Length < 3)
        {
            Instantiate(groundDirt,instantiateDirt,Quaternion.identity);
        }
    }
}
