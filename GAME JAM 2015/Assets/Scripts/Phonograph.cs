using UnityEngine;
using System.Collections;

public class Phonograph : MonoBehaviour
{

    AudioSource recordNorm, recordRev;
    public bool isRev;
    public bool isNorm;

    float currentPosition;
    Transform player;

    // Use this for initalization
    void Start()
    {
        currentPosition = 0;
        player = GameObject.Find("First Person Duck Controller").transform;
        recordNorm = gameObject.transform.FindChild("RecordNorm").transform.GetComponent<AudioSource>();
        recordRev = gameObject.transform.FindChild("RecordRev").transform.GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_FORWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.collider.Raycast(gunLookRay, out hitInfo, 100))
            {
                ChangeTimeDirectionToFoward();
            }
        }
        else if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_BACKWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.collider.Raycast(gunLookRay, out hitInfo, 100))
            {
                ChangeTimeDirectionToReverse();
            }
        }

        if (isRev && !recordRev.isPlaying)
        {
            recordRev.Play();
            recordRev.time = currentPosition;
            isNorm = false;
        }

        if (isNorm && !recordNorm.isPlaying)
        {
            recordNorm.Play();
            recordNorm.time = currentPosition;
            isRev = false;
        }
    }

    public void ChangeTimeDirectionToFoward()
    {
        //Debug.Log("ChangeTimeDirectionToFoward");
        isNorm = true;
        isRev = false;

        currentPosition = 80 - recordRev.time;
        recordRev.Stop();
    }

    public void ChangeTimeDirectionToReverse()
    {
        isNorm = false;
        isRev = true;

        currentPosition = 80 - recordNorm.time;
        recordNorm.Stop();
    }
}
