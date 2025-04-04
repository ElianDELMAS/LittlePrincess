using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private Vector2 input;

    public CarIdentity identity;

    public UnityEvent<Vector2> onInput;
    public bool frost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // Get keyboard inputs
    {
        if(!this.frost)
        {
            inputY = Input.GetAxis("Vertical");
            inputX = Input.GetAxis("Horizontal");
            //Debug.Log(inputX + "," + inputY);

            input = new Vector2(inputX, inputY).normalized;
            onInput.Invoke(input);
        }
    }
}
