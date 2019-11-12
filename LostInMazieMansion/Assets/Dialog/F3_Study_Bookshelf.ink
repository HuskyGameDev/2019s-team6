INCLUDE Functions.ink
VAR got_key = false
-> start

=== start
{ HasFlag("F3_Study_Bookshelf"): -> bookshelf }
You: This bookshelf is a mess...
->DONE

=== bookshelf
{ got_key: -> returning}
You: This bookshelf is a mess...
You: Better clean it up while I look for that key.
You: Hey, a key fell out of one of the books!
<i>Obtained Dresser Key</i>
DO::AddItem Items/F3_Dresser_Key
~ got_key = true
-> DONE

=== returning
You: The bookshelf is nice and organized now.
-> DONE 
