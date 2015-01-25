using UnityEngine;
using System.Collections;

public class Phonograph : MonoBehaviour
{

    AudioSource recordNorm, recordRev;
    public bool isRev;
    public bool isNorm;



    // Use this for initalization
    void Start()
    {

        recordNorm = gameObject.transform.FindChild("RecordNorm").transform.GetComponent<AudioSource>();
        recordRev = gameObject.transform.FindChild("RecordRev").transform.GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRev && !recordRev.isPlaying)
        {
            recordRev.Play();
            isNorm = false;
        }

        if (isNorm && !recordNorm.isPlaying)
        {
            recordNorm.Play();
            isRev = false;
        }
    }
}
