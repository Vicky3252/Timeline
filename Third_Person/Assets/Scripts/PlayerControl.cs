using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public NewPlayerActions ip;
    // Start is called before the first frame update
    void Start()
    {
        ip = new NewPlayerActions();
        ip.Player.Move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ipmove = ip.Player.Move.ReadValue<Vector2>();
        transform.position += new Vector3(ipmove.x, 0, ipmove.y);
    }
}
