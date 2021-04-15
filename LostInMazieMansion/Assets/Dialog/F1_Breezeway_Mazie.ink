INCLUDE Functions.ink
VAR is_first_visit = true
VAR given_candy_first_visit = true
VAR mansion_hint_visited = false
VAR cooking_first_visit_visited = false
-> start

=== start
{ cooking_first_visit_visited: -> cooking_return }
{ mansion_hint_visited: -> mansion_hint_return }
{ HasItem("Mazie_Doll"): -> mansion_hint }
{ not given_candy_first_visit: -> given_candy_returning }
{ not is_first_visit: -> first_visit_returning }
~ is_first_visit = false
You: You’re here too! Are your memories coming back?
Mazie: Yes, but there are still some that are fuzzy, if I had some candy maybe that will help…
{ HasItem("F1_Bathroom_Candy"): -> first_visit_has_candy }
You: I’ll go find some for you

-> DONE

=== first_visit_returning
{ HasItem("F1_Bathroom_Candy"): -> has_candy_returning }
Mazie: My memory is still fuzzy, maybe some candy will help…
You: I’ll go look for some
-> DONE

=== first_visit_has_candy
You: Here's some I found earlier!
DO::RemoveItem F1_Bathroom_Candy
-> has_candy_cont
-> DONE

=== has_candy_returning
You: Here’s your candy!
DO::RemoveItem F2_Bathroom_Candy
-> has_candy_cont
-> DONE

=== has_candy_cont
~ given_candy_first_visit = false
Mazie: Mmmm...the candy was even better this time
You: Is your memory coming back then?
Mazie: Yes, I think you want to go into the basement, somehow
You: There’s a hole in the dining room that looks like it goes there
Mazie: There should be something in the room to the right of the entrance that will help you get down there
You: I’ll go look for it
-> DONE

=== given_candy_returning
Mazie: To the right side of the entrance there should be a room with something in it for you
You: I’ll go check it out
-> DONE


=== mansion_hint
~ mansion_hint_visited = true
You: I found this mansion that has a doll that looks a lot like you
Mazie: I remember playing with that in the past, I’d always leave my doll by the entrance
You: I’ll look into it then
-> DONE

=== mansion_hint_return
{not HasItem("Mazie_Doll"): -> cooking_first_visit }
Mazie: I would always leave my doll at the entrance
You: I’ll see if that helps
-> DONE

=== cooking_first_visit
~ cooking_first_visit_visited = true

-> DONE

=== cooking_return

-> DONE