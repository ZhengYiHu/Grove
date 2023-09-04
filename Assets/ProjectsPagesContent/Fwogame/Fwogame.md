#### Where to play

The game is available on my [Itch](https://zyhu.itch.io/fwogame) or right [HERE](https://zyhu.me/Fwogame)!

Source code available on my [Github](https://github.com/ZhengYiHu/Fwogame)

#### Inspiration

The idea came from playing some of [Sokpop](https://sokpop.co/)'s little games, and I just wanted to make a small little project to replicate their signature leg animation as showcased in [this video](https://www.youtube.com/watch?v=2LbKuQsODHg).


#### Procedural Limbs Animations

I used Unity's line renderer to create the limbs setting the origin on the character's body and the end at the target end effector which is going to be calculated according to various factors.

1. First of all, the end effector will anchor to the terrain and will not move when the body of the character and the origin of the limb moves around.
2. I set a maximum **Tollerance** range around each end effector.
3. a **Ray** is cast from each origin point downwards to determine how much the character has moved from the anchored point.
4. If the Raycast's hit point exceeded the Tollerance range, then the legs end effectors will be repositioned to the new target, making the caracter effectively perform a **step**.
5. A small offset and other adjustments are added for the walking cycle to look more natural.
6. More animations are then added to other parts of the character, like body rotations and damping based on the current velocity and so on.

#### More screenshots
