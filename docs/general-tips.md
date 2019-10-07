# General Tips/Tricks/Recommendations

## If it can be in a prefab, put it in a prefab

Unity 2018.3 made it very easy to keep things isolated in prefabs. It is recommended to put all puzzles, interfaces, enemies, furniture, etc., in prefabs for several reasons. The main two are:

1. A prefab can be modified without modifying the scenes it is in.

    This can eliminate many merge conflicts. Overrides may be necessary in certain scenes for level-specific things, like triggers, layout of the environment, references to other prefabs, etc., but keeping things in prefabs keeps things clean.

2. One prefab can be used in multiple scenes.

    Because prefabs can be shared between scenes and will be consistent across those scenes, they should be used for things that appear in more than one scene (hence, the `RequiredLevelObject` prefab, which has all of our camera, audio, and interface objects and scripts). Any future levels require that prefab to be present, but won't need any duplicate interfaces copied or updated across them.
