INCLUDE Functions.ink

-> start

=== start

You: <i>I played the notes on this sheet and now the piano looks to be playing something on its own</i>
{ HasItem("Music_Sheet"): -> resolve }
//this needs to be developed more 

-> DONE

=== resolve
<i>I dont think I need this music sheet anymore</i>
DO::RemoveItem Music_Sheet

-> DONE