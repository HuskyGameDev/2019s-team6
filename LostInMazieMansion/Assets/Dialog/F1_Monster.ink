INCLUDE Functions.ink
VAR is_first_visit = true
-> start

=== start

{ not is_first_visit: -> first_visit_returning }
~ is_first_visit = false
Monster: GIVE. ME. FOOD
You: If I make you food will you move out of the way?
Monster: YES. USE. THESE.
You: I will do my best

-> DONE

=== first_visit_returning
{ HasItem("Food"): -> give_food}
Monster: GIVE. FOOD
Player: I’m working on cooking it

-> DONE

=== give_food
Monster: YUMMY. FOOD. ME. GO. NOW.
Player: Thanks!

-> DONE
