using UnityEngine;
using System.Collections;

public class PhonographMenus : MonoBehaviour
{

    AudioSource recordNorm, recordRev;
    public bool isRev;
    public bool isNorm;

    float currentPosition;

    // Use this for initalization
    void Start()
    {
        currentPosition = 0;
        recordNorm = gameObject.transform.FindChild("RecordNorm").transform.GetComponent<AudioSource>();
        recordRev = gameObject.transform.FindChild("RecordRev").transform.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
