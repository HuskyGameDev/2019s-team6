EXTERNAL HasItem(name)
-> start

// functions have to be declared before the start knot,
// but after the variable declarations, it seems
=== function HasItem(name) ===
Fallback.
~ return false

=== start
{ HasItem("F3_Dresser_Key"): -> has_key }
You: <i>It's locked. Maybe there's a key somewhere...</i>
-> DONE

=== has_key
Unlocked Dresser
You: Hey, a flashlight!
Obtained Flashlight
DO::RemoveItem F3_Dresser_Key
DO::AddItem Items/Flashlight
-> DONE

