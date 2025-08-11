using UnityEngine;

public class BringAlcohol : MonoBehaviour
{
    public miniGameHelper mgh;
    public Rigidbody rb;
    public float jumpPower;
    public int maxJumps;
    public int atJump;
    public bool inJump;
    public float maxHoldJump;
    public float holdJump;
    public float jumpHoldMod;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && atJump < maxJumps)
        {
            atJump++;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower, 0);
            inJump = true;
        }
        if (inJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(rb.linearVelocity.x, jumpPower * jumpHoldMod * Time.deltaTime, 0);
            }
            holdJump += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) || holdJump >= maxHoldJump || rb.linearVelocity.y <= 0)
        {
            inJump = false;
            holdJump = 0;
        }
        if (rb.linearVelocity.y == 0)
        {
            atJump = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-jumpPower,0,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(jumpPower, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rb.gameObject)
        {
            mgh.finalScore = 1;
        }
    }
}