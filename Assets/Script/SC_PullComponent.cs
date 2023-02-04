using UnityEngine;

namespace Script
{
    public class SC_PullComponent : MonoBehaviour
    {
        public Joint2D joint;
        public SpriteRenderer rockSprite;
        [SerializeField] private Sprite newRockSprite;
        [SerializeField] private Sprite oldRockSprite;
        public Color FlowerColor;
        private Rigidbody2D rbRock;

        private void Start()
        {
            rbRock = this.GetComponent<Rigidbody2D>();

            rbRock.bodyType = RigidbodyType2D.Kinematic;
        }

        public void Grab(Rigidbody2D rb)
        {
            rbRock.bodyType = RigidbodyType2D.Dynamic;
            rockSprite.sprite = newRockSprite;
            joint.connectedBody = rb;
            joint.enabled = true;
        }

        public void CancelGrab()
        {
            if(joint.connectedBody != null)
            {
                rbRock.velocity = Vector2.zero;
                rbRock.bodyType = RigidbodyType2D.Kinematic;
                rockSprite.sprite = oldRockSprite;
                joint.connectedBody = null;
                joint.enabled = false;
            }
        }
    }
}