using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    [field: SerializeField] public Rigidbody StoneRB { get; private set; }
    [field: SerializeField] public Transform ShotPoint { get; private set; }
    [field: SerializeField] public float ChargeForce { get; private set; } = 1;
    [field: SerializeField] public float ChargeFeet { get; private set; } = 1;
    [field: SerializeField] public bool IsCharging { get; private set; }
    [field: SerializeField] public float ChargeTime { get; private set; } = 1;
    [field: SerializeField] public KeyCode ShootKey { get; private set; } = KeyCode.Space;


    private void Awake()
    {
        if (StoneRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(StoneRB)}.";
            throw new MissingComponentException(msg);
        }
    }

    private void Update()
    {
        if (Input.GetKey(ShootKey))
        {
            IsCharging = true;
            ChargeTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(ShootKey) && ChargeTime >= 1)
        {
            ChargeShot();
        }
        else if (Input.GetKeyUp(ShootKey) && ChargeTime < 1)
        {
            ChargeTime = 0;
        }
    }

    private void FixedUpdate()
    {
        //if (!DoShoot)
            return;
        //DoShoot = false;

        Vector3 kickDirection = StoneRB.transform.forward;
        Vector3 force = ChargeForce * kickDirection;
        StoneRB.AddForce(force, ForceMode.Impulse);

        Vector3 kickSpinDirection = StoneRB.transform.up;
        Vector3 torque = ChargeFeet * kickSpinDirection;
        StoneRB.AddTorque(torque, ForceMode.Impulse);
    }

    private void Reset()
    {
        if (StoneRB == null)
            StoneRB = GetComponent<Rigidbody>();
    }

    void ChargeShot ()
    {
        ChargeForce = ChargeTime;
        StoneRB.AddForce(ShotPoint.forward * ChargeForce, ForceMode.Impulse);

        IsCharging = false;
        ChargeTime = 0;
        ChargeForce = 0;
    }

}
