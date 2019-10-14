EXTERNAL HasItem(name)
VAR is_first_visit = true
-> start

// functions have to be declared before the start knot,
// but after the variable declarations, it seems
=== function HasItem(name) ===
Fallback.
~ return false

=== start
{ not is_first_visit: -> returning }
~ is_first_visit = false
You: Hello?
Mazie: ...
You: Where am I?
Mazie: ...I'm... I'm not really sure...
You: Oh. Well, can you tell me your name? Are you Mazie?
Mazie: ...I think, but I don't remember.
You: I see.
Mazie: Can you go get me some candy?
{ HasItem("F3_Storage_Candy"): -> first_visit_has_candy }
You: <i>Hm... there must be some stored here somewhere.</i>
-> DONE

=== first_visit_has_candy
You: Oh! I have one here. You can have it!
-> DONE

=== returning
Mazie: Did you find any candy?
{ HasItem("F3_Storage_Candy"): -> has_candy }
You: No, I haven't yet. Let me look some more.
You: <i>Maybe there's one in the storage room?
-> DONE

=== has_candy
You: Yep! Here you go!
-> DONE
