INCLUDE Functions.ink
VAR unlocked_door = false

-> start

=== start
{ unlocked_door: -> door_unlocked}
{ HasItem("Crowbar"): -> has_crowbar }
You: <i>The door won't open. It seems like it's boarded up from the other side.</i>
-> DONE

=== has_crowbar
~ unlocked_door = true
-> door_unlocked
-> DONE

=== door_unlocked
DO::EndAndMovePlayerToDoor F3_MainHallway_GBed3 F3_GuestBedroom3
-> DONE
