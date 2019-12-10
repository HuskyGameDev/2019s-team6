INCLUDE Functions.ink
VAR is_first_visit = true
VAR given_candy_first_visit = true
-> start

=== start
{ not given_candy_first_visit: -> has_candy_returning }
{ not is_first_visit: -> returning }
~ is_first_visit = false
You: Hello?
???: ...
You: Where am I?
???: ... I'm... I'm not really sure...
You: Oh. Well, can you tell me your name?
???: ... I don't remember.
You: Hm, I see.
???: Can you go get me some candy?
{ HasItem("F3_Storage_Candy"): -> first_visit_has_candy }
You: Uhh... sure, I suppose.
You: <i>Hm... there must be some stored here somewhere.</i>
-> DONE

=== first_visit_has_candy
You: Sure, I found a piece earlier. You can have it.
DO::RemoveItem F3_Storage_Candy
-> has_candy_cont
-> DONE

=== returning
???: Did you find any candy?
{ HasItem("F3_Storage_Candy"): -> has_candy }
You: No, I haven't yet. Let me have a look around.
You: You: <i>Hm... there must be some stored here somewhere.</i>
-> DONE

=== has_candy
You: I did. Here you go!
DO::RemoveItem F3_Storage_Candy
-> has_candy_cont
-> DONE

=== has_candy_cont
~ given_candy_first_visit = false
???: Mmm, thanks! My name is Mazie, by the way.
You: Oh, you remembered! Do you remember anything else about this place?
Mazie: I remember I kept a flashlight in my bedroom dresser, in the next room over. 
Mazie: The key should be in one of the books on the rightmost bookshelf. 
Mazie: Blue, green, red, or brown... I can't remember which one it was in...
You: Thanks! I'll take a look.
{ SetFlag("F3_Study_Bookshelf") }
->DONE

=== has_candy_returning
Mazie: The key should be in one of the books on the rightmost bookshelf. 
Mazie: Blue, green, red, or brown... I can't remember which one...
You: I'll take a look.
-> DONE