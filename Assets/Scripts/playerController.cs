using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Touch theTouch;
    public float thrust = 10f;
    public Rigidbody2D rigidbody;
    bool onceDo = false;
    bool rotateOnce = true;
    public Text score;
    int scoreValue;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        Gameplay();
    }


    void Gameplay()
    {
        if(Input.touchCount>0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("test");
                if(!onceDo)
                {
                    rigidbody.velocity = Vector2.up * thrust;
                    onceDo=true;
                    //transform.Rotate(Vector3.forward * 45);
                    transform.rotation = Quaternion.Euler(0,0,45);
                    rotateOnce=true;
                }
                
            }
            
        }
        onceDo=false;
        if(rigidbody.velocity.y < 0)
        {
            if(rotateOnce)
            {
                //transform.Rotate(Vector3.forward * 45);
                transform.rotation = Quaternion.Euler(0,0,-45);
                rotateOnce=false;
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        gameOver=true;
        transform.rotation = Quaternion.Euler(0,0,-45);
        rigidbody.freezeRotation = true;
        rigidbody.velocity = Vector2.up * thrust;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    }
    void OnTriggerExit2D(Collider2D triggerCol)
    {
        if(triggerCol.transform.tag == "goal")
        {
            scoreValue++;
            score.text = (scoreValue/2).ToString();
        }

    }
}
