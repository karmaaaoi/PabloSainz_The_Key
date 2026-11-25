using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public float velocidad = 10f;
    public float gravity = -9.81f;
    public float verticalSpeed;
    private CharacterController CharacterController;
    float horizontalMove;
    float verticalMove;
    public float coinCollete = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (CharacterController.isGrounded == true)
        {
            verticalSpeed = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                verticalSpeed = 2.5f;
            }
        }
        verticalSpeed += gravity * Time.deltaTime;
        Vector3 direction = new Vector3(horizontalMove, verticalSpeed, verticalMove);
        CharacterController.Move(direction * velocidad * Time.deltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coin"))
        {

            collectable_controller collectable = hit.gameObject.GetComponent<collectable_controller>();
            if (collectable.collectable == false)
            {
                collectable.collectable = true;
                //sumar 1 a la moneda
                coinCollete += 1;
                //mostrar en consola texto de cuantas monedas tienes
                Debug.Log("moneda" + coinCollete);
                //destruir moneda
                Destroy(hit.gameObject);
            }
        }

        Debug.Log("Collided with: " + hit.gameObject.name);
    }
}

