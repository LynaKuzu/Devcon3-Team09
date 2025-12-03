using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    [field: SerializeField] public Rigidbody StoneRB { get; private set; }
    [field: SerializeField] public Transform ShotPoint { get; private set; }
    [field: SerializeField] public float ChargeForce { get; private set; } = 1;
    [field: SerializeField] public float ChargeFeet { get; private set; } = 1;
    [field: SerializeField] public bool IsCharging { get; private set; }
    [field: SerializeField] public bool HasShot; 
    [field: SerializeField] public float ChargeTime = 1;
    [field: SerializeField] public KeyCode ShootKey { get; private set; } = KeyCode.Space;
    [field: SerializeField] public KeyCode LeftKey { get; private set; } = KeyCode.A;
    [field: SerializeField] public KeyCode RightKey { get; private set; } = KeyCode.D;

    [field: SerializeField] public float RockMove = 0f;
    private Rigidbody rb;




    private void Awake()
    {
        if (StoneRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(StoneRB)}.";
            throw new MissingComponentException(msg);
        }
        rb = GetComponent<Rigidbody>();

         
    }

    private void Update()
    {
        if (Input.GetKey(ShootKey) && HasShot == false)
        {
            IsCharging = true;
            ChargeTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(ShootKey) && ChargeTime >= 1)
        {
            ChargeShot();
            HasShot = true;
        }
        else if (Input.GetKeyUp(ShootKey) && ChargeTime < 1)
        {
            ChargeTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if(RockMove > 0f)
        {
            RockMove += -0.1f;
        }
        if (RockMove < 0f)
        {
            RockMove += 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            RockMove += 1f;
            if (RockMove > 3f)
            {
                RockMove = 3f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            RockMove -= 1f;
            if (RockMove < -3f)
            {
                RockMove = -3f;
            }
        }
        StoneRB.velocity = new Vector3(RockMove, rb.velocity.y, rb.velocity.z);
        



    }

    private void Reset()
    {
        if (StoneRB == null)
            StoneRB = GetComponent<Rigidbody>();
    }

    void ChargeShot ()
    {

        ChargeForce = ChargeTime;
        if (ChargeForce > 5)
        {
            ChargeForce = 5;
        }
        StoneRB.AddForce((ShotPoint.forward * ChargeForce) * 300, ForceMode.Impulse);

        IsCharging = false;
        ChargeTime = 0;
        ChargeForce = 0;
    }

}
