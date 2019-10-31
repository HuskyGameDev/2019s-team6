INCLUDE Functions.ink
VAR has_flashlight = false

-> start

=== start
{ has_flashlight: -> open_room}
{ HasItem("Flashlight"): -> flashlight }
You: *At a glance, the room is pitch black*
You: I can't see a thing in there! Better find light before I go in.
-> DONE

=== flashlight
You: This flashlight should do the trick.
~ has_flashlight = true
-> open_room
-> DONE

=== open_room
DO::EndAndMovePlayerToDoor F3_Lounge F3_Lounge
->DONE
