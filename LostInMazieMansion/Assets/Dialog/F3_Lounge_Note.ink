VAR read = false
-> start

=== start
{ read: -> returning}
You: There's a note on the table. It reads:
Note: ‘Go to the fireplace which is at the north end, against the wall... If you want to get out, you must look about... Hit three bricks and what you seek will fall out... 
Note: The secret lies where the smoke will rise, and what will rise must fall down to ash... if your last press is right you will solve this riddle..’
~ read = true
-> DONE

=== returning
Note: The note reads:
Note: ‘Go to the fireplace which is at the north end, against the wall... If you want to get out, you must look about... Hit three bricks and what you seek will fall out... 
Note: The secret lies where the smoke will rise, and what will rise must fall down to ash... if your last press is right you will solve this riddle..’
-> DONE 
