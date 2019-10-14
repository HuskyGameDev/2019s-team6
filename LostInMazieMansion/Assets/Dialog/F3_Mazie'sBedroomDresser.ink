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
<i>Unlocked Dresser</i>
You: Hey, a flashlight!
<i>Obtained Flashlight</i>
DO::RemoveItem F3_Dresser_Key
DO::AddItem Items/F3_Hall_Key
-> DONE

