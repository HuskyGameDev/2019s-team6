INCLUDE Functions.ink
VAR is_first_visit = true
VAR given_candy_first_visit = true
VAR puzzle_finish_visited = false
VAR fear_first_visit_visited = false
-> start

=== start
{ fear_first_visit_visited: -> fear_return }
{ puzzle_finish_visited: -> puzzle_finish_return }
{ HasItem("Music_Sheet"): -> puzzle_finish }
{ not given_candy_first_visit: -> given_candy_returning }
{ not is_first_visit: -> first_visit_returning }
~ is_first_visit = false
You: I've found you again! Are you getting better?
Mazie: Yeah...my memory is getting better it seems
You: I'm not sure where to go here, do you have any ideas?
Mazie: Hmm...I'm not sure...my memory is still a bit fuzzy...If you go get me more candy my memory may clear up.
{ HasItem("F2_Bathroom_Candy"): -> first_visit_has_candy }
You: I'll see if I can find any around
-> DONE

=== first_visit_returning
{ HasItem("F2_Bathroom_Candy"): -> has_candy_returning }
Mazie: If only my memory wasn’t fuzzy...some candy may help with it
You: I’ll go looking around for some
-> DONE

=== first_visit_has_candy
You: Here's some I found earlier!
DO::RemoveItem F2_Bathroom_Candy
-> has_candy_cont
-> DONE

=== has_candy_returning
You: Here's the candy you asked for!
DO::RemoveItem F2_Bathroom_Candy
-> has_candy_cont
-> DONE

=== has_candy_cont
~ given_candy_first_visit = false
Mazie: Mmmm...That candy was yummy, thanks!
You: No problem, did you happen to remember anything that could help me?
Mazie: Hmm...That puzzle on the table is missing a few pieces, but you should be able to find them in one of the guest rooms and on this floor...
You: Is there anything more specific about the rooms you can remember?
Mazie: Hmm...the Moonlit Garden would be a good place to hide a puzzle piece...
You: Thanks! I'll get going now.
-> DONE

=== given_candy_returning
Mazie: Hmm...The Moonlit Garden and a guest bedroom upstairs would be good places to hide a puzzle piece...the last has to be on this floor...
You: I’ll go looking
-> DONE


=== puzzle_finish
~ puzzle_finish_visited = true
Mazie: It looks like you finished the puzzle
You: I did, I got what looks like a music sheet from it. Do you know what I could do with it?
Mazie: Hmm...I remember Dad used to play the piano in the bottom left room of the corridor
You: I’ll go there and check it out then
-> DONE

=== puzzle_finish_return
{not HasItem("MusicSheet"): -> fear_first_visit }
Mazie: I remember Dad used to play the piano in the bottom left room of the corridor…
You: I’ll go there and check it out
-> DONE

=== fear_first_visit
~ fear_first_visit_visited = true
Mazie: What happened? You look white as a ghost…
You: I found a tunnel behind a Piano and when I entered I found rats and I panicked
Mazie: I never knew there was a tunnel there...
You: It’s alright, I never expected it either
Mazie: Maybe there is something in the hallway on the right you could use to get through...I remember Dad going in there before playing the piano plenty of times
You: I’ll see what I can find in there
-> DONE

=== fear_return
Mazie: My Dad would always go in that hallway on the right before playing the piano...maybe there’s something there you could use
You: I’ll be sure to take a look
-> DONE