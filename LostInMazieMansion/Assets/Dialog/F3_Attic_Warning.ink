INCLUDE Functions.ink
VAR warning = true
-> start

=== start
DO::AddItem Items/Flashlight
You: There sure are a lot of holes in the floor. Better be careful where I step...
-> DONE

=== returning
-> DONE
