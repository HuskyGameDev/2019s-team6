INCLUDE Functions.ink
VAR is_first_visit = true
VAR all_hands_placed = false
-> start

=== start
{all_hands_placed: -> puzzle_solved}
You:That’s strange...this clock is missing all of its hands. It almost looks like four of them could fit in here. I wonder if they’re lying around somewhere...

{HasItem("F3_Office_Hand_1"): -> hand_one }
{not HasItem("F3_Office_Hand_1"): -> hand_undiscovered }

-> DONE

=== hand_one
You:That one fell right into place

{HasItem("F3_Office_Hand_9"): -> hand_nine }
{not HasItem("F3_Office_Hand_9"): -> hand_undiscovered }
-> DONE

=== hand_nine
You:It looks like this one goes here

{HasItem("F3_Office_Hand_2"): -> hand_two }
{not HasItem("F3_Office_Hand_2"): -> hand_undiscovered }
-> DONE

=== hand_two
You:This one fits here, one left

{HasItem("F3_Office_Hand_5"): -> hand_five }
{not HasItem("F3_Office_Hand_5"): -> hand_undiscovered }
-> DONE

=== hand_five
You:And thats the last one-
<i>Upon placing the hands into the clock, they all begin rotating and shift to different positions.</i>
You:Looks like the clock hands point to 1, 9, 2, then 5. I wonder if this is the combination for the safe?
DO::RemoveItem F3_Office_Hand_1
DO::RemoveItem F3_Office_Hand_9
DO::RemoveItem F3_Office_Hand_2
DO::RemoveItem F3_Office_Hand_5
~ all_hands_placed = true
-> DONE

=== hand_undiscovered
You:Looks like I dont have the next clock hand that I need. I should go looking around they have to be somewhere.
->DONE

=== puzzle_solved
You:Looks like the clock hands point to 1, 9, 2, then 5. I wonder if this is the combination for the safe?
-> DONE











