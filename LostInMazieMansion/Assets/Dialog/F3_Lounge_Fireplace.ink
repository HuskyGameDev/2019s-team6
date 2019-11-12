INCLUDE Functions.ink
EXTERNAL DoOpenPuzzle()
VAR got_key = false
-> start

=== function DoOpenPuzzle()
Fallback
~ return

=== start
{ HasFlag("F3_Fireplace_Solved"): -> returning }
You: There's a few bricks loose on this fireplace...
{ DoOpenPuzzle() }
{ not HasFlag("F3_Fireplace_Solved"): -> DONE }
You: Hey, a key!
<i>Obtained Hall Key</i>
DO::AddItem Items/F3_Hall_Key
~ got_key = true
-> DONE

=== returning
You: This key should open the hallway door.
-> DONE

