INCLUDE Functions.ink
VAR is_first_visit = true
VAR all_hands_placed = false
-> start

=== start
{all_hands_placed: -> puzzle_solved}
You: That’s strange...this clock is missing all of its hands. 
You: It almost looks like four of them could fit in here. I wonder if they’re lying around somewhere...

{HasItem("F3_Clock_Hand_1"): -> hand_one }
{not HasItem("F3_Clock_Hand_1"): -> hand_undiscovered }

-> DONE

=== hand_one
You: This black hand fell into place.

{HasItem("F3_Clock_Hand_2"): -> hand_nine }
{not HasItem("F3_Clock_Hand_2"): -> hand_undiscovered }
-> DONE

=== hand_nine
You:It looks like the red hand goes here...

{HasItem("F3_Clock_Hand_3"): -> hand_two }
{not HasItem("F3_Clock_Hand_3"): -> hand_undiscovered }
-> DONE

=== hand_two
You:This yellow hand fits here. One hand left...

{HasItem("F3_Clock_Hand_4"): -> hand_five }
{not HasItem("F3_Clock_Hand_4"): -> hand_undiscovered }
-> DONE

=== hand_five
You:And that's the last one!
<i>Upon placing the hands into the clock, they all begin rotating and shift to different positions.</i>
You:Looks like the clock hands point to 1, 9, 2, then 5. I wonder if this is the combination for the safe?
DO::RemoveItem F3_Clock_Hand_1
DO::RemoveItem F3_Clock_Hand_2
DO::RemoveItem F3_Clock_Hand_3
DO::RemoveItem F3_Clock_Hand_4
{ SetFlag("F3_Office_Safe") }
~ all_hands_placed = true
-> DONE

=== hand_undiscovered
You:Looks like I dont have the next clock hand that I need. I should look around, they have to be somewhere.
->DONE

=== puzzle_solved
You:Looks like the clock hands point to 1, 9, 2, then 5. I wonder if this is the combination for the safe?
-> DONE











