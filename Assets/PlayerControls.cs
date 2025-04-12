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

    public Animator pigWalkAnimator;

    public UnityEvent<Vector2> onInput;
    public bool frost;

    // Start is called before the first frame update
    void Start()
    {
        this.pigWalkAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update() // Get keyboard inputs
    {
        if(!this.frost)
        {
            inputY = Input.GetAxis("Vertical");
            inputX = Input.GetAxis("Horizontal");

            if(inputX == 0 &&  inputY == 0) { this.pigWalkAnimator.enabled = false; }
            else { this.pigWalkAnimator.enabled = true; }

            input = new Vector2(inputX, inputY).normalized;
            //Debug.Log("Human input = " + input);
            onInput.Invoke(input);
        }
        else { this.pigWalkAnimator.enabled = false; }
    }

    public void setFrost(bool frost)
    {
        this.frost = frost;
        if (frost) { this.pigWalkAnimator.enabled = true; }
        else { this.pigWalkAnimator.enabled = false; }
    }
}
