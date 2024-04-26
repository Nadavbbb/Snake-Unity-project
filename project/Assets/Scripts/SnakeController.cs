using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;


    // References
    public GameObject BodyPrefab;

    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();

    [SerializeField] GameObject logic;
    // Start is called before the first frame update
    private bool stopSnake;
    public void SetStopSnake(bool IsStop)
    {
        stopSnake = IsStop;
    }
    void Start() {
        stopSnake = false;
        // המשחק מתחיל בכך שהנחש יוצר 5 קוביות שזה הגוף שלו
        for (int i = 0; i < 5; i++)
        {
            GrowSnake();
        }

    }

    // Update is called once per frame
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stopSnake)
        {
            // Update snake's head position
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            // Steering the snake
            float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
            transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

            // Save current position to history
            PositionsHistory.Insert(0, transform.position);

            // Trim history list if it exceeds maximum length
            if (PositionsHistory.Count > 1000)
            {
                PositionsHistory.RemoveAt(PositionsHistory.Count - 1);
            }

            // Update body parts
            int index = 0;
            foreach (var body in BodyParts)
            {
                int pointIndex = Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1);
                Vector3 point = PositionsHistory[pointIndex];

                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

                body.transform.LookAt(point);

                index++;
            }
        }
        
    }

    // מגדיל את הנחש על ידי יצירת והוספת חלק
    public void GrowSnake() 
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    public void OnTriggerEnter(Collider other)
    {
        // אם הנחש פוגע באשפה אז אותו הריבוע מצטרף לגוף שלו ונעלם מן המסך
        if (other.CompareTag("Trash"))
        {
            logic.GetComponent<GameLogic>().OpenGateLogic(other);
            Destroy(other.gameObject);
            GrowSnake();

        }
        else if (other.CompareTag("Heart"))
        {
            logic.GetComponent<GameLogic>().AddLifeIfHasPlace(other);
        }


    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("end of the game obstacle"))
        {
            logic.GetComponent<GameLogic>().ObstacleCollision();

        }
    }
}