INCLUDE Functions.ink
EXTERNAL DoOpenPuzzle()
VAR got_key = false
VAR returning_from_puzzle = false
-> start

=== start
{ returning_from_puzzle: -> after_puzzle }
{ HasFlag("F3_Fireplace_Solved"): -> returning }
~ returning_from_puzzle = true
You: There's a few bricks loose on this fireplace...
DO::OpenPuzzle
-> DONE

=== after_puzzle
~ returning_from_puzzle = false
{ not HasFlag("F3_Fireplace_Solved"): -> start }
You: Hey, a key!
<i>Obtained Hall Key</i>
DO::AddItem Items/F3_Hall_Key
~ got_key = true
-> DONE

=== returning
You: This key should open the hallway door.
-> DONE

