INCLUDE Functions.ink
-> start

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

