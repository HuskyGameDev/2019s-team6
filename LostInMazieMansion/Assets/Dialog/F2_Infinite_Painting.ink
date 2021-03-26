INCLUDE Functions.ink
VAR First_Look = true
VAR Second_Look = true
VAR Repeated_Look = true

{ First_Look: -> start}
{ Second_Look: -> second}
{ Repeated_Look: -> returning}

=== start
You: This painting looks almost lifelike...I wonder…
~ First_Look = false
-> DONE

=== second
You: Oh wow! I can reach into it! Let’s grab this Torch
~ Second_Look = false
DO::AddItem Items/Torch
-> DONE

=== returning
You: I don't see anything else useful in the painting

->DONE
