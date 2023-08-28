Source code is available on my [Github Repository](https://github.com/ZhengYiHu/WebGL_Portfolio/tree/main).

## Website

I created a new [WebGL Template](https://docs.unity3d.com/Manual/webgl-templates.html) that would position my game in a Canvas object that will expand over the whole screen to simulate a FullScreen window.
Check my [Full Screen WebGL Template](https://github.com/ZhengYiHu/WebGL_Fullscreen_Template) for more information.

The build is then hosted hosted on [Github Pages](https://pages.github.com/) and is inspired by it's default static site system to add content in the form of **Markdown** files.

## Markdown Parsing

I used the library [FancyTextRendering](https://github.com/JimmyCushnie/FancyTextRendering) to parse my **MD** files and store them into text boxes that support **Rich Text** rendering to speed up the addition of new content in my pages.

## Streaming Assets

In order to limit the initial loading time of the project, I moved some of the heaviest files into Unity's [Streaming Assets](https://docs.unity3d.com/Manual/StreamingAssets.html) folder, and fetch the file on runtime when needed through **HTML requests**.

## CI/CL

In order to avoid rebuilding the project and deplyong each time a change is made, I set up a quick [Github Action](https://github.com/ZhengYiHu/WebGL_Portfolio/blob/main/.github/workflows/main.yml) that would listen to the commits in the repository using [Game CI](https://game.ci/).

Each time a new push is detected, the action would trigger to make a new **WebGL build** and deploy it on the **gh-pages** branch, that is set up as source for the deoplyed website.

## Limitations and Future plans

Since the view is effectively just an Unity game window, all the resemblances to a regular website are just simulated in the engine and many of those expected behaviours are still not implemented yet.
Some examples are:
 - Text size adapting according to the view setting
 - Not being able to select and copy text
 - Not being able to zoom in and out by pinching and dragging on mobile
 - The back button would make the user leave the game view
 - Scrolling with middle mouse button doesn't work

---

#### Notes
- There was a bug in Unity where `TMP_TextUtilities.FindIntersectingLink` wouldn't work when `TextOverflowModes` is set to `TextOverflowModes.Link`.
 More information in [this bug thread](https://forum.unity.com/threads/tmp_textutilities-findintersectinglink-is-bugged-on-textoverflowmodes-link.1482768/).

    A workaround I used is to rewrite and fix the functionality of `FindIntersectingLink` in a custom class and use that instead, until Unity fixes the official one themselves.

- Images and videos will not work in editor since they being stripped from the game files.
A solution would be to create a `Removable Assets` folder in game for editor visualization.
Add a deployment job to move that folder's content into the `StreamableAssets` folder to be hosted online just before the build begins.
