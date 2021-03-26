INCLUDE Functions.ink
VAR First_Visit = true
{First_Visit: -> start}

=== start
You: <i>Wow, this room looks beautiful, I wonder what’s around</i>
~First_Visit = false
-> DONE
