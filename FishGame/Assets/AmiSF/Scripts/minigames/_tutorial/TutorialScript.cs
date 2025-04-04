using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    //variables
    public Rigidbody rb;
    public float jumpPower;
    public int maxJumps;
    public int atJump;
    public bool inJump;
    public float maxHoldJump;
    public float holdJump;
    public float jumpHoldMod;

    //functions
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
    }
}