using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
     // Bu kod başlangıçta küpün yerini değiştirir.
     // transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Herhangi bir input olmadan kübü dikeyde hareket ettirir
        // float translation = speed;
        // translation *= Time.deltaTime;
        // transform.Translate(translation, 0, 0);


        // Ok tuşları ile küpü hareket ettirmeyi sağlayan kod
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationY = Input.GetAxis("Vertical") * speed;
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;
        transform.Translate(translationX, translationY, 0); 
    }
}
