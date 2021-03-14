INCLUDE Functions.ink
VAR first_visit = true
-> start

=== start
{not first_visit: -> returning}
~ first_visit = false
You: Hi Mazie!
Mazie: Hello! This is my first time talking to you!
You: Great!
-> DONE

=== returning
You: Hello again.
Mazie: Hi, I've talked to you before!
You: Yes, you have.
Mazie: Do you have any candy?
{ HasItem("F3_Storage_Candy"): -> has_candy}
You: Nah fam
-> DONE

=== has_candy
DO::RemoveItem F3_Storage_Candy
You: Yes, I do.
Mazie: Thanks! *devours with gusto*
You: Poggers
-> DONE