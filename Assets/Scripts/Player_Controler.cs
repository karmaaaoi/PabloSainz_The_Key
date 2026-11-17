using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public float velocidad = 10f;
    private CharacterController CharacterController;
    float horizontalMove;
    float verticalMove;
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
        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);
        CharacterController.Move(direction * velocidad * Time.deltaTime);
    }
}
