INCLUDE Functions.ink
VAR unlocked_door = false

-> start

=== start
{ unlocked_door: -> door_unlocked}
{ HasItem("F3_Hall_Key"): -> has_key }
You: <i>It's locked. Maybe there's a key around here...</i>
-> DONE

=== has_key
<i>Unlocked Door</i>
DO::RemoveItem F3_Hall_Key
~ unlocked_door = true
-> door_unlocked
-> DONE

=== door_unlocked
DO::EndAndMovePlayerToDoor F3_MainHallway F3_MainHallway_Top
->DONE
