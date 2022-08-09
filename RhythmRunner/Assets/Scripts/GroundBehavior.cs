using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public float groundHeight;
	public LevelData levelConfig;
	public RealTimeData realTime;
    BoxCollider2D boxCollider;
	private float initXPos;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (transform.localScale.y / 2);
		initXPos = transform.position.x;
    }

	void FixedUpdate() {
		transform.position = new Vector2(initXPos - realTime.distance, transform.position.y);
	}
}
