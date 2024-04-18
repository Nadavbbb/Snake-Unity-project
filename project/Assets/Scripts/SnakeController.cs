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

    // Start is called before the first frame update
    void Start() {

        // המשחק מתחיל בכך שהנחש מוציא 5 קוביות שזה הגוף שלו
        for (int i = 0; i < 5; i++)
        {
            GrowSnake();
        }

    }

    // Update is called once per frame
    void Update() 
    {



        // כל שנייה זה מחשב ומעדכן את המיקום של הנחש
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // הניווט של הנחש
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // שומר את המיקום האחרון של הנחש
        PositionsHistory.Insert(0, transform.position);

        // כל תנועה שאני עושה זה אומר מה יקרה אם שאר החלקים של הנחש
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            body.transform.LookAt(point);

            index++;
        }
        // קבל את המיקום הנוכחי של הנחש
        Vector3 snakePosition = transform.position;
    }

    public void GrowSnake() 
    {
        // מוסיף את התפוח לגוף הנחש
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
    public void OnTriggerEnter(Collider other)
    {
        // אם הנחש פוגע בתפוח אז אותו הריבוע מצטרף לגוף שלו ונעלם מן המסך
        if(other.CompareTag("apple"))
        {
            Destroy(other.gameObject);
            GrowSnake();
        }

        
    }
}