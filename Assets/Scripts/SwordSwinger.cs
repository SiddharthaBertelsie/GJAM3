using UnityEngine;

public class SwordSwinger : MonoBehaviour
{
    // Before running the code, we want to have a empty object that the sword sprite + collider is attachted to.
    // It will have an anim which swings in an arc.
    // The sword will be facing straight ahead on the object

    // The code:
    // We want to get the screen position of our mouse, and then convert it to a Vector2 world space position
    // We want to roatte the empty obj that the sword is attached to in the direction of the world space position we just got.
    // We want to enable the sword, before playing the animation
    // The sword should disappear after the animation is done.
}
