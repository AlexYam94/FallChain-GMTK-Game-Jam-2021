using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.System
{
    public class RopeSegment : MonoBehaviour
    {
        public GameObject connectedLeft { get { return connectedLeft; } set { connectedLeft = value; } }
        [SerializeField] GameObject connectedRight;

        Vector2 temp;
        Vector2 lastPosition = new Vector2(0, 0);
        Vector2 currentPosition;

        // Start is called before the first frame update
        void Start()
        {
            currentPosition = transform.position;
        }

        private void Update()
        {
            if (connectedRight != null)
            {
                HingeJoint2D[] hingeJoints = GetComponents<HingeJoint2D>();
                foreach (var hingeJoint in hingeJoints)
                {
                    if (hingeJoint.connectedBody.gameObject == connectedRight)
                    {
                        transform.position = connectedRight.transform.position;
                    }
                }
            }
        }
    }

}
