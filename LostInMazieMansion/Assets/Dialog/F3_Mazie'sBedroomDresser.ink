EXTERNAL HasItem(name)
VAR got_flashlight = false
-> start

=== start
{ got_flashlight: -> returning}
{ HasItem("F3_Dresser_Key"): -> has_key }
You: <i>It's locked. Maybe there's a key somewhere...</i>
-> DONE

=== has_key
<i>Unlocked Dresser</i>
You: Hey, a flashlight!
<i>Obtained Flashlight</i>
DO::RemoveItem F3_Dresser_Key
DO::AddItem Items/Flashlight
~ got_flashlight = true
-> DONE

=== returning
You: This flashlight should come in handy.
-> DONE

