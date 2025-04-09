using System.Collections;
using System.Collections.Generic;
using UnityEngine; // as usual
using UnityEngine.Events; // needed to use UnityEvent

public class SimpleCheckpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, SimpleCheckpoint> onCheckpointEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<CarIdentity>() != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(collider.gameObject.GetComponent<CarIdentity>(), this);
        }
    }
}
