using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float power = 20f;
    public float timer = 0;
    public Text TextUl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        TextUl.text = timer.ToString();
        if (Input.GetKey(KeyCode.Space))
        {
            power = power + Random.Range(-100, 200);
            rigidbody.AddForce(transform.up * power);
        }
        if (this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
    }
}
