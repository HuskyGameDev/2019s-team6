INCLUDE Functions.ink
VAR unlocked_door = false
-> start

=== start
{ unlocked_door: -> door_unlocked}
{ HasItem("Crowbar"): -> has_crowbar }
<i>Several boards are nailed to the wall, covering the door.</i>
You: <i>These boards are nailed on pretty tight. Maybe I can find something around here to pry them off.<i>
-> DONE

=== has_crowbar
~ unlocked_door = true
You: This crowbar should do the trick.
<i> You pry the boards off with the crowbar<i>
-> door_unlocked
-> DONE

=== door_unlocked
DO::EndAndMovePlayerToDoor F3_MainHallway F3_MainHallway_GBed3
-> DONE