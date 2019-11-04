EXTERNAL HasItem(name)
EXTERNAL HasCollectedItem(name)
EXTERNAL EndAndMovePlayerToDoor(scene, door)

// Flag functions
EXTERNAL HasFlag(name)
EXTERNAL SetFlag(name)
EXTERNAL ClearFlag(name)

=== function HasItem(name)
Fallback.
~ return false

=== function HasCollectedItem(name)
Fallback.
~ return false

=== function EndAndMovePlayerToDoor(scene, door)
Fallback
~ return

=== function HasFlag(name)
Fallback
~ return false

=== function SetFlag(name)
Fallback
~ return

=== function ClearFlag(name)
Fallback
~ return
