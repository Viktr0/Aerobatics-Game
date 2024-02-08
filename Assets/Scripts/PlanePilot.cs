using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanePilot : MonoBehaviour
{
    Rigidbody rigidBody;

    float speed = 15.0f;
    float bias;
    Vector3 moveCamTo;
    const int checkpointNumber = 9;
    private float startTime;
    string timeString;

    enum GameState{Paused, InProgress, Crashed, Finished};
    GameState gameState = GameState.InProgress;

    public GameObject elevatorLeft;
    public GameObject elevatorRight;
    public GameObject rudder;
    public GameObject propeller;
    public GameObject lookAtObj;

    public GameObject exitButton;
    public GameObject startButton;
    public Text endText;
    public Text timeText;
    public Text endTimeText;
    public Text checkpointText;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        Checkpoint.current = 0;
        startTime = Time.time;
        rigidBody = GetComponent<Rigidbody>();
        gameState = GameState.InProgress;
        exitButton.active = false;
        startButton.active = false;
        endText.text = "";
        timeText.text = "";
        endTimeText.text = "";
        timeString = "";
        checkpointText.text = (0).ToString() + " / " + checkpointNumber.ToString();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            // Pause
        }

        if (gameState == GameState.Crashed || gameState == GameState.Finished)
        {

            exitButton.active = true;
            startButton.active = true;
            timeText.text = "";

            // Camera
            if (Camera.main.transform.position.y < 200.0f)
            {
                bias = 0.95f;
                Vector3 moveCamTo = Camera.main.transform.position + Vector3.up * 2.0f;
                Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
                Camera.main.transform.LookAt(lookAtObj.transform.position);
            }
        }
        else if (gameState == GameState.InProgress)
        {
            // Timer
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timeText.text = minutes + ":" + seconds;
            timeString = timeText.text;
            
            // Camera
            bias = 0.99f;
            moveCamTo = transform.position - transform.forward * 5.0f + transform.up * 0.5f;
            Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);

            // Speed
            speed -= transform.forward.y * Time.deltaTime * 15.0f;
            if (speed < 15.0f) speed = 15.0f;

            // Movement
            if (transform.position.y > 300.0f) transform.position.Set(transform.position.x, 300.0f, transform.position.z);
            transform.Rotate(1.0f * Input.GetAxis("Vertical"), 1.0f * Input.GetAxis("Yaw"), -1.0f * Input.GetAxis("Horizontal"));

            // Controls
            propeller.transform.RotateAroundLocal(Vector3.up, 10.0f * speed);
            rudder.transform.localRotation = Quaternion.AngleAxis(Input.GetAxis("Yaw") * 60.0f, -Vector3.forward);
            elevatorLeft.transform.localRotation = Quaternion.AngleAxis((Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")) * 40.0f, Vector3.right);
            elevatorRight.transform.localRotation = Quaternion.AngleAxis((Input.GetAxis("Horizontal") - Input.GetAxis("Vertical")) * 40.0f, Vector3.left);
        }
        else if(gameState == GameState.Paused)
        {
            // Paused
        }
    }

    private void FixedUpdate()
    {
        if (gameState == GameState.Crashed) rigidBody.velocity = Vector3.zero;
        else rigidBody.velocity = (transform.forward * speed);
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        // Crashed
        if (gameState != GameState.Crashed)
        {
            Camera.main.transform.parent = null;
            foreach (Transform child in transform.Find("Airplane").transform) {
                var rigidbody = child.gameObject.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
                rigidbody.velocity = rigidBody.velocity * 2.0f + (child.position - transform.position) * Random.Range(0.1f, 1.5f);
                rigidbody.rotation = Quaternion.FromToRotation(new Vector3(Random.Range(0.1f, 1.5f), Random.Range(0.1f, 1.5f), Random.Range(0.1f, 1.5f)), new Vector3(Random.Range(10.0f, 15f), Random.Range(10.0f, 15f), Random.Range(10.0f, 15f)));
            }
            endText.text = "You are a loser.";
            endTimeText.text = timeString;
            
        }
        gameState = GameState.Crashed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var checkpoint = other.gameObject.GetComponent<Checkpoint>();
        if (checkpoint != null)
        {
            // Checkpoint
            if(Checkpoint.current == checkpoint.index)
            {
                checkpointText.text = (checkpoint.index + 1).ToString() + " / " + checkpointNumber.ToString();
                if (Checkpoint.current < checkpointNumber - 1) { Checkpoint.current++; }
                else
                {
                    // Last checkpoint
                    endText.text = "You won.";
                    endTimeText.text = timeString;
                    
                    // Let the plane go
                    gameState = GameState.Finished;
                    Camera.main.transform.parent = null;
                    foreach (Transform child in transform.Find("Airplane").transform)
                    {
                        var rigidbody = child.gameObject.GetComponent<Rigidbody>();
                        rigidbody.useGravity = true;
                    }
                }
            }


        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
