using UnityEngine;
using System.Collections;

public class PlayerFunctionScript : MonoBehaviour {

    enum PlayerState{
        Waiting = 0,
        Moving = 1,
        Turning
    }

    enum ForwardState{
        None = 0,
        Exist
    }

    private PlayerState myState = PlayerState.Waiting;
    private ForwardState myForwardState = ForwardState.None;

    private float myPositionX = 0;
    private float myPositionZ = 0;
    private float prePositionX = 0;
    private float prePositionZ = 0;

	// Use this for initialization
	void Start () {
        myPositionX = transform.position.x;
        myPositionZ = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        switch (myState) {
        case PlayerState.Waiting :
            CheckInput();
            CheckState();
            break;
        case PlayerState.Moving  :
            Move();
            break;
        case PlayerState.Turning :
            Turn();
            break;
        }
	}

    private float preRotation = 0.0f;
    private float turnAngle;
    private float rotateRatio = 1.0f;
    private float wantAngle = 0f;

    void TurnInit(int direct) {

        rotateRatio = 0f;

        preRotation = transform.localEulerAngles.y;
        if (direct == 0) {
            wantAngle = transform.localEulerAngles.y - 90f;
        } else {
            wantAngle = transform.localEulerAngles.y + 90f;
        }

    }

	void Turn() {

        turnAngle = Mathf.LerpAngle(preRotation,wantAngle,1.0f*rotateRatio);
        rotateRatio = rotateRatio + 0.01f;
        transform.eulerAngles = 
            new Vector3(0, turnAngle,  0);

        if ( rotateRatio >= 1f ) {
            ChangeState( PlayerState.Waiting );
        }

    }


    private Vector3 wantPosition;
    private float pointRatio = 1.0f;

    void MoveInit() {

        wantPosition = transform.localPosition + transform.TransformDirection(0,0,1);
        pointRatio = 0;

    }

	void Move() {

        transform.position = Vector3.Lerp (transform.position, wantPosition, 1.0f*pointRatio);
        pointRatio = pointRatio + 0.01f;

        if (transform.position == wantPosition) {
            ChangeState(PlayerState.Waiting);
        }

    }

    void CheckInput(){

        if(Input.GetKeyDown(KeyCode.UpArrow) && myForwardState == ForwardState.None ){
            ChangeState(PlayerState.Moving);
            MoveInit();
        }

        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            ChangeState(PlayerState.Turning);
            TurnInit(0);
        }

        if (Input.GetKeyDown (KeyCode.RightArrow)) {
            ChangeState(PlayerState.Turning);
            TurnInit(1);
        }

        
    }
    
    void CheckState(){
    }

    void ChangeState(PlayerState purposeState){
        myState = purposeState;
    }

    void OnTriggerEnter(Collider col){

        myForwardState = ForwardState.Exist;
        Debug.Log ("!");

    }

    void OnTriggerExit(Collider col) {

        myForwardState = ForwardState.None;

    }

}
