
using UnityEngine;
using UnityEngine.Audio;

public class Canon : MonoBehaviour {

    public Transform firepoint;
    public GameObject canonballprefab;
    public GameObject smokecloud;
    GameObject canonball;
    public float cannonForce = 20.0f;
    public float rotationSpeed = 60.0f;
    bool canRotate = true;
    bool canFire = true;
    public Transform barrel;
    public Transform canonbase;
    public AudioSource firingAudio;
    //public Canvas UI;

    private void Update()
    {
        if (canRotate)
        {
            getInput();
        }

        if(canFire)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                {
                fire();
                }
        }
    }


    void getInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateLeft();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateRight();      
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rotateUp();
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rotateDown();
        }
    }


    public void rotateUp()
    {
        rotateBarrel(-1);
    }

   public void rotateDown()
    {
        rotateBarrel(1);
    }

    public void rotateRight()
    {
        rotateCanon(1);
    }

    public void rotateLeft()
    {
        rotateCanon(-1);
    }


    void rotateCanon(int dir)
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime *dir);
    }

    void rotateBarrel(int dir)
    {
        barrel.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * dir,Space.Self);
    }

    public void fire()
    {
        firingAudio.Play();
        canonball =  Instantiate(canonballprefab, firepoint.transform.position, firepoint.transform.rotation);
        canonball.GetComponent<Rigidbody>().AddForce(firepoint.forward * cannonForce);
        Destroy(canonball, 5.0f);

        GameObject smokeClouds = Instantiate(smokecloud, firepoint.transform.position, Quaternion.identity);
        Destroy(smokeClouds, 5.0f);
    }
}
