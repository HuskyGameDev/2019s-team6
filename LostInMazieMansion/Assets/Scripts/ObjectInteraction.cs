/*
 * This script defines an interactable object.  Interactable objects can be
 * interacted with by the player be pressing 'E'.  Some interactable objects
 * are collected when 'E' is pressed.
 * 
 * NOTE:
 * Most objects using this script will have isInteractable return true.
 */


//using system.collections;
//using system.collections.generic;
//using unityengine;

//abstract class interactable
//{
//    /*
//     * the player can interact with interactable objects
//     */
//    public abstract bool isinteractable();

//    /*
//     * the player can collect collectable interactable objects
//     */
//    public abstract bool iscollectable();

//}

//class interaction : interactable
//{
//    private bool cantouch;    // is the object an interactable
//    private bool cancollect;  // is the object a collectable

//    /*
//     * constructor for an interactable object.
//     * 
//     * param touch   - true if player can interact by pressing 'e'
//     *                 false otherwise
//     * param collect - true if pressing 'e' adds object to inventory
//     *                 false otherwise
//    */
//    public interaction(bool touch, bool collect)
//    {
//        cantouch = touch;
//        cancollect = collect;
//    }

//    /*
//     * checks to see if an object is interactable.
//     * 
//     * return - true if the player can press 'e' next to object
//     *          false otherwise
//    */
//    public override bool isinteractable()
//    {
//        return cantouch;
//    }

//    /*
//     * checks to see if an object is collectable.
//     * 
//     * return - true if pressing 'e' adds object to inventory
//     *          false otherwise
//     */
//    public override bool iscollectable()
//    {
//        return cancollect;
//    }
//}

//public class objectinteraction : monobehaviour
//{
//    public bool touch;   // true if interactable, false otherwise
//    public bool collect; // true if collectable, false otherwise
//    interaction obj;     // this is the object up for interactable debate

//    // use this for initialization
//    void start()
//    {
//        // make a new obj and define whether or not it's interactable
//        obj = new interaction(touch, collect);
//    }

//    // update is called once per frame
//    void update()
//    {
//        // if the object is interactable and the player presses 'e'
//        if (obj.isinteractable() && input.getkey(keycode.e))
//        {
//            // if the object is collectable
//            if (obj.iscollectable())
//            {
//                // make item sprite disappear


//                // add item to inventory 


//                // make "collected item" sound
//            }

//            // a message will appear

//        }
//    }
//}
