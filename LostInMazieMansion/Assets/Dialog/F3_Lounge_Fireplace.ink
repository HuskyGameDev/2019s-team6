INCLUDE Functions.ink
VAR got_key = false
-> start

=== start
{ got_key: -> returning }
You: There's a few bricks loose on this fireplace...
You: Hey, a key!
<i>Obtained Hall Key</i>
DO::AddItem Items/F3_Hall_Key
~ got_key = true
-> DONE

=== returning
You: This key should open the hallway door.
-> DONE

