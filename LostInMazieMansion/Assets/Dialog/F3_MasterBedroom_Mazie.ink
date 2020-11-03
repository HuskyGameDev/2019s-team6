INCLUDE Functions.ink
VAR is_first_visit = true
VAR given_candy_first_visit = true
-> start

=== start
{ not given_candy_first_visit: -> has_candy_returning }
{ not is_first_visit: -> returning }
~ is_first_visit = false
You: Oh, you're here! Are you doing alright?
Mazie: Yeah, I think so...
Player: I'm trying to find my way around. Do you remember anything that could help?
Mazie: Hmmm...my memory is still fuzzy... I can’t think of anything. Maybe you could find me more candy? I might remember more.
{ HasItem("F3_GuestBedroom_Candy"): -> first_visit_has_candy }
Player: It doesn’t hurt to try. I’ll see what I can do.
-> DONE

=== first_visit_has_candy
You: I found a piece lying around earlier. Here you go!
DO::RemoveItem F3_GuestBedroom_Candy
-> has_candy_cont
-> DONE

=== returning
{ HasItem("F3_GuestBedroom_Candy"): -> has_candy }
You: I might remember more if you can find some candy.
You: I’ll see what I can do.
-> DONE

=== has_candy
You: Here you go!
DO::RemoveItem F3_Storage_Candy
-> has_candy_cont
-> DONE

=== has_candy_cont
~ given_candy_first_visit = false
Mazie: Mmm...tasty...thanks again!
Player: No problem. Do you remember anything helpful?
Mazie: Hmm...you might be able to find something helpful in one of the guest bedrooms, though a few of them have been boarded up.
Player: Are there any other ways in?
Mazie: The attic floorboards have always been a bit loose...you might be able to get in from above.
Player: Sounds like an idea. I’ll give it a try.
->DONE

=== has_candy_returning
Mazie: You might be able to get into the guest bedrooms from above though the attic.
Player: I’ll give it a try.

-> DONE