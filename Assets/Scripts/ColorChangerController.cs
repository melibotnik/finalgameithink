
using UnityEngine;

public class ColorChangerController : MonoBehaviour
{
   // variables/components
    public SpriteRenderer SR;
    public Color TargetColor = Color.blue;
    public Sprite X;

    // beginning
    void Start()
    {
        {
            SR.color = TargetColor;
        }
    }
    
    // movements
    void Update()
    {
        transform.position += new Vector3(-0.01f, 0, 0);
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
        transform.localScale += new Vector3(-0.02f, -0.02f, 0) * Time.deltaTime;
        
        //-------------------//
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.05f, 0, 0);
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.05f, 0, 0);
        }
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -0.05f, 0);
        }
        
    }
}
