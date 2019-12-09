INCLUDE Functions.ink
VAR got_key = false
VAR returning_from_puzzle = false
-> start

=== start
{ returning_from_puzzle: -> after_puzzle }
{ HasFlag("F3_Bookshelf_Solved"): -> returning }
~ returning_from_puzzle = true
You: This bookshelf is a mess...
DO::OpenPuzzle
->DONE

=== after_puzzle
~ returning_from_puzzle = false
{ not HasFlag("F3_Bookshelf_Solved"): -> start }
You: Hey, a key fell out of one of the books!
<i>Obtained Dresser Key</i>
DO::AddItem Items/F3_Dresser_Key
~ got_key = true
-> DONE

=== bookshelf
{ got_key: -> returning}
You: This bookshelf is a mess...
You: Better clean it up while I look for that key.
-> DONE

=== returning
You: The bookshelf is nice and organized now.
-> DONE 
