INCLUDE Functions.ink

-> start

===start
{ HasItem("Blinders"): -> hasBlinders }
You: Ugh...my head...I can't make it any further...
DO::EndAndMovePlayerToDoor F3_MainHallway F3_MainHallway_Top
-> DONE

===hasBlinders
You: These blinders should do the trick...just gotta make it the rest of the way...
-> DONE