using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private bool Pressed;
    private Rigidbody2D rb;
    private SpringJoint2D SpringJoint;
    private float releaseDecay;
    [SerializeField]private SpriteRenderer ballS;
    [SerializeField]private float maxDistance;
    public Rigidbody2D slingrb;
    private LineRenderer line;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpringJoint = GetComponent<SpringJoint2D>();      
        releaseDecay = 1 / (SpringJoint.frequency * 4);
        ballS = GetComponent<SpriteRenderer>();  
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }
    private void Update()
    {
        if (Pressed)
        {
            Drag();
        }
    }
    private void Drag()
    {
        SetLineRendererPosition();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );       
        float distance = Vector2.Distance( mousePos, slingrb.position );
        if ( distance > maxDistance )
        {
            Vector2 direction = (mousePos - slingrb.position).normalized;
            rb.position = slingrb.position + direction * maxDistance;
        }
        else
        {
            rb.position = mousePos;
        }
    }
    private void SetLineRendererPosition()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = rb.position;
        positions[1] = SpringJoint.connectedBody.position;
        line.SetPositions(positions );
    }
    private void OnMouseDown()
    {
        Pressed = true;
        rb.isKinematic = true;
        line.enabled = true;       
    }
    private void OnMouseUp()
    {
        Pressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        line.enabled = false;
    }
    private IEnumerator Release()
    {
        yield return new WaitForSeconds( releaseDecay );
        SpringJoint.enabled = false;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {            
            Invoke("DestroyBa", 2f);
        }
    }

    private void DestroyBa()
    {
        Destroy(gameObject);
        
    }
    private void OnEnable()
    {
        SpringJoint.connectedBody = GameObject.FindGameObjectWithTag("Sling").GetComponent<Rigidbody2D>();
        slingrb = SpringJoint.connectedBody;
        SpringJoint.enabled = true;
        SpringJoint.distance = 0.005f;
    }
    private void OnDestroy()
    {
        STaticInventory.slots--;
    }
}
