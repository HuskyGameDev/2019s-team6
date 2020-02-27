# Where is it updated?

## Interactable Button visibility/position
The position and visibility of the interaction button is done in the `Player` script. The player is already tracking a reference to the current interactable, and putting it here lets us run the `LateUpdate` position update once, rather than once for each interactable. This lets us cut out state logic from `Interactable`.
