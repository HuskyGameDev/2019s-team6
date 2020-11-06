INCLUDE Functions.ink
VAR is_first_visit = true
VAR combination = false
-> start

=== start

You:This safe is locked. Looks like it needs a combination.

{combination: -> open_safe}
-> DONE

=== open_safe
<i>Upon entering the combination, the safe unlocks and cracks open. Inside are a strange pair of shades.</i>
You:Looks like these shades block part of my vision below my eyes. Could be helpful.

<i>Obtained Under-Eye Blinders.</i>
-> DONE